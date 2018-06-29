using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {
        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            var result = new double[width, height];
            
			var sy = Transpose (sx);

			for (int x = 1; x < width - 1; x++)
                for (int y = 1; y < height - 1; y++)
                {                    
					var gx = MultiplyMatrixes (g, sx, x, y);
					var gy = MultiplyMatrixes (g, sy, x, y);
                    
					result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            return result;
        }

        private static double MultiplyMatrixes(double[,] image, double[,] filter, int pixelX, int pixelY)
        {
            double result = 0;
            var length = filter.GetLength(0);
            for (var x = 0; x < length; x++)
                for (var y = 0; y < length; y++)
                {
                    result += image[pixelX - 1 + x, pixelY - 1 + y] * filter[x, y];
                }
            return result;
        }

        private static double[,] Transpose(double[,] sx)
		{
			var length = sx.GetLength (0);
			var sy = new double[length,length];
			for (var x = 0; x < length; x++)
				for (var y = 0; y < length; y++)
				{
					sy [x, y] = sx [y, x];
				}
			return sy;
		}
    }
}