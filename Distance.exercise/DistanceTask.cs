using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double angleA = CosPhi(x, y, ax, ay, bx, by);
            double angleB = CosPhi(x, y, bx, by, ax, ay);

            if (ax == bx && ay == y && ax == x && ay == y) return 0;
            if (ax == bx && ay == by && ax != x && ay != y) return Length(x, y, ax, ay);
            if (ax == bx && ax == x && ay != by)
                if ((y > ay && y < by) || (y < ay && y > by)) return 0;
                else return Math.Min(Diff(y, ay), Diff(y, by));
            if (ay == by && ay == y && ax != bx)
                if ((x > ax && x < bx) || (x < ax && x > bx)) return 0;
                else return Math.Min(Diff(x, ax), Diff(x, bx));

            if (angleA > 0 && angleB > 0)
            {
                double dist1 = Math.Abs((by - ay) * x - (bx - ax) * y + bx * ay - by * ax);
                double dist2 = Math.Sqrt(Math.Pow((by - ay), 2) + Math.Pow((bx - ax), 2));
                return dist1 / dist2;

            }
            return Math.Min(Length(x, y, ax, ay), Length(x, y, bx, by));
        }

        public static double Length(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        public static double Diff(double a, double b)
        {
            return Math.Abs(a - b);
        }

        public static double CosPhi(double x, double y, double ax, double ay, double bx, double by)
        {
            double dist1 = (x - ax) * (bx - ax) + (y - ay) * (by - ay);
            double dist2 = (Length(x, y, ax, ay) * Length(bx, by, ax, ay));
            return dist1 / dist2;
        }
    }
}