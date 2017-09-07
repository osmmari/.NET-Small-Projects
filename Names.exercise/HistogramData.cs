using System.Linq;

namespace Names
{
	public class HistogramData
	{
		public string Title { get; private set; }
		public string[] XLabels { get; private set; }
		public double[] YValues { get; private set; }

		public HistogramData(string title, string[] xLabels, double[] yValues)
		{
			Title = title;
			XLabels = xLabels;
			YValues = yValues;
		}

		public bool Equals(HistogramData other)
		{
			return other.XLabels.SequenceEqual(XLabels) && other.YValues.SequenceEqual(YValues);
		}
	}
}