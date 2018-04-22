using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
	public class DungeonTask
	{
        public static MoveDirection[] FindShortestPath(Map map)
		{
            var path = new MoveDirection[0];
            var pathToChest = BfsTask.FindPaths(map, map.InitialPosition, map.Chests).FirstOrDefault();
            var exit = new Point[] { map.Exit };
            var pathToExit = BfsTask.FindPaths(map, pathToChest.Value, exit).FirstOrDefault();

            if (pathToChest != null && pathToExit != null)
            {
                //path = (ExtractToPath(pathToChest).Concat(ExtractToPath(pathToExit))).ToArray();
                var path1 = ExtractToPath(pathToChest).ToArray();
                var path2 = ExtractToPath(pathToExit).ToArray();

                path = path1.Concat(path2).ToArray();
            }

			return path;
		}

        private static IEnumerable<MoveDirection> ExtractToPath(SinglyLinkedList<Point> source)
        {
            if (source.Previous != null)
            {
                ExtractToPath(source.Previous);
                yield return ConvertToMove(source);
            }
        }

        private static MoveDirection ConvertToMove(SinglyLinkedList<Point> moving)
        {
            if (moving.Value.X - moving.Previous.Value.X == 1) return MoveDirection.Right;
            if (moving.Value.X - moving.Previous.Value.X == -1) return MoveDirection.Left;
            if (moving.Value.Y - moving.Previous.Value.Y == 1) return MoveDirection.Down;
            if (moving.Value.Y - moving.Previous.Value.Y == -1) return MoveDirection.Up;

            throw new Exception("No way");
        }
	}
}
