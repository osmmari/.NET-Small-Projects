using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {
        /* 
		Разберитесь, как работает нижеследующий код (называемый фильтрацией Собеля), 
		и какое отношение к нему имеют эти матрицы:
		
		     | -1 -2 -1 |           | -1  0  1 |
		Sx = |  0  0  0 |      Sy = | -2  0  2 |
		     |  1  2  1 |           | -1  0  1 |
		
		https://ru.wikipedia.org/wiki/%D0%9E%D0%BF%D0%B5%D1%80%D0%B0%D1%82%D0%BE%D1%80_%D0%A1%D0%BE%D0%B1%D0%B5%D0%BB%D1%8F
		
		Попробуйте заменить фильтр Собеля 3x3 на фильтр Собеля 5x5 и сравните результаты. 
		http://www.cim.mcgill.ca/~image529/TA529/Image529_99/assignments/edge_detection/references/sobel.htm

		Обобщите код применения фильтра так, чтобы можно было передавать ему любые матрицы, любого нечетного размера.
		Фильтры Собеля размеров 3 и 5 должны быть частным случаем. 
		После такого обобщения менять фильтр Собеля одного размера на другой будет легко.
		*/

        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            var result = new double[width, height];
            for (int x = 1; x < width - 1; x++)
                for (int y = 1; y < height - 1; y++)
                {
                    // Вместо этого кода должно быть умножение матриц sx и полученной из неё sy на окрестность точки (x, y)
                    var gx = -g[x - 1, y - 1] - 2 * g[x, y - 1] - g[x + 1, y - 1] + g[x - 1, y + 1] + 2 * g[x, y + 1] + g[x + 1, y + 1];
                    var gy = -g[x - 1, y - 1] - 2 * g[x - 1, y] - g[x - 1, y + 1] + g[x + 1, y - 1] + 2 * g[x + 1, y] + g[x + 1, y + 1];
                    result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            return result;
        }
    }
}