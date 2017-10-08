using System;
using System.Windows.Forms;

namespace Digger
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Game.CreateMap();
			Application.Run(new DiggerWindow());
		}
	}
}