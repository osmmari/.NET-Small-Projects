using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle
{
    public class Indexer : IIndexer
    {
        private Dictionary<int, List<string>> words = new Dictionary<int, List<string>> { };
        private int id;
        private readonly char[] separator = { ' ', '.', ',', '!', '?', ':', '-', '\r', '\n' };

        public int Id
        {
            get { return id; }
            set { id = value;}
        }

        public List<string> Words
        {
            set { if (words.ContainsKey(id))
                    words[id].AddRange(value);
                  else words.Add(id, value); }
        }

        public void Add(int id, string documentText)
        {
            Console.WriteLine("id = {0}, document = {1}", id, documentText);
            Id = id;
            var listOfWords = documentText.Split(separator);
            Words = listOfWords.ToList<string>();
        }

        public List<int> GetIds(string word)
        {
            //Console.WriteLine("GetIds");
            var result = new List<int>();
            foreach(var id in words.Keys)
            {
                foreach(var getWord in words[id])
                {
                    if (getWord == word)
                     {
                            //Console.WriteLine("Trying add id {0}", id);
                            result.Add(id);
                            break;
                     }
                }
            }
            return result;
        }

        public List<int> GetPositions(int id, string word)
        {
            //Console.WriteLine("GetPos");
            var result = new List<int>();
            int count = 0;
            foreach (var getWord in words[id])
            {
                if (getWord == "") count++;
                else
                {
                    if (getWord[0] == word[0])
                    {
                        if (getWord.Equals(word))
                        {
                            //Console.WriteLine("Trying add id {0}", id);
                            result.Add(count);
                        }
                    }
                    count = count + getWord.Length + 1;
                }
            }
            return result;
        }

        public void Remove(int id)
        {
            words.Remove(id);
        }
    }
}
