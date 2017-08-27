using System;

namespace MyPhotoshop
{
	public class Photo
	{
		public readonly int width;
		public readonly int height;
		private readonly Pixel[,] data;

        public Photo(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.data = new Pixel[width, height];
        }

        public Pixel this[int x, int y]
        {
            get { return data[x,y]; }
            set { data[x, y] = value; }
        } 
	}
}

