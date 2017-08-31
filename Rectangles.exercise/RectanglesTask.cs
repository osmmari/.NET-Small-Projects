using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
            //if (r1.Height == 0 || r1.Width == 0 || r2.Height == 0 || r2.Width == 0) return false;
            //bool result = false;
            // так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
            // check if r2 cross vertical
            if ( (r2.Left >= r1.Left && r2.Left <= r1.Right) &&
                ((r2.Top <= r1.Top && (r2.Top+r2.Height) >= r1.Top) ||
                 (r2.Top <= (r1.Top+r1.Height) && r2.Bottom >= r1.Bottom))) return true;
            // check if r1 cross vertical
            if ((r1.Left >= r2.Left && r1.Left <= r2.Right) &&
                ((r1.Top <= r2.Top && r1.Bottom >= r2.Top) ||
                 (r1.Top <= r2.Bottom && r1.Bottom >= r2.Bottom))) return true;
            // check if r2 cross horizontal
            if ((r2.Top >= r1.Top && r2.Top <= r1.Bottom) &&
                 ((r2.Left <= r1.Left && r2.Right >= r1.Left) ||
                 (r1.Right >= r2.Left && r1.Right <= r2.Right))) return true;
            // check if r1 cross horizontal
            if ((r1.Top >= r2.Top && r1.Top <= r2.Bottom) &&
                ((r1.Left <= r2.Left && r1.Right >= r2.Left) ||
                (r2.Right >= r1.Left && r2.Right <= r1.Right))) return true;
            if (IndexOfInnerRectangle(r1, r2) != -1) return true;
            return false;
		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
            if (r1.Height == 0 || r1.Width == 0 || r2.Height == 0 || r2.Width == 0) return 0;
            if (IndexOfInnerRectangle(r1, r2) == 0) return r1.Width * r1.Height;
            if (IndexOfInnerRectangle(r1, r2) == 1) return r2.Width * r2.Height;
            //int result = 0;
            // vertice of r1 inside in r2
            if ((r1.Left >= r2.Left && r1.Left <= r2.Right) && 
                (r1.Top >= r2.Top && r1.Top <= r2.Bottom) && 
                (r1.Right >= r2.Right) && (r1.Bottom > r2.Bottom))
                return (r2.Right - r1.Left) * (r2.Bottom - r1.Top);
            // vertice of r2 inside in r1
            if ((r2.Left >= r1.Left && r2.Left <= r1.Right) &&
                (r2.Top >= r1.Top && r2.Top <= r1.Bottom) &&
                (r2.Right >= r1.Right) && (r2.Bottom > r1.Bottom))
                return (r1.Right - r2.Left) * (r1.Bottom - r2.Top);
            // another vertice of r1 inside in r2
            if ((r1.Right >= r2.Left && r1.Right <= r2.Right) &&
                (r1.Top >= r2.Top && r1.Top <= r2.Bottom) &&
                r1.Left < r2.Left && r1.Bottom > r2.Bottom)
                return (r1.Right - r2.Left) * (r2.Bottom - r1.Top);
            // another vertice of r2 inside in r1
            if ((r2.Right >= r1.Left && r2.Right <= r1.Right) &&
                (r2.Top >= r1.Top && r2.Top <= r1.Bottom) &&
                r2.Left < r1.Left && r2.Bottom > r1.Bottom)
                return (r2.Right - r1.Left) * (r1.Bottom - r2.Top);
            // if 2 vertices of r1 inside in r2
            if ((r1.Left >= r2.Left && r1.Right <= r2.Right) &&
                (r1.Top >= r2.Top && r1.Top <= r2.Bottom))
                return r1.Width * (r2.Bottom - r1.Top);
            // if 2 vertices of r2 inside in r1
            if ((r2.Left >= r1.Left && r2.Right <= r1.Right) &&
                (r2.Top >= r1.Top && r2.Top <= r1.Bottom))
                return r2.Width * (r1.Bottom - r2.Top);
            // if another 2 vertice of r1 inside in r2
            if ((r1.Left >= r2.Left && r1.Right <= r2.Right) &&
                (r1.Bottom >= r2.Top && r1.Bottom <= r2.Bottom))
                return r1.Width * (r1.Bottom - r2.Top);
            // if another 2 vertices of r2 insinde in r1
            if ((r2.Left >= r1.Left && r2.Right <= r1.Right) &&
                (r2.Bottom >= r1.Top && r2.Bottom <= r1.Bottom))
                return r2.Width * (r2.Bottom - r1.Top);
            //////
            if (r1.Left > r2.Left && r1.Left < r2.Right && r1.Top > r2.Top && r1.Bottom < r2.Bottom &&
                r1.Right > r2.Right)
                return (r2.Right - r1.Left) * r1.Height;
            if (r2.Left > r1.Left && r2.Left < r1.Right && r2.Top > r1.Top && r2.Bottom < r1.Bottom &&
                r2.Right > r1.Right)
                return (r1.Right - r2.Left) * r2.Height;
            if (r1.Right > r2.Left && r1.Right < r2.Right && r1.Top > r2.Top && r1.Bottom < r2.Bottom &&
                r1.Left < r2.Left)
                return (r1.Right - r2.Left) * r1.Height;
            if (r2.Right > r1.Left && r2.Right < r1.Right && r2.Top > r1.Top && r2.Bottom < r1.Bottom &&
                r2.Left < r1.Left)
                return (r2.Right - r1.Left) * r2.Height;
            // if r1 cross r2
           if ((r1.Top < r2.Top && r1.Bottom > r2.Bottom &&
                r1.Left > r2.Left && r1.Right < r2.Right) ||
                (r2.Top < r1.Top && r2.Bottom > r1.Bottom &&
                r2.Left > r1.Left && r2.Right < r1.Right))
                return Math.Min(r1.Width, r1.Height) * Math.Min(r2.Width, r2.Height);
            if (AreIntersected(r1, r2) && 
                ((r1.Top == r2.Top || r1.Bottom == r2.Bottom) || (r1.Left == r2.Left || r1.Right == r2.Right)))
                return (Math.Min(r1.Right, r2.Right) - Math.Max(r1.Left, r2.Left)) * (Math.Min(r1.Bottom, r2.Bottom) - Math.Max(r1.Top, r2.Top));

            return 0; //result;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
            // int result = -1;

            if (r1.Left >= r2.Left && r1.Right <= r2.Right &&
                r1.Top >= r2.Top && r1.Bottom <= r2.Bottom)
                return 0;

            if (r2.Left >= r1.Left && r2.Right <= r1.Right &&
                r2.Top >= r1.Top && r2.Bottom <= r1.Bottom)
                return 1;

            return -1; //result;
		}
	}
}