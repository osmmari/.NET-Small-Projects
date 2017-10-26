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
        private Dictionary<int, string> strings = new Dictionary<int, string> { };
        private int id;
        private readonly char[] separator = { ' ', '.', ',', '!', '?', ':', '-', '\r', '\n' };

        public int Id
        {
            get { return id; }
            set { id = value;
                if (!words.ContainsKey(id))
                    words.Add(id, new List<string>()); }
        }

        public List<string> Words
        {
            //get { return words; }
            set { if (words.ContainsKey(Id))
                    words[Id] = value;
                  else words.Add(Id, value); }
        }

        public void Add(int id, string documentText)
        {
            //Console.WriteLine("Add");
            Id = id;
            if (!strings.ContainsKey(id)) strings.Add(id, documentText);
            else strings[id] = documentText;
            var listOfWords = documentText.Split(separator);
            Words = listOfWords.ToList<string>();
            //Console.WriteLine("The end of Add");
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
                        if (!result.Contains(id))
                            result.Add(id);
                    }
                }
            }
            //Console.WriteLine("The end of GetIds");
            return result;
        }

        public List<int> GetPositions(int id, string word)
        {
            //Console.WriteLine("GetPositions");
            var result = new List<int>();
            int count = 0;
            Id = id;
            foreach (var getWord in words[Id])
            {
                if (getWord.Equals(word))
                {
                    //if (!result.Contains(count))
                        result.Add(count);
                }
                if (getWord == "") count++;
                else count = count + getWord.Length + 1;
            }

            /*string allWords = String.Join(" ", words[Id]);
            var length = word.Length;

            while (allWords.Length > 0)
            {
                int index = allWords.IndexOf(word);
                if (index >= 0)
                {
                    count += index;
                    if (!result.Contains(count))
                        result.Add(count);
                    allWords = allWords.Remove(0, index + 1);
                    count+=1;
                }
                else break;
            }*/

            return result;
        }

        public void Remove(int id)
        {
            //Console.WriteLine("Remove");
            Id = id;
            Words = new List<string> { };
            //Console.WriteLine("The end of Remove");
        }
    }
}
