using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Profiling
{
	public class ProfilerTask : IProfiler
	{
        double time1, time2;
        List<ExperimentResult> result = new List<ExperimentResult>();
        Stopwatch watch = new Stopwatch();

		public List<ExperimentResult> Measure(IRunner runner, int repetitionsCount)
		{
            foreach (var size in Constants.FieldCounts)
            {
                runner.Call(false, size, 1);
                watch.Restart();
                runner.Call(false, size, repetitionsCount);
                watch.Stop();
                time1 = (double) watch.ElapsedMilliseconds / repetitionsCount;
                runner.Call(true, size, 1);
                watch.Restart();
                runner.Call(true, size, repetitionsCount);
                watch.Stop();
                time2 = (double) watch.ElapsedMilliseconds / repetitionsCount;
                result.Add(new ExperimentResult(size, time2, time1));
            }

            return result;
		}
	}
}