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

        /// <param name="lines">все строки файла, которые нужно распарсить. Первая строка заголовочная.</param>
        /// <returns>Словарь: ключ — идентификатор слайда, значение — информация о слайде</returns>
        /// <remarks>Метод должен пропускать некорректные строки, игнорируя их</remarks>
        public static IDictionary<int, SlideRecord> ParseSlideRecords(IEnumerable<string> lines)
		{
            /*lines
                .Select(x => new { split = x.Split(';') })
                .Where(some => CheckItIsRightSlideId(some.split.ElementAtOrDefault(0)))
                .Where(some => CheckIfSameKey(slideId))
                .Select(line => dict.Add(slideId, new SlideRecord(slideId, GetType(line.split.ElementAt(1)), line.split.ElementAtOrDefault(2))));*/

            return lines
                .Select(x => new { split = x.Split(';') })
                .Where(some => CheckItIsRightSlideId(some.split.ElementAtOrDefault(0)))
                .ToDictionary(line => slideId,
                line => new SlideRecord(slideId, GetType(line.split.ElementAt(1)), line.split.ElementAtOrDefault(2)));

            //dict.Add(key: int.Parse(x[0]), value: new SlideRecord(int.Parse(x[0]), SlideType.Theory, x[2]));
            //return dict;
        }

        private static bool CheckIfSameKey(int id)
        {
            return !dict.ContainsKey(id);
        }

        private static bool CheckItIsRightSlideId(string id)
        {
            return int.TryParse(id, out slideId);
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
            return SlideType.Theory;
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
                .Select(x => new { split = x.Split(';') })
                .Where(some => CheckVisited(some.split.ElementAtOrDefault(0)) && CheckItIsRightSlideId(some.split.ElementAtOrDefault(1)))
                //.Where(some => slides.ContainsKey(slideId))
                .Select(line => new VisitRecord(userId, 
                    slideId,
                    GetDate(line.split.ElementAtOrDefault(2), line.split.ElementAtOrDefault(3)),
                    slides[slideId].SlideType));
        }

        private static DateTime GetDate(string date, string time)
        {
            var parsedDate = date.Split('-').Select(x => int.Parse(x)).ToArray();
            var parsedTime = time.Split(':').Select(x => int.Parse(x)).ToArray();

            return new DateTime(parsedDate[0], parsedDate[1], parsedDate[2], parsedTime[0], parsedTime[1], parsedTime[2]);
        }

        private static bool CheckVisited(string id)
        {
            if (int.TryParse(id, out userId))
                return true;
            else if (id == "UserId") return false;
            else throw new FormatException("Wrong line [very wrong line!]");
        }
    }
}