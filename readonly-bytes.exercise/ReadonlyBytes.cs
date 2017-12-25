using System;
using System.Collections;
using System.Collections.Generic;

namespace hashes
{
    class ReadonlyBytes
    {
        public int Length
        {
            get; set;
        }

        public ReadonlyBytes()
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}