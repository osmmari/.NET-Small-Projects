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
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public string GetImageFileName()
        {
            return "Terrain";
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
                    break;
            }
            return new CreatureCommand() { DeltaX = dX, DeltaY = dY };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public string GetImageFileName()
        {
            return "Player";
        }
    }
}
