using System.Collections.Generic;
using System;

namespace TableParser
{
    public class FieldsParserTask
    {
        // При решении этой задаче постарайтесь избежать создания методов, длиннее 10 строк.
        // Ниже есть метод ReadField — это подсказка. Найдите класс Token и изучите его.
        // Подумайте как можно использовать ReadField и Token в этой задаче.

        public static int Index
        {
            get; set;
        }

        public static List<string> ParseLine(string line)
        {
            Console.WriteLine(line);
            Index = 0;
            var result = new List<string> { };
            while (Index < line.Length)
            {
                result.Add(ReadField(line, Index));
            }

            //Console.WriteLine("{0} \n", line);
            //foreach (var a in result) Console.Write("{0} ", a);

            result.Remove(null);

            return result; // сокращенный синтаксис для инициализации коллекции.
        }


        private static string ReadField(string line, int startIndex)
        {
            int length = 0;
            bool isSpaces = false;

            //while (startIndex < line.Length && length == 0)
            while (startIndex < line.Length && length == 0 && !isSpaces)
            {
                if (line[startIndex] == ' ') { startIndex++; }
                else if (line[startIndex] == '\"' && line.IndexOf('\"', startIndex + 1) != -1)
                {
                    startIndex++;
                    length = line.IndexOf('\"', startIndex) - startIndex;
                    Index = startIndex + length + 1;
                    if (length == 0) isSpaces = true;
                }
                else if (line[startIndex] == '\'' && line.IndexOf('\'', startIndex + 1) != -1)
                {
                    startIndex++;
                    length = line.IndexOf('\'', startIndex) - startIndex;
                    Index = startIndex + length + 1;
                    if (length == 0) isSpaces = true;
                }
                else if (line[startIndex] == '\"' || line[startIndex] == '\'')
                {
                    startIndex++;
                    length = line.Length - startIndex;
                    Index = startIndex + length + 1;
                    if (length == 0) isSpaces = true;
                }
                else
                {
                    length = Min(line, startIndex) - startIndex;
                    Index = startIndex + length;
                }
            }

            if (length == 0)
            {
                if (isSpaces)
                {
                    return "";
                }
                else { Index = line.Length; return null; }
            }

            return SlashRemove(line.Substring(startIndex, length));
            //new Token(line, startIndex, length);
        }

        private static int Min(string line, int startIndex)
        {
            var symbols = new[] { '\'', '\"', ' ' };
            var temp = new List<int>();
            foreach (var symbol in symbols)
            {
                int ind = line.IndexOf(symbol, startIndex + 1);
                if (ind != -1) temp.Add(ind);
            }
            if (temp.Count > 0)
            {
                temp.Sort();
                return temp[0];
            }
            return line.Length;
        }

        private static string SlashRemove(string word)
        {
            string result = "";
            if (word.Length > 1)
            {
                for (int i = 0; i < word.Length; i++)
                {
                        if (word[i] == '\\' && word[i + 1] == '\\')
                        {
                            result += '\\';
                            i++;
                        }
                        else result += word[i];
                }
            }
            else
            {
                result = word;
            }
            return result;
        }
    }
}