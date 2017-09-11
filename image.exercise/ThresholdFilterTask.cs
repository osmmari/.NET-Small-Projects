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
			return new double[original.GetLength(0), original.GetLength(1)];
		}
	}
}