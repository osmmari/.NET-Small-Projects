using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(Calculate(input));
            Console.ReadKey();

        }

        public struct Input
        {
            public static double sum;
            public static double rate;
            public static double time;
        }

        public static double Calculate(string userInput)
        {
            string[] variables = userInput.Split(' ');
            double[] doubles = new double[3];

            for (int i = 0; i < 3; i++)
            {
                doubles[i] = Convert.ToDouble(variables[i]);
            }

            Input.sum = doubles[0];
            Input.rate = doubles[1] / 12.0;
            Input.time = doubles[2];

            return Input.sum * Math.Pow((1 + (Input.rate / 100.0)), Input.time);
        }
    }
}
