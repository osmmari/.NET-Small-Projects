using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class BfsTask
    {
        private static Queue<SinglyLinkedList<Point>> queue;
        private static HashSet<Point> visited;
        private static Tuple<int, int>[] directions;

        public static IEnumerable<SinglyLinkedList<Point>> FindPaths(Map map, Point start, Point[] chests)
        {
            queue = new Queue<SinglyLinkedList<Point>>();
            visited = new HashSet<Point> { start };
            queue.Enqueue(new SinglyLinkedList<Point>(start, null));
            directions = new[] { Tuple.Create(-1, 0), Tuple.Create(1, 0), Tuple.Create(0, -1), Tuple.Create(0, 1) };
            var width = map.Dungeon.GetLength(0);
            var height = map.Dungeon.GetLength(1);
        
            while (queue.Count != 0)
            {
                var point = queue.Dequeue();
                if (point.Value.X < 0 || point.Value.Y < 0 ||
                    point.Value.X >= width || point.Value.Y >= height) continue;
                if (map.Dungeon[point.Value.X, point.Value.Y] == MapCell.Wall) continue;

                if (chests.Contains(point.Value)) yield return point;

                foreach (var dir in directions)
                            AddToQueue(new Point(point.Value.X + dir.Item1, point.Value.Y + dir.Item2), point);
            }

            yield break;
        }
        
        private static void AddToQueue(Point point, SinglyLinkedList<Point> prevPoint)
        {
            if (!visited.Contains(point))
            {
                queue.Enqueue(new SinglyLinkedList<Point>(point, prevPoint));
                visited.Add(point);
            }
        }
    }
}