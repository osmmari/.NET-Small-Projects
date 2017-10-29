using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace Profiling
{
    class ChartBuilder : IChartBuilder
    {
        public Control Build(List<ExperimentResult> result)
        {
            GraphPane pane = ZedGraphControl.grap
            
            pane.CurveList.Clear();

            PointPairList time1 = new PointPairList();
            PointPairList time2 = new PointPairList();
            foreach (var experiment in result)
            {
                time1.Add(experiment.Size, experiment.StructResult);
                time2.Add(experiment.Size, experiment.ClassResult);
            }

            LineItem curve1 = pane.AddCurve("Struct Time", time1);
        }
    }
}