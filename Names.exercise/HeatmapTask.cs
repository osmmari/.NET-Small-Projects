using System;

namespace Names
{
	internal static class HeatmapTask
	{

		public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
		{
            /*
			Подготовьте данные для построения карты интенсивностей, у которой по оси X — число месяца, по Y — номер месяца, 
			а интенсивность точки (она отображается цветом и размером) обозначает количество рожденных людей в это число этого месяца.
			Не учитывайте людей, родившихся первого числа любого месяца.

			В качестве подписей (label) по X используйте число месяца. 
			Поскольку данные за первые числа месяца учитывать не нужно, то начинайте подписи со второго числа.
			В качестве подписей по Y используйте номер месяца (январь — 1, февраль — 2, ...).

			Таким образом, данные для карты интенсивностей должны быть в виде двумерного массива 30 на 12 —  от 2 до 31 числа и от января до декабря.
			*/

            var days = new string[30];
            var months = new string[12];
            var values = new double[30,12];

            // X axis (days)
            for (int i = 2; i <= 31; i++)
            {
                days[i - 2] = i.ToString();
            }

            // Y axis (months)
            for (int i = 1; i <= 12; i++)
            {
                months[i - 1] = i.ToString();
            }

            foreach (var name in names)
            {
                if (name.BirthDate.Day != 1)
                {
                    values[name.BirthDate.Day-2, name.BirthDate.Month - 1]++;
                }
            }

            return new HeatmapData("Карта интенсивностей", values, days, months);
		}
	}
}