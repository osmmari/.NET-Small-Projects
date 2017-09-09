using System;
using System.Linq;

namespace Names
{
	internal static class HistogramTask
	{
		public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
		{
            /*
			Напишите код, готовящий данные для построения гистограммы 
			— количества людей в выборке c заданным именем в зависимости от числа (то есть номера дня в месяце) их рождения.
			Не учитывайте тех, кто родился 1 числа любого месяца.
			Если вас пугает незнакомое слово гистограмма — вам как обычно в википедию! 
			http://ru.wikipedia.org/wiki/%D0%93%D0%B8%D1%81%D1%82%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B0

			В качестве подписей (label) по оси X используйте число месяца.

			Объясните наблюдаемый результат!

			Пример подготовки данных для гистограммы смотри в файле HistogramSample.cs
			*/

            var days = new string[31];
            var birthCounts = new double[31];

            // X axis (days)
            for (int i = 1; i <= 31; i++)
            {
                days[i - 1] = i.ToString();
            }

            // Y values (counts of birthes)
            foreach (var nameSample in names)
            {
                if (nameSample.Name == name)
                {
                    if (nameSample.BirthDate.Day != 1) birthCounts[nameSample.BirthDate.Day-1]++;
                }
            }

			return new HistogramData(string.Format("Рождаемость людей с именем '{0}'", name), days, birthCounts);
		}
	}
}