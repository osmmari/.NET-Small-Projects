using System.Collections.Generic;

namespace TextAnalysis
{
	static class BigramGeneratorTask
	{
		/*
		По словарю, созданному в предыдущей задаче и по первому слову фразы 
		продолжите фразу до длины phraseWordsCount слов так, чтобы каждое следующее 
		слово определялось предыдущим по переданному словарю.
		
		Если в какой-то момент по словарю продолжить фразу нельзя, то на этом месте фразу нужно закончить.
		*/
		public static string ContinuePhraseWithBigramms(
			Dictionary<string, string> mostFrequentNextWords, 
			string phraseBeginning, 
			int phraseWordsCount)
		{
            string resultSentence = phraseBeginning;

            int i = 1;
            while (i < phraseWordsCount)
            {
                if (!mostFrequentNextWords.ContainsKey(phraseBeginning)) return resultSentence;
                var phrase = mostFrequentNextWords[phraseBeginning];
                resultSentence += " " + phrase;
                phraseBeginning = phrase;
                i++;
            }

			return resultSentence;
		}
	}
}