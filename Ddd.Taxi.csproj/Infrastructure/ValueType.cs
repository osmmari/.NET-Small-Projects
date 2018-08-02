using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ddd.Infrastructure
{
    /// <summary>
    /// Базовый класс для всех Value типов.
    /// </summary>
    public abstract class ValueType<T>
    {
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            //return this == obj;
            foreach(var property in GetType().GetProperties())
            {
                if (property.GetValue(this) != property.GetValue(obj))
                    return false;
            }
            return true;
        }
         
        public override string ToString()
        {
            StringBuilder result;
            var properties = GetType().GetProperties();
            result = properties.Select(x => x.Name + GetValue(x).ToString())

            return "";
        }

        private object GetValue(PropertyInfo x)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}