using System;
using System.Globalization;

namespace Names
{
	public class NameData
	{
		public NameData(int year, int month, int day, string name)
			:this(new DateTime(year, month, day), name)
		{
		}

		public NameData(DateTime birthDate, string name)
		{
			BirthDate = birthDate;
			Name = name;
		}


		/// <summary>Дата рождения</summary>
		public DateTime BirthDate;

		/// <summary>Имя</summary>
		public string Name;

		public static NameData ParseFrom(string textLine)
		{
			string[] parts = textLine.Split('\t');
			const string format = "dd.MM.yyyy";
			var date = DateTime.ParseExact(parts[0], format, CultureInfo.InvariantCulture);
			return new NameData(date, parts[1]);
		}

		public override string ToString()
		{
			return String.Format("{0}    {1}", BirthDate.ToString("dd.MM.yyyy"), Name);
		}
	}
}