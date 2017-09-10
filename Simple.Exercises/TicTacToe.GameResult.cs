using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        public enum Mark
        {
            Empty,
            Cross,
            Circle
        }

        public enum GameResult
        {
            CrossWin,
            CircleWin,
            Draw
        }

        public static void Main()
        {
            Check("XXX OO. ...");
            Check("OXO XO. .XO");
            Check("OXO XOX OX.");
            Check("XOX OXO OXO");
            Check("... ... ...");
            Check("XXX OOO ...");
            Console.ReadKey();
        }

        private static void Check(string description)
        {
            Console.WriteLine(description.Replace(" ", "\r\n"));
            Console.WriteLine(GetGameResult(CreateFromString(description)));
            Console.WriteLine();
        }

        public static Mark[,] CreateFromString(string description)
        {
            var result = new Mark[3, 3];
            description = description.Replace(" ", "");
            for (int y = 0; y < 3; y++)
                for (int x = 0; x < 3; x++)
                {
                    switch (description[3 * y + x])
                    {
                        case 'X':
                            result[x, y] = Mark.Cross;
                            break;
                        case 'O':
                            result[x, y] = Mark.Circle;
                            break;
                        case '.':
                            result[x, y] = Mark.Empty;
                            break;
                    }
                }
            return result;
        }

        public static GameResult GetGameResult(Mark[,] field)
        {
            if (HasWinSequence(field, Mark.Cross) && HasWinSequence(field, Mark.Circle)) return GameResult.Draw;
            else if (HasWinSequence(field, Mark.Cross)) return GameResult.CrossWin;
            else if (HasWinSequence(field, Mark.Circle)) return GameResult.CircleWin;
            return GameResult.Draw;
        }

        public static bool HasWinSequence(Mark[,] field, Mark mark)
        {
            for (int y = 0; y < 3; y++)
            {
                if (field[0, y] == mark && field[1, y] == mark && field[2, y] == mark) return true;
                if (field[y, 0] == mark && field[y, 1] == mark && field[y, 2] == mark) return true;
            }
            if (field[1,1] == mark)
            {
                if (field[0, 0] == mark && field[2, 2] == mark) return true;
                if (field[2, 0] == mark && field[0, 2] == mark) return true;
            }
            return false;
        }
    }
}
