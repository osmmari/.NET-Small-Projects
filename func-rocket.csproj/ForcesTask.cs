using System;
using System.Drawing;
using System.Linq;

namespace func_rocket
{
	public class ForcesTask
	{
		/// <summary>
		/// Создает делегат, возвращающий по ракете вектор силы тяги двигателей этой ракеты.
		/// Сила тяги направлена вдоль ракеты и равна по модулю forceValue.
		/// </summary>
		public static RocketForce GetThrustForce(double forceValue)
		{
            //return r => Vector.Zero;
            return rocket => new Vector(Math.Abs(forceValue), 0).Rotate(rocket.Direction);
		}

		/// <summary>
		/// Преобразует делегат силы гравитации, в делегат силы, действующей на ракету
		/// </summary>
		public static RocketForce ConvertGravityToForce(Gravity gravity, Size spaceSize)
		{
            //return r => Vector.Zero;
            return rocket => new Vector(gravity(spaceSize, rocket.Location).X, gravity(spaceSize, rocket.Location).Y);
        }

		/// <summary>
		/// Суммирует все переданные силы, действующие на ракету, и возвращает суммарную силу.
		/// </summary>
		public static RocketForce Sum(params RocketForce[] forces)
		{
            return rocket => forces.Select(force => force(rocket))
                    .DefaultIfEmpty(Vector.Zero)
                    .Aggregate((v1, v2) => v1 + v2);
        }
	}
}