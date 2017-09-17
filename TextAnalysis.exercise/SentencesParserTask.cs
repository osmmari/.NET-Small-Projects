using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static readonly string[] StopWords =
        {
            "the", "and", "to", "a", "of", "in", "on", "at", "that",
            "as", "but", "with", "out", "for", "up", "one", "from", "into"
        };

        /*
		Разбейте файл с текстом на предложения и слова. 
		Считайте, что слова могут состоять только из букв (используйте метод char.IsLetter) или символа апострофа ',
		а предложения разделены одним из следующих символов .!?;:()
		Слова могут быть разделены любыми символами, за исключением тех, которые разделяют предложения.
		Удалите из текста слова, содержащиеся в массиве StopWords (частые незначащие слова при анализе текстов называют стоп-словами)
		Метод должен возвращать список предложений, где каждое предложение — это список оставшихся слов в нижнем регистре.
		*/
        public static List<List<string>> ParseSentences(string text)
        {
            // divide on sentences
            //Console.WriteLine("|| Дан следующий текст: {0} || \n", text);
            var sentences = text.Split('.', '!', '?', ';', ':', '(', ')');

            // divide each sentence on words and create a list of correct words
            // then this list is adding to result list
            var resultSentences = new List<List<string>>();
            foreach (var sentence in sentences)
            {
                var words = new List<string>();
                var separator = RemoveAllMud(sentence);
                var wordsCollect = sentence.Split(separator);
                foreach (var w in wordsCollect)
                {
                    //Console.Write("Word before replace : {0}", w); Console.WriteLine();
                    var word = Regex.Replace(w, @"\p{C}+", String.Empty);
                    word = word.ToLower();
                    //Console.Write("Word after : {0}", word); Console.WriteLine();
                    if (word.Length > 0)
                        if (!IsWordInStopWords(word) && (char.IsLetter(word[0]) || word.StartsWith("\'")))
                        {
                            words.Add(word);
                        }
                }
                if (words.Count > 0) resultSentences.Add(words);
                /*
                foreach (var s in words) Console.Write(s);
                Console.WriteLine();
                */
            }
            //Console.WriteLine("--------------------------------------");
            return resultSentences;
        }

        public static bool IsWordInStopWords(string word)
        {
            foreach (var stopWord in StopWords) if (word == stopWord) return true;
            return false;
        }

        public static char[] RemoveAllMud(string sentence)
        {
            var separator = new char[sentence.Length];
            int i = 0;
            foreach (char symbol in sentence)
            {
                if (!char.IsLetter(symbol) && symbol != '\'') separator[i] = symbol;
                i++;
            }
            return separator;
        }
	}
}