using System.Collections.Generic;

namespace yield
{
    public static class ExpSmoothingTask
    {
        public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
        {
            var isFirstItem = true;
            double previousItem = 0;
            foreach (var element in data)
            {
                var item = new DataPoint
                {
                    AvgSmoothedY = element.AvgSmoothedY,
                    MaxY = element.MaxY,
                    OriginalY = element.OriginalY,
                    X = element.X
                };
                if (isFirstItem)
                {
                    isFirstItem = false;
                    previousItem = element.OriginalY;
                }
                else previousItem = alpha * element.OriginalY + (1 - alpha) * previousItem;
                item.ExpSmoothedY = previousItem;
                yield return item;
            }
        }
    }
}