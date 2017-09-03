using System;
namespace Mazes
{
	public static class DiagonalMazeTask
	{
        public static int down;
        public static int right;

		public static void MoveOut(Robot robot, int width, int height)
		{
            StartingValues(width, height);
            for (int i = 1, j = 1; i < (height - 1) && j < (width - 1); i = HeightInc(i), j = WidthInc(j))
            {
                if (down >= right) MovingDown(robot);
                else MovingRight(robot);
                if (i < height - 2 && j < width - 2)
                {
                    if (down >= right) MovingRight(robot);
                    else MovingDown(robot);
                }
            }
		}

        public static void StartingValues(int width, int height)
        {
            down = right = 1;
            if (height / width > 0) down = Convert.ToInt32(Math.Round((double)height / (double)width));
            else if (width / height > 0) right = Convert.ToInt32(Math.Round((double)width / (double)height));
        }

        public static void MovingRight(Robot robot)
        {
            for (int i = 0; i < right; i++) robot.MoveTo(Direction.Right);
        }

        public static void MovingDown(Robot robot)
        {
            for (int i = 0; i < down; i++) robot.MoveTo(Direction.Down);
        }

        public static int HeightInc(int i)
        {
            return i + down;
        }

        public static int WidthInc(int j)
        {
            return j + right;
        }
    }
}