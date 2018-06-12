using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.DataStructure
{
    public class Category : IComparable
    {
        private string name;
        private MessageType type;
        private MessageTopic topic;

        public Category(string name, MessageType type, MessageTopic topic)
        {
            this.name = name;
            this.type = type;
            this.topic = topic;
        }

        public int CompareTo(object obj)
        {
            if (this == null || obj == null) return 1;
            Category category2 = obj as Category;
            //Console.WriteLine(this.ToString() + category2.ToString());
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(category2.name))
                return 1;
            else
            {
                for (int i = 0; i < Math.Min(name.Length, category2.name.Length); i++)
                {
                    if (name[i] > category2.name[i]) return 1;
                    else if (name[i] < category2.name[i]) return -1;
                }
            }

            if (type > category2.type) return 1;
            else if (type < category2.type) return -1;

            if (topic > category2.topic) return 1;
            else if (topic < category2.topic) return -1;

            return 0;
        }

        public override string ToString()
        {
            return String.Format("{0}.{1}.{2}", name, type.ToString(), topic.ToString());
        }

        public bool Equals(Category obj)
        {
            return this.CompareTo(obj) == 0 ? true : false;
        }

        public static bool operator <=(Category element1, Category element2)
        {
            return element1.CompareTo(element2) <= 0 ? true : false;
        }

        public static bool operator >=(Category element1, Category element2)
        {
            return element1.CompareTo(element2) >= 0 ? true : false;
        }

        public static bool operator <(Category element1, Category element2)
        {
            return element1.CompareTo(element2) < 0 ? true : false;
        }

        public static bool operator >(Category element1, Category element2)
        {
            return element1.CompareTo(element2) > 0 ? true : false;
        }
    }
}
