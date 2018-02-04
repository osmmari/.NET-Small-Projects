using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_slideviews
{
	public class ParsingTask
	{
        private static int slideId;
        private static int userId;
        private static Dictionary<int, SlideRecord> dict = new Dictionary<int, SlideRecord>();
        private static string errorLine;

        /// <param name="lines">все строки файла, которые нужно распарсить. Первая строка заголовочная.</param>
        /// <returns>Словарь: ключ — идентификатор слайда, значение — информация о слайде</returns>
        /// <remarks>Метод должен пропускать некорректные строки, игнорируя их</remarks>
        public static IDictionary<int, SlideRecord> ParseSlideRecords(IEnumerable<string> lines)
		{
            return lines
                .Where(line => CheckItIsNotEmpty(line))
                .Select(x => new { split = x.Split(';') })
                .Where(some => CheckItIsRightSlideId(some.split.ElementAtOrDefault(0)))
                .ToLookup(line => slideId)
                .ToDictionary( line => line.Key,
                line => 
                    new SlideRecord(int.Parse(line.First().split.ElementAt(0)), GetType(line.First().split.ElementAt(1)), line.First().split.ElementAtOrDefault(2)));
        }

        private static bool CheckIfSameKey(int id)
        {
            return !dict.ContainsKey(id);
        }

        private static bool CheckItIsRightSlideId(string id)
        {
            return int.TryParse(id, out slideId);
        }

        private static bool CheckItIsNotEmpty(string line)
        {
            string[] lines = line.Split(';');
            return line != null && line != "" && lines.Count()==3 && lines[2]!="" && CheckForType(lines[1]);
        }

        private static bool CheckForType(string input)
        {
            return input == "theory" || input == "exercise" || input == "quiz";
        }

        private static SlideType GetType(string input)
        {
            switch (input)
            {
                case "theory":
                    return SlideType.Theory;
                case "exercise":
                    return SlideType.Exercise;
                case "quiz":
                    return SlideType.Quiz;
            }
            return 0;
        }

        /// <param name="lines">все строки файла, которые нужно распарсить. Первая строка — заголовочная.</param>
        /// <param name="slides">Словарь информации о слайдах по идентификатору слайда. 
        /// Такой словарь можно получить методом ParseSlideRecords</param>
        /// <returns>Список информации о посещениях</returns>
        /// <exception cref="FormatException">Если среди строк есть некорректные</exception>
        public static IEnumerable<VisitRecord> ParseVisitRecords(
			IEnumerable<string> lines, IDictionary<int, SlideRecord> slides)
		{
            return lines
                .Where(line => SaveLine(line))
                .Select(x => new { split = x.Split(';') })
                .Where(some => CheckVisited(some.split.ElementAtOrDefault(0), slides) && CheckItIsRightSlideId(some.split.ElementAtOrDefault(1)))
                //.Where(some => slides.ContainsKey(slideId))
                .Select(line => new VisitRecord(userId, 
                    slideId,
                    GetDate(line.split.ElementAtOrDefault(2), line.split.ElementAtOrDefault(3)),
                    slides[slideId].SlideType));
        }

        private static DateTime GetDate(string date, string time)
        {
            string dateString = string.Format("{0} {1}", date, time);
            if (DateTime.TryParse(dateString, out DateTime result)) return result;
            else
            {
                string message = string.Format("Wrong line [{0}]", errorLine);
                throw new FormatException(message);
            }
        }

        private static bool CheckVisited(string id, IDictionary<int, SlideRecord> slides)
        {
            string[] lines = errorLine.Split(';');

            if (lines.Count() == 4)
            {

                string[] dates = lines[2].Split('-');
                string[] times = lines[3].Split(':');

                if (int.TryParse(id, out userId) && dates.Count() == 3 && times.Count() == 3 && int.TryParse(lines[1], out slideId) && slides.ContainsKey(slideId))
                    return true;
                else if (errorLine == "UserId;SlideId;Date;Time") return false;
            }
            string message = string.Format("Wrong line [{0}]", errorLine);
            throw new FormatException(message);
        }

        private static bool SaveLine(string line)
        {
            errorLine = line;
            Console.WriteLine(line);
            return true;
        }
    }
}