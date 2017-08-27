using System;
using System.Drawing;

namespace MyPhotoshop
{
	public static class Convertors
	{
		public static Photo Bitmap2Photo(Bitmap bmp)
		{
			var photo=new Photo();
			photo.width=bmp.Width;
			photo.height=bmp.Height;
			photo.data=new Pixel[bmp.Width,bmp.Height];
			for (int x=0;x<bmp.Width;x++)
				for (int y=0;y<bmp.Height;y++)
				{
				var pixel=bmp.GetPixel (x,y);
                photo.data[x,y] = new Pixel();
                photo.data[x,y].R=(double)pixel.R/255;
				photo.data[x,y].G=(double)pixel.G/255;
				photo.data[x,y].B=(double)pixel.B/255;
				}
			return photo;
		}
		
		static int ToChannel(double val)
		{
            if (val<0 || val>1)
                throw new Exception(string.Format("Wrong channel value {0} (the value must be between 0 and 1", val));
			return (int)(val * 255);
		}
		
		public static Bitmap Photo2Bitmap(Photo photo)
		{
			var bmp=new Bitmap(photo.width,photo.height);
			for (int x=0;x<bmp.Width;x++)
				for (int y=0;y<bmp.Height;y++)
					bmp.SetPixel(x,y,Color.FromArgb (
						ToChannel (photo.data[x,y].R),
						ToChannel (photo.data[x,y].G),
						ToChannel (photo.data[x,y].B) ));
					       		
			return bmp;
		}
	}
}

