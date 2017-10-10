using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }

        public int GetDrawingPriority()
        {
            return 5;
        }

        public string GetImageFileName()
        {
            return "Terrain.png";
        }
    }

    class Player : ICreature
    {
        private int x;
        private int y;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        int dX, dY = 0;

        public CreatureCommand Act(int x, int y)
        {
            //Console.WriteLine("x = {0}, y = {1} \n", x, y);
            switch(Game.KeyPressed)
            {
                case System.Windows.Forms.Keys.Left:
                    dX = -1;
                    break;
                case System.Windows.Forms.Keys.Up:
                    dY = -1;
                    break;
                case System.Windows.Forms.Keys.Right:
                    dX = 1;
                    break;
                case System.Windows.Forms.Keys.Down:
                    dY = 1;
                    break;
                default:
                    dX = 0;
                    dY = 0;
                    break;
            }
            if (!(x + dX >= 0 && x + dX < Game.MapWidth &&
                y + dY >= 0 && y + dY < Game.MapHeight))
            {
                /*Console.WriteLine("x = {0}, y = {1}", x, y);
                Console.WriteLine(x + dX > 0);
                Console.WriteLine(x + dX < Game.MapWidth);
                Console.WriteLine(y + dY > 0);
                Console.WriteLine(y + dY < Game.MapHeight);
                Console.WriteLine("dx = {0} dy = {1}", dX, dY);
                Console.WriteLine("Width = {0}, Height = {1}", Game.MapWidth, Game.MapHeight);*/
                dX = 0;
                dY = 0;
            }
            //var map = Game.Map[x + dX, y + dY].GetImageFileName();
            //Console.WriteLine("{0} \n", map);
            return new CreatureCommand() { DeltaX = dX, DeltaY = dY };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public int GetDrawingPriority()
        {
            return 3;
        }

        public string GetImageFileName()
        {
            return "Digger.png";
        }
    }
}
