using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable IsExpressionAlwaysTrue

namespace Inheritance.DataStructure
{
    [TestFixture]
    public class Category_should
    {
        Category A11 = new Category("A", MessageType.Incoming, MessageTopic.Subscribe);
        Category A21 = new Category("A", MessageType.Outgoing, MessageTopic.Subscribe);
        Category A12 = new Category("A", MessageType.Incoming, MessageTopic.Error);
        Category B11 = new Category("B", MessageType.Incoming, MessageTopic.Subscribe);
        Category C1 = new Category(null, MessageType.Incoming, MessageTopic.Subscribe);
        Category C2 = new Category(null, MessageType.Incoming, MessageTopic.Subscribe);

        Category[] Descending()
        {
            return new[] { A11, A12, A21, B11 };
        }

        Category[] SpecialCase()
        {
            return new[] { A11, A12, A21, B11, C1, C2 };
        }

        Category A11_copy = new Category("A", MessageType.Incoming, MessageTopic.Subscribe);

        [Test]
        public void NullReference()
        {
            var a = SpecialCase();
            Assert.False(A11.Equals(C1));
            Assert.False(A11.Equals(C2));
            Assert.False(C1.Equals(A11));
            Assert.False(C2.Equals(A11));
            //Assert.True(C1.Equals(C2));
        }

        [Test]
        public void ImplementEqualsCorrectly()
        {
            var a = Descending();
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    Assert.AreEqual(i == j, a[i].Equals(a[j]), $"Error on {i} {j}");
            Assert.True(A11.Equals(A11_copy));
        }

        [Test]
        public void ImplementCompareToCorrectly()
        {
            var a = Descending();
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    Assert.AreEqual(Math.Sign(i.CompareTo(j)), Math.Sign(a[i].CompareTo(a[j])), $"Error on {i} {j}");
            Assert.AreEqual(0, A11.CompareTo(A11_copy));
        }

        [Test]
        public void ImplementOperatorsCorrectly()
        {
            var a = Descending();
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                {
                    Assert.AreEqual(i <= j, a[i] <= a[j], $"Error on <=, {i} {j}");
                    Assert.AreEqual(i >= j, a[i] >= a[j], $"Error on >=, {i} {j}");
                    Assert.AreEqual(i < j, a[i] < a[j], $"Error on <, {i} {j}");
                    Assert.AreEqual(i > j, a[i] > a[j], $"Error on >, {i} {j}");
                    Assert.AreEqual(i == j, a[i] == a[j], $"Error on ==, {i} {j}");
                    Assert.AreEqual(i != j, a[i] != a[j], $"Error on !=, {i} {j}");
                }
        }

        [Test]
        public void ImplementIComparableInterface()
        {
            Assert.True(A11 is IComparable);
        }

        [Test]
        public void ImplementToStringCorrectly()
        {
            Assert.AreEqual("A.Incoming.Subscribe", A11.ToString());
        }
    }
}
