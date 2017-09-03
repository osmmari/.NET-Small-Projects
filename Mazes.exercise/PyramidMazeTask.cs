namespace Mazes
{
	public static class PyramidMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            for (int i = 0; i < (height - 1) / 2; i++)
            {
                HorizontalMoving(robot, width, i);
                if (i * 2 < height - 3) MovingUp(robot);
            }
        }

        public static void HorizontalMoving(Robot robot, int width, int iteration)
        {
            int distance = width - (iteration * 2) ;

            for (int i = 1; i < distance - 2; i++)
            {
                if (iteration % 2 == 0) robot.MoveTo(Direction.Right);
                else robot.MoveTo(Direction.Left);
            }
        }

        public static void MovingUp(Robot robot)
        {
            for (int i = 0; i < 2; i++) robot.MoveTo(Direction.Up);
        }
    }
}