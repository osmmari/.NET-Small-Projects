using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public struct Pixel
    {
        public double Check(double value)
        {
            if (value < 0 || value > 1) throw new ArgumentException();
            return value;
        }

        public double r;
        public double g;
        public double b;

        public Pixel(double r, double g, double b)
        {
            this.r = this.g = this.b = 0;
            this.R = r;
            this.G = g;
            this.B = b;
        }

        public double R
        {
            get { return r; }
            set { r = Check(value); }
        }

        public double G
        {
            get { return g; }
            set { g = Check(value); }
        }

        public double B
        {
            get { return b; }
            set { b = Check(value); }
        }

        public static double Trim(double value)
        {
            if (value < 0) return 0;
            if (value > 1) return 1;
            return value;
        }

        public static Pixel operator *(Pixel pixel, double parameter)
        {
            return new Pixel(
                        Pixel.Trim(pixel.R * parameter),
                        Pixel.Trim(pixel.G * parameter),
                        Pixel.Trim(pixel.B * parameter)
                );
        }

        public static Pixel operator *(double parameter, Pixel pixel)
        {
            return new Pixel(
                        Pixel.Trim(pixel.R * parameter),
                        Pixel.Trim(pixel.G * parameter),
                        Pixel.Trim(pixel.B * parameter)
                );
        }
    }
}
