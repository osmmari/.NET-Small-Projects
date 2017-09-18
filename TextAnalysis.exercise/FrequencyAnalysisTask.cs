using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
	static class FrequencyAnalysisTask
	{
		public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
		{
            // find all pairs of words
            var bigram = new Dictionary<string, string>();
            var wordsFrequency = new Dictionary<string, Dictionary<string, int>>();

            foreach (var sentence in text)
            {
                for (int i = 0; i < sentence.Count - 1; i++)
                {
                    if (!wordsFrequency.ContainsKey(sentence[i]))
                    {
                        wordsFrequency.Add(sentence[i], new Dictionary<string, int>());
                        wordsFrequency[sentence[i]].Add(sentence[i + 1], 1);
                    }
                    else
                    {                        
                        if (wordsFrequency[sentence[i]].ContainsKey(sentence[i+1]))
                            wordsFrequency[sentence[i]][sentence[i + 1]]++;
                        else wordsFrequency[sentence[i]].Add(sentence[i+1], 1);
                    }
                }
            }

            // sort resulting dictionary for each word
            foreach (var pairWords in wordsFrequency)
            {
                var setOfWords = pairWords.Value;
                int max = int.MinValue;
                string bestWord = "";
                foreach (var word in setOfWords.Keys)
                {
                    if (setOfWords[word] == max)
                    {
                        if (string.CompareOrdinal(word, bestWord) < 0) bestWord = word;
                    }
                    else if (setOfWords[word] > max)
                    {
                        max = setOfWords[word];
                        bestWord = word;
                    }
                }
                bigram.Add(pairWords.Key, bestWord);
            }

            return bigram;
		}

	}
}