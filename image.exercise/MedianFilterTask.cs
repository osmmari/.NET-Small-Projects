using System.Linq;

namespace Recognizer
{
    internal static class MedianFilterTask
    {
        /* 
		 * Для борьбы с пиксельным шумом, подобным тому, что на изображении,
		 * обычно применяют медианный фильтр, в котором цвет каждого пикселя, 
		 * заменяется на медиану всех цветов в некоторой окрестности пикселя.
		 * https://en.wikipedia.org/wiki/Median_filter
		 * 
		 * Используйте окно размером 3х3 для не граничных пикселей,
		 * Окно размером 2х2 для угловых и 3х2 или 2х3 для граничных.
		 */
        public static double[,] MedianFilter(double[,] original)
        {
            var resultImage = new double[original.GetLength(0), original.GetLength(1)];
            for (int x = 0; x < original.GetLength(0); x++)
                for (int y = 0; y < original.GetLength(1); y++)
                {
                    int width = 3;
                    int heght = 3;

                    if (x == 0) width = 2;
                    else if (x == original.GetLength(0) - 1) width = -2;

                    if (y == 0) heght = 2;
                    else if (y == original.GetLength(1) - 1) heght = -2;

                    resultImage[x, y] = Median(original, x, y, width, heght);
                }

            return resultImage;
        }

        public static double Median(double[,] original, int x, int y, int windowWidth, int windowHeight)
        {
            double result = original[x, y];
            int count = 1;

            if (windowWidth == 3) { result += original[x - 1, y] + original[x + 1, y]; count += 2; }
            else if (windowWidth == 2) { result += original[x + 1, y]; count++; }
            else { result += original[x - 1, y]; count++; }

            if (windowHeight == 3) { result += original[x, y - 1] + original[x, y + 1]; count += 2; }
            else if (windowHeight == 2) { result += original[x, y + 1]; count++; }
            else { result += original[x, y - 1]; count++; }

            return result / count;
        }
    }
}