using System;
using System.Collections.Generic;

namespace func_rocket
{
	public class LevelsTask
	{
		static readonly Physics standardPhysics = new Physics();
        private static Rocket rocket = new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI);
        private static Vector target = new Vector(600, 200);
        private static Vector upTarget = new Vector(700, 500);

        private static Level CreateLevel(string name, Gravity gravity)
        {
            return new Level(name, rocket, target, gravity, standardPhysics);
        }

        public static IEnumerable<Level> CreateLevels()
		{
            yield return CreateLevel("Zero", (size, v) => Vector.Zero);

            yield return CreateLevel("Heavy", (size, v) => new Vector(0.0, 0.9));

            yield return new Level("Up", rocket, upTarget, (size, v) => new Vector(0.0, -300 / (size.Height - v.Y + 300.0)), standardPhysics);

            yield return CreateLevel("WhiteHole",
                (size, v) => WhiteHole(v));

            yield return CreateLevel("BlackHole",
                (size, v) => BlackeHole(v));

            yield return CreateLevel("BlackAndWhite",
                (size, v) => (WhiteHole(v) + BlackeHole(v)) / 2);
        }

        private static Vector WhiteHole(Vector v)
        {
            return (target - v).Normalize() * 140 * GravityVector(v, target);
        }

        private static Vector BlackeHole(Vector v)
        {
            return ((target - v) / 2).Normalize() * 300 * GravityVector(v, (target - v) / 2);
        }

        private static double GravityVector(Vector v, Vector target)
        {
            return Math.Sqrt(Math.Pow(target.X - v.X, 2.0) + Math.Pow(target.Y - v.Y, 2.0)) /
                (Math.Abs((Math.Pow(target.X - v.X, 2.0) + Math.Pow(target.Y - v.Y, 2.0))) + 1);
        }
	}
}