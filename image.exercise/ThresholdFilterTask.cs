using System;
using System.Collections.Generic;

namespace Recognizer
{
    public static class ThresholdFilterTask
    {
        /* 
		 * Замените пиксели ярче порогового значения T на белый (1.0),
		 * а остальные на черный (0.0).
		 * Пороговое значение найдите так, чтобы:
		 *  - если N — общее количество пикселей изображения, 
		 *    то хотя бы (int)(threshold*N)  пикселей стали белыми;
		 *  - белыми стало как можно меньше пикселей.
		*/

        public static double[,] ThresholdFilter(double[,] original, double threshold)
        {
            var resultImage = new double[original.GetLength(0), original.GetLength(1)];

            int numberOfPixels = (int)(original.GetLength(0) * original.GetLength(1) * threshold);
            var allElements = new List<double>();
            foreach (var element in original)
            {
                allElements.Add(element);
            }
            allElements.Sort();
            allElements.Reverse();
            double T = allElements[numberOfPixels];

            for (int x = 0; x < original.GetLength(0); x++)
                for (int y = 0; y < original.GetLength(1); y++)
                    resultImage[x, y] = original[x, y] >= T ? 1.0 : 0.0;

            return resultImage;
        }
    }
}