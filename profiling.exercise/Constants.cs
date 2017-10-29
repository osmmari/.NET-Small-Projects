using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiling
{
    public class Constants
    {
        public const int ArraySize= 100;
        public static IReadOnlyCollection<int> FieldCounts;

        static Constants()
        {
            var fc = new List<int>();
            for (int i = 1; i <= 512; i *= 2)
                fc.Add(i);
            FieldCounts = fc.AsReadOnly();
        }
    }
}
