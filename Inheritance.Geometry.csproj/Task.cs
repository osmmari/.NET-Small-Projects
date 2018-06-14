using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Geometry
{
    public interface IVisitor
    {
        void Visit(Ball body);
        void Visit(Cube body);
        void Visit(Cyllinder body);
    }

    public abstract class Body
	{
        public abstract double GetVolume();
        public abstract void Accept(IVisitor visitor);
	}

	public class Ball : Body
	{
        public double Radius { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override double GetVolume()
        {
            return 4.0 * Math.PI * Math.Pow(Radius, 3) / 3;
        }
    }

	public class Cube : Body
	{
        public double Size { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override double GetVolume()
        {
            return Math.Pow(Size, 3);
        }
    }

	public class Cyllinder : Body
	{
        public double Radius { get; set; }
        public double Height { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override double GetVolume()
        {
            return Math.PI * Math.Pow(Radius, 2) * Height;
        }
    }

	// Заготовка класса для задачи на Visitor
	public class SurfaceAreaVisitor : IVisitor
	{
		public double SurfaceArea { get; private set; }

        public void Visit(Ball body)
        {
            SurfaceArea = 4 * Math.PI * body.Radius * body.Radius;
        }

        public void Visit(Cube body)
        {
            SurfaceArea = 6 * body.Size * body.Size;
        }

        public void Visit(Cyllinder body)
        {
            SurfaceArea = 2 * Math.PI * body.Radius * (body.Height + body.Radius);
        }
    }

	public class DimensionsVisitor : IVisitor
	{
		public Dimensions Dimensions { get; private set; }

        public void Visit(Ball body)
        {
            Dimensions = new Dimensions(body.Radius * 2, body.Radius * 2);
        }

        public void Visit(Cube body)
        {
            Dimensions = new Dimensions(body.Size, body.Size);
        }

        public void Visit(Cyllinder body)
        {
            Dimensions = new Dimensions(body.Radius * 2, body.Height);
        }
    }
}
