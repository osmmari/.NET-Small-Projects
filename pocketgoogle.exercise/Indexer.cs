using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle
{
    public class Indexer : IIndexer
    {
        private Dictionary<int, string[]> words = new Dictionary<int, string[]> { };
        private Dictionary<string, List<int>> ids = new Dictionary<string, List<int>> { };
        private readonly char[] separator = { ' ', '.', ',', '!', '?', ':', '-', '\r', '\n' };

        public void Add(int id, string documentText)
        {
            //Console.WriteLine("id = {0}, text = {1}", id, documentText);
            var listOfWords = documentText.Split(separator);
            if (words.ContainsKey(id)) words[id] = words[id].Concat(listOfWords).ToArray();
            else words.Add(id, listOfWords);

            foreach (var word in listOfWords)
            {
                if (ids.ContainsKey(word))
                {
                    if (!ids[word].Contains(id))
                        ids[word].Add(id);
                }
                else ids.Add(word, new List<int> { id });
            }
        }

        public List<int> GetIds(string word)
        {
            //Console.WriteLine("Get id of word {0}", word);
            if (ids.ContainsKey(word))
            {
                var needToDelete = new List<int>();
                foreach (var id in ids[word])
                {
                    if (!words.ContainsKey(id))
                    {
                        needToDelete.Add(id);
                    }
                }
                foreach (var id in needToDelete)
                {
                    ids[word].Remove(id);
                }
                return ids[word];
            }
            return new List<int>();
        }

        public List<int> GetPositions(int id, string word)
        {
            //Console.WriteLine("Get pos in id {0} of word {1}", id, word);
            var result = new List<int>();
            int index = 0;
            foreach (var getWord in words[id])
            {
                if (getWord == "") index++;
                else
                {
                    if (getWord[0] == word[0])
                    {
                        if (getWord == word)
                        {
                            result.Add(index);
                        }
                    }
                    index += getWord.Length + 1;
                }
            }
            return result;
        }

        public void Remove(int id)
        {
            //Console.WriteLine("Remove id {0}", id);
            words.Remove(id);
        }
    }
}
