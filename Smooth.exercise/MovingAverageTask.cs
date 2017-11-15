using System.Collections.Generic;

namespace yield
{
	public static class MovingAverageTask
	{
		public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
		{
            //bool isFirstItem = true;
            double pastAverage = 0; //minAverage = 0;
            int n = 1;

            //foreach(var element in data) n++;

            foreach(var item in data)
            {
                item.AvgSmoothedY = (pastAverage * (n - 1) + item.OriginalY) / n;
                if (n < windowWidth)
                {
                    pastAverage = item.AvgSmoothedY;
                    n++;
                }
                else
                {
                    pastAverage = item.OriginalY;
                }

                /*if (isFirstItem)
                {
                    item.AvgSmoothedY = item.OriginalY;
                    isFirstItem = false;
                    minAverage = item.OriginalY;
                }
                else item.AvgSmoothedY = pastAverage - (minAverage / n) + (item.OriginalY / n);
                pastAverage = item.AvgSmoothedY;*/

                yield return item;
            }
		}
	}
}