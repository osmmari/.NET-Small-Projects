using System.Collections.Generic;
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
                    int height = 3;

                    if (original.GetLength(0) < 2) width = 1;
                    else if (x == original.GetLength(0) - 1) width = -2;
                    else if (x == 0) width = 2;

                    if (original.GetLength(1) < 2) height = 1;
                    else if (y == original.GetLength(1) - 1) height = -2;
                    else if (y == 0) height = 2;

                    resultImage[x, y] = Median(original, x, y, width, height);
                }

            return resultImage;
        }

        public static double Median(double[,] original, int x, int y, int windowWidth, int windowHeight)
        {
            double result;
            var listMed = new List<double> { original[x, y] };

            if (windowWidth == 3) { listMed.Add(original[x - 1, y]); listMed.Add(original[x + 1, y]); }
            else if (windowWidth == 2) { listMed.Add(original[x + 1, y]); }
            else if (windowWidth == -2) { listMed.Add(original[x - 1, y]); }

            if (windowHeight == 3) { listMed.Add(original[x, y - 1]); listMed.Add(original[x, y + 1]); }
            else if (windowHeight == 2) { listMed.Add(original[x, y + 1]); }
            else if (windowHeight == -2) { listMed.Add(original[x, y - 1]); }

            if (windowHeight == 2 && windowWidth == 2) { listMed.Add(original[x + 1, y + 1]); }
            else if (windowHeight == -2 && windowWidth == -2) { listMed.Add(original[x - 1, y - 1]); }
            else if (windowWidth == 3 && windowHeight == 3)
            {
                listMed.Add(original[x - 1, y - 1]); listMed.Add(original[x + 1, y - 1]);
                listMed.Add(original[x - 1, y + 1]); listMed.Add(original[x + 1, y + 1]);
            }
            else if (windowWidth == 2 && windowHeight == 3) { listMed.Add(original[x + 1, y - 1]); listMed.Add(original[x + 1, y + 1]); }
            else if (windowWidth == 3 && windowHeight == 2) { listMed.Add(original[x - 1, y + 1]); listMed.Add(original[x + 1, y + 1]); }
            else if (windowWidth == 3 && windowHeight == -2) { listMed.Add(original[x - 1, y - 1]); listMed.Add(original[x + 1, y - 1]); }
            else if (windowWidth == -2 && windowHeight == 3) { listMed.Add(original[x - 1, y - 1]); listMed.Add(original[x - 1, y + 1]); }
            else if (windowWidth == -2 && windowHeight == 2) { listMed.Add(original[x - 1, y + 1]); }
            else if (windowWidth == 2 && windowHeight == -2) { listMed.Add(original[x + 1, y - 1]); }

            listMed.Sort();

            if (listMed.Count % 2 == 1) { result = listMed[listMed.Count / 2]; }
            else { result = (listMed[(listMed.Count / 2) - 1] + listMed[listMed.Count / 2]) / 2; }

            return result;
        }
    }
}