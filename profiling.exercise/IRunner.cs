using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiling
{
    public interface IRunner
    {
        void Call(bool isClass, int size, int count);
    }
}
