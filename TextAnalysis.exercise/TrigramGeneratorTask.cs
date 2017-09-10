using System.Collections.Generic;

namespace TextAnalysis
{
	internal static class TrigramGeneratorTask
	{
		/*
		Повторите ту идею с Биграммами, только используя триграммную модель текста.
		Теперь вам преедается словарь, в котором ключем являются два первых слова триграмм текста (разделенные пробелом),
		а значение — третье слово триграммы.
		Продолжите фразу до длины phraseWordsCount слов так, чтобы каждое следующее 
		слово определялось двумя предыдущими по переданному словарю.
		*/
		public static string ContinuePhraseWithTrigramms(Dictionary<string, string> mostFrequentNextWords, string phraseBeginning, int phraseWordsCount)
		{
			return phraseBeginning;
		}
	}
}
