using System;
using System.Collections.Generic;
using System.Linq;

namespace yield
{

	public static class MovingMaxTask
	{
		public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
		{
            int n = 1;
            double max = 0.0f;

            foreach(var item in data)
            {
                if (n <= windowWidth)
                {
                    if (max < item.OriginalY) max = item.OriginalY;
                }
                else
                {
                    n = 1;
                    max = item.OriginalY;
                }
                item.MaxY = max;

                n++;

                yield return item;
            }            
		}
	}
}