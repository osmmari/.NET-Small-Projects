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
        private static List<Point> visited;

        public static IEnumerable<SinglyLinkedList<Point>> FindPaths(Map map, Point start, Point[] chests)
        {
            queue = new Queue<SinglyLinkedList<Point>>();
            visited = new List<Point> { start };
            queue.Enqueue(new SinglyLinkedList<Point>(start, null));
            var width = map.Dungeon.GetLength(0);
            var height = map.Dungeon.GetLength(1);
            //var path = new SinglyLinkedList<Point>(start, null);
            //SinglyLinkedList<Point> path = null;

            while (queue.Count != 0)
            {
                var point = queue.Dequeue();
                if (point.Value.X < 0 || point.Value.Y < 0 || point.Value.X >= width || point.Value.Y >= height) continue;
                if (map.Dungeon[point.Value.X, point.Value.Y] == MapCell.Wall) continue;

                if (chests.Contains(point.Value)) yield return point;

                for (var dx = -1; dx <= 1; dx++)
                    for (var dy = -1; dy <= 1; dy++)
                        if (Math.Abs(dx)!=Math.Abs(dy))
                            AddToQueue(new Point(point.Value.X + dx, point.Value.Y + dy), point);
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