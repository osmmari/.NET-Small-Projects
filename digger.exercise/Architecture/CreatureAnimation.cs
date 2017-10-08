using System.Drawing;

namespace Digger
{
	public class CreatureAnimation
	{
		public ICreature Creature;
		public CreatureCommand Command;
		public Point Location;
		public Point TargetLogicalLocation;
	}
}