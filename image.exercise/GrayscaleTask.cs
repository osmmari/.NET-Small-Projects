namespace Recognizer
{
	public static class GrayscaleTask
	{
        /* 
		 * Переведите изображение в серую гамму.
		 * 
		 * original[x, y] - массив пикселей с координатами x, y. 
		 * Каждый канал R,G,B лежит в диапазоне от 0 до 255.
		 * 
		 * Получившийся массив должен иметь те же размеры, 
		 * grayscale[x, y] - яркость пикселя (x,y) в диапазоне от 0.0 до 1.0
		 *
		 * Используйте формулу:
		 * Яркость = (0.299*R + 0.587*G + 0.114*B) / 255
		 * 
		 * Почему формула именно такая — читайте в википедии 
		 * http://ru.wikipedia.org/wiki/Оттенки_серого
		 */

        public static double[,] ToGrayscale(Pixel[,] original)
        {
            var grayscale = new double[original.GetLength(0), original.GetLength(1)];
            for (int x = 0; x < grayscale.GetLength(0); x++)
                for (int y = 0; y < grayscale.GetLength(1); y++)
                    grayscale[x, y] = (0.299 * original[x, y].R + 0.587 * original[x, y].G + 0.114 * original[x, y].B) / 255.0;
            return grayscale;
        }
    }
}