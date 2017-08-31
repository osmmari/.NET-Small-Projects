using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
            bool result = false;
            // так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
            // check if r2 cross vertical
            if ( (r2.Left >= r1.Left && r2.Left <= (r1.Left + r1.Width)) &&
                ((r2.Top <= r1.Top && (r2.Top+r2.Height) >= r1.Top) ||
                 (r2.Top <= (r1.Top+r1.Height) && (r2.Top + r2.Height) >= (r1.Top + r1.Height)))) result = true;
            // check if r1 cross vertical
            if ((r1.Left >= r2.Left && r1.Left <= (r2.Left + r2.Width)) &&
                ((r1.Top <= r2.Top && (r1.Top + r1.Height) >= r2.Top) ||
                 (r1.Top <= (r2.Top + r2.Height) && (r1.Top + r1.Height) >= (r2.Top + r2.Height)))) result = true;
            // check if r2 cross horizontal
            if ((r2.Top >= r1.Top && r2.Top <= (r1.Top + r1.Height)) &&
                 ((r2.Left <= r1.Left && (r2.Left + r2.Width) >= r1.Left) ||
                 ((r1.Left + r1.Right) >= r2.Left && (r1.Left + r1.Right) <= (r2.Left + r2.Width)))) result = true;
            // check if r1 cross horizontal
            if ((r1.Top >= r2.Top && r1.Top <= (r2.Top + r2.Height)) &&
                ((r1.Left <= r2.Left && (r1.Left + r1.Width) >= r2.Left) ||
                ((r2.Left + r2.Right) >= r1.Left && (r2.Left + r2.Right) <= (r1.Left + r1.Width)))) result = true;
            return result;
		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			return 0;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			return -1;
		}
	}
}