using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Reports
{
	public abstract class ReportMaker
	{

		protected abstract string MakeCaption(string caption);
		protected abstract string BeginList();
		protected abstract string MakeItem(string valueType, string entry);
		protected abstract string EndList();
		public string MakeReport(IEnumerable<Measurement> measurements, string caption, Func<IEnumerable<double>, object> makeStatistics)
		{
			var data = measurements.ToList();
			var result = new StringBuilder();
			result.Append(MakeCaption(caption));
			result.Append(BeginList());
			result.Append(MakeItem("Temperature", makeStatistics(data.Select(z => z.Temperature)).ToString()));
			result.Append(MakeItem("Humidity", makeStatistics(data.Select(z => z.Humidity)).ToString()));
			result.Append(EndList());
			return result.ToString();
		}
	}

	public class HtmlReportMaker : ReportMaker
	{
		protected override string MakeCaption(string caption)
		{
			//return $"<h1>{caption}</h1>";
			return String.Format("<h1>{0}</h1>", caption);
		}

		protected override string BeginList()
		{
			return "<ul>";
		}

		protected override string EndList()
		{
			return "</ul>";
		}

		protected override string MakeItem(string valueType, string entry)
		{
			//return $"<li><b>{valueType}</b>: {entry}";
			return String.Format("<li><b>{0}</b>: {1}", valueType, entry);
		}
	}

	public class MarkdownReportMaker : ReportMaker
	{
		protected override string BeginList()
		{
			return "";
		}

		protected override string EndList()
		{
			return "";
		}

		protected override string MakeCaption(string caption)
		{
			//return $"## {caption}\n\n";
			return String.Format("## {0}\n\n", caption);
		}

		protected override string MakeItem(string valueType, string entry)
		{
			//return $" * **{valueType}**: {entry}\n\n";
			return String.Format(" * **{0}**: {1}\n\n", valueType, entry);
		}
	}


	public static class ReportMakerHelper
	{
		public static object MeanAndStd(IEnumerable<double> _data)
		{
			var data = _data.ToList ();
			var mean = data.Average ();
			var std = Math.Sqrt(data.Select(z => Math.Pow(z - mean, 2)).Sum() / (data.Count - 1));
			return new MeanAndStd {
				Mean = mean,
				Std = std
			};
		}

		public static object Median(IEnumerable<double> data)
		{
			var list = data.OrderBy(z => z).ToList();
			if (list.Count % 2 == 0)
				return (list[list.Count / 2] + list[list.Count / 2 - 1]) / 2;
			else
				return list[list.Count / 2];
		}

		public static string MeanAndStdHtmlReport(IEnumerable<Measurement> data)
		{
			return new HtmlReportMaker().MakeReport(data, "Mean and Std", MeanAndStd);
		}

		public static string MedianMarkdownReport(IEnumerable<Measurement> data)
		{
			return new MarkdownReportMaker().MakeReport(data, "Median", Median);
		}

		public static string MeanAndStdMarkdownReport(IEnumerable<Measurement> measurements)
		{
			// !!!!!!
			return new MarkdownReportMaker().MakeReport(measurements, "Mean and Std", MeanAndStd);
		}

		public static string MedianHtmlReport(IEnumerable<Measurement> measurements)
		{
			// !!!!!!
			return new HtmlReportMaker().MakeReport(measurements, "Median", Median);
		}
	}
}
