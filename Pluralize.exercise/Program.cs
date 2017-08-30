using System;
using System.IO;

namespace Pluralize
{
	public static class Program
	{
		static void Main(string[] args)
		{
			// Это пример ввода сложных данных из файла.
			// Циклы, строки, массивы будут рассмотрены на лекциях чуть позже, но это не должно быть препятствием вашему любопытству! :)
			string[] lines = File.ReadAllLines("rubles.txt");
			bool hasErrors = false;
			foreach (var line in lines)
			{
				string[] words = line.Split(' ');
				int count = int.Parse(words[0]);
				string rightAnswer = words[1];
				string pluralizedRubles = PluralizeTask.PluralizeRubles(count);
				if (pluralizedRubles != rightAnswer)
				{
					hasErrors = true;
					Console.WriteLine(String.Format("Wrong answer: {0} {1}", count, pluralizedRubles));
				}
			}
			if (!hasErrors)
				Console.WriteLine("Correct!");
            Console.WriteLine("hi");
		}
	}
}