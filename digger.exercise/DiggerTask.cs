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
                dX = 0;
                dY = 0;
            } 
            if (Game.Map[x + dX, y + dY] != null)
            {
                if (Game.Map[x + dX, y + dY].ToString() == "Digger.Sack")
                { dX = 0; dY = 0; }
            }
            return new CreatureCommand() { DeltaX = dX, DeltaY = dY };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject.ToString() == "Digger.Gold") Game.Scores += 10;
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

    class Sack : ICreature
    {
        private static int counter = 0;

        public virtual CreatureCommand Act(int x, int y)
        {
            if (y < Game.MapHeight - 1)
            {
                var map = Game.Map[x, y + 1];
                if (map == null)
                {
                    counter++;
                    return new CreatureCommand() { DeltaX = 0, DeltaY = 1 };
                }
            }
            if (counter > 1)
                Game.Map[x, y] = new Digger.Gold();
                //this = new Gold();
            counter = 0;
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };
        }

        public virtual bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public virtual int GetDrawingPriority()
        {
            return 3;
        }

        public virtual string GetImageFileName()
        {
            return "Sack.png";
        }
    }

    class Gold : Sack, ICreature 
    {
        public override CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };
        }

        public override bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject.ToString() == "Digger.Player") return true;
            return false;
        }

        public override int GetDrawingPriority()
        {
            return 3;
        }

        public override string GetImageFileName()
        {
            return "Gold.png";
        }
    }
}
