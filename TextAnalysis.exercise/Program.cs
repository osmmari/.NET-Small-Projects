using System;
using System.IO;
using System.Linq;

namespace TextAnalysis
{
	internal static class Program
	{
		public static void Main()
		{
			var text = File.ReadAllText("Text.txt");

			Console.WriteLine("SentencesParserTask:");
			var sentences = SentencesParserTask.ParseSentences(text);
			for (int i = 0; i < Math.Min(10, sentences.Count); i++)
				Console.WriteLine(string.Join("|", sentences[i]) + ".");

			Console.WriteLine("FrequencyAnalysisTask:");
			var frequency = FrequencyAnalysisTask.GetMostFrequentNextWords(sentences);
			foreach (var keyValuePair in frequency.Take(10))
			{
				Console.WriteLine($"{keyValuePair.Key}|{keyValuePair.Value}");
			}

            Console.WriteLine();
			Console.WriteLine("BigramGeneratorTask:");
			foreach (var start in new[] { "harry", "he", "boy", "ron", "wizard" })
			{
				var phrase = BigramGeneratorTask.ContinuePhraseWithBigramms(frequency, start, 5);
				Console.WriteLine(phrase);
			}

            /*
			Эту часть задания можете выполнить по желанию.

			Console.WriteLine();
			Console.WriteLine("TrigramGeneratorTask:");
			foreach (var start in new[] { "harry potter", "ron weasley", "hermione granger" })
			{
				var phrase = TrigramGeneratorTask.ContinuePhraseWithTrigramms(frequency, start, 5);
				Console.WriteLine(phrase);
			}
			*/
        }
	}
}