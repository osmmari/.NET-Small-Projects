using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.BinaryTrees
{
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>, new()
    {
        public T Value { get; set; }
        public BinaryTree<T> Right { get; set; }
        public BinaryTree<T> Left { get; set; }
        public BinaryTree<T> FirstElement { get; set; }

        public BinaryTree()
        {
            Value = default(T);
            Right = null;
            Left = null;
            FirstElement = null;
        }

        private BinaryTree(T value, BinaryTree<T> first)
        {
            Value = value;
            Right = null;
            Left = null;
            FirstElement = first;
        }

        public void Add(T element)
        {
            if (FirstElement == null)
                FirstElement = this;
            if (Value.Equals(default(T)))
                Value = element;
            else if (element.CompareTo(Value) <= 0)
            {
                if (Left == null)
                    Left = new BinaryTree<T>(element, FirstElement);
                else
                    Left.Add(element);
                if (FirstElement.Value.Equals(Value))
                    FirstElement = this;
            }
            else
            {
                if (Right == null)
                    Right = new BinaryTree<T>(element, FirstElement);
                else
                    Right.Add(element);
                if (FirstElement.Value.Equals(Value))
                    FirstElement = this;
            }
        }

        public static BinaryTree<T> Create(params T[] elements)
        {
            BinaryTree<T> tree = new BinaryTree<T>();
            foreach (var element in elements)
            {
                tree.Add(element);
            }
            return tree;
        }

        public static BinaryTree<T> Create(T[] array, BinaryTree<T> tree)
        {
            return new BinaryTree<T>();
        }

        public T First()
        {
            return FirstElement.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<T> values = new List<T>();

            var e = Leaves(FirstElement);

            while (e.MoveNext())
            {
                values.Add(e.Current);
            }

            values.Sort();

            foreach (var element in values)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        private static List<T> allLeaves = new List<T>();

        private IEnumerator<T> Leaves(BinaryTree<T> node)
        {
            if (node != null)
            {
                yield return node.Value;
                if (node.Left != null)
                {
                    var e = Leaves(node.Left);
                    while (e.MoveNext())
                    {
                        yield return e.Current;
                    }
                }
                if (node.Right != null)
                {
                    var e = Leaves(node.Right);
                    while (e.MoveNext())
                    {
                        yield return e.Current;
                    }
                }
            }
        }
    }

    public class BinaryTree : IEnumerable
    {
        public int Value { get; set; }
        public BinaryTree Right { get; set; }
        public BinaryTree Left { get; set; }
        public BinaryTree FirstElement { get; set; }

        public BinaryTree()
        {
            Value = default(int);
            Right = null;
            Left = null;
            FirstElement = null;
        }

        private BinaryTree(int value, BinaryTree first)
        {
            Value = value;
            Right = null;
            Left = null;
            FirstElement = first;
        }

        public void Add(int element)
        {
            if (FirstElement == null)
                FirstElement = this;
            if (Value == default(int))
                Value = element;
            else if (element.CompareTo(Value) <= 0)
            {
                if (Left == null)
                    Left = new BinaryTree(element, FirstElement);
                else
                    Left.Add(element);
                if (FirstElement.Value.Equals(Value))
                    FirstElement = this;
            }
            else
            {
                if (Right == null)
                    Right = new BinaryTree(element, FirstElement);
                else
                    Right.Add(element);
                if (FirstElement.Value.Equals(Value))
                    FirstElement = this;
            }
        }

        public static BinaryTree Create(params int[] elements)
        {
            BinaryTree tree = new BinaryTree();
            foreach (var element in elements)
            {
                tree.Add(element);
            }
            return tree;
        }

        public static BinaryTree Create(int[] array, BinaryTree tree)
        {
            return new BinaryTree();
        }

        public int First()
        {
            return FirstElement.Value;
        }

        public IEnumerator GetEnumerator()
        {
            List<int> values = new List<int>();

            var e = Leaves(FirstElement);

            while (e.MoveNext())
            {
                values.Add(e.Current);
            }

            values.Sort();

            foreach (var element in values)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        private IEnumerator<int> Leaves(BinaryTree node)
        {
            if (node != null)
            {
                yield return node.Value;
                if (node.Left != null)
                {
                    var e = Leaves(node.Left);
                    while (e.MoveNext())
                    {
                        yield return e.Current;
                    }
                }
                if (node.Right != null)
                {
                    var e = Leaves(node.Right);
                    while (e.MoveNext())
                    {
                        yield return e.Current;
                    }
                }
            }
        }
    }
}
