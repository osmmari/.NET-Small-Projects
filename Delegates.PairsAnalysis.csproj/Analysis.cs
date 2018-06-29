using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.PairsAnalysis
{
    public static class Analysis
    {
        public static int FindMaxPeriodIndex(params DateTime[] data)
        {
			return Finder(data, MaxIndexProcess).MaxIndex();
        }

        public static double FindAverageRelativeDifference(params double[] data)
        {
			return Finder(data, AverageProcess).AverageDifference();
        }

		public static IEnumerable<double> Finder<T>(IEnumerable<T> data, Func<T,T,double> process)
		{
			return data.Pairs ().Select(pair => process(pair.Item1, pair.Item2));
		}

		private static double MaxIndexProcess(DateTime source1, DateTime source2)
		{
			return (source2 - source1).TotalSeconds;
		}

		private static double AverageProcess(double source1, double source2)
		{
			return (source2 - source1) / source1;
		}
    }

	public static class AnalysisExtension
	{
		public static IEnumerable<Tuple<T, T>> Pairs<T>(this IEnumerable<T> data)
		{
			//if (data.Count() < 2) throw new ArgumentException();

			T previous = default(T);
			using (var it = data.GetEnumerator ())
			{
				if (it.MoveNext ())
					previous = it.Current;

				while (it.MoveNext ())
				{
					yield return new Tuple<T,T> (previous, it.Current);
					previous = it.Current;
				}
			}
		}

		public static int MaxIndex<T>(this IEnumerable<T> data) where T : IComparable<T>
		{
            //return data.ToList ().IndexOf (data.Max ());
            int maxIndex = -1;
            T maxValue = default(T);

            int index = 0;
            foreach (T value in data)
            {
                if (value.CompareTo(maxValue) > 0 || maxIndex == -1)
                {
                    maxIndex = index;
                    maxValue = value;
                }
                index++;
            }
            if (maxIndex < 0) throw new ArgumentException();
            return maxIndex;
        }

		public static double AverageDifference(this IEnumerable<double> differences)
		{
			return differences.Sum() / differences.Count ();
		}
	}
}
