using System;
using System.Drawing;

namespace Recognizer
{
	public class Pixel
	{
		public byte R { get; private set; }
		public byte G { get; private set; }
		public byte B { get; private set; }
	
		public Pixel(byte r, byte g, byte b)
		{
			R = r;
			G = g;
			B = b;
		}

		public Pixel(Color color)
		{
			R = color.R;
			G = color.G;
			B = color.B;
		}

		public override string ToString()
		{
			return String.Format("Pixel({0}, {1}, {2})", R, G, B);
		}
	}
}