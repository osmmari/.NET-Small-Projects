using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiling
{
    public interface IProfiler
    {
        List<ExperimentResult> Measure(IRunner runner, int repetitionsCount);
    }
}
