using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Weights
{
    public class Indexer
    {
        private int mod;
        private int length;

        private double[] Array { get; set; }

        public int Length
        {
            get { return length; }
            set
            {
                if (value >= 0 && value <= Array.Length) length = value;
                else
                    throw new ArgumentException();
            }
        }

        public int Mod
        {
            get { return mod; }
            set
            {
                if (value >= 0) mod = value;
                else
                    throw new ArgumentException();
            }
        }

        public Indexer(double[] array, int mod, int length)
        {
            Array = array;
            Mod = mod;
            Length = length;
        }

        public double this[int index]
        {
            get
            {
                if (index >= 0 && index <= Length) return Array[index + Mod];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index <= Length) Array[index + Mod] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
