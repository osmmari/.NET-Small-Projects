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

            int bias = sx.GetLength(0) / 2;
            var sy = Transpose (sx);

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {                    
					var gx = MultiplyMatrixes (g, sx, x, y, bias);
					var gy = MultiplyMatrixes (g, sy, x, y, bias);
                    
					result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            return result;
        }

        private static double MultiplyMatrixes(double[,] image, double[,] filter, int pixelX, int pixelY, int bias)
        {
            double result = 0;
            var width = image.GetLength(0);
            var height = image.GetLength(1);
            for (var x = -bias; x <= bias; x++)
                for (var y = -bias; y <= bias; y++)
                {
                    var indexX = pixelX + x;
                    var indexY = pixelY + y;
                    if (indexX >= 0 && indexX < width && indexY >= 0 && indexY < height)
                        result += image[pixelX + x, pixelY + y] * filter[bias + x, bias + y];
                    else return 0;
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