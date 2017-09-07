using System.Linq;

namespace Names
{
	public class HeatmapData
	{
		public string[] XLabels { get; private set; }
		public string[] YLabels { get; private set; }
		public string Title { get; private set; }
		public double[,] Heat { get; private set; }

		public HeatmapData(string title, double[,] heat, string[] xLabels, string[] yLabels)
		{
			XLabels = xLabels;
			YLabels = yLabels;
			Title = title;
			Heat = heat;
		}

		public bool Equals(HeatmapData other)
		{
			return Enumerable.Range(0, 2)
					   .All(dimension =>
						   Heat.GetLength(dimension) == other.Heat.GetLength(dimension))
				   && Heat
					   .Cast<double>()
					   .SequenceEqual(other.Heat
						   .Cast<double>());
		}
	}
}