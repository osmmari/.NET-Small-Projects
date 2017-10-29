using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;

namespace Profiling
{
    public interface IChartBuilder
    {
        Control Build(List<ExperimentResult> result);
    }
}
