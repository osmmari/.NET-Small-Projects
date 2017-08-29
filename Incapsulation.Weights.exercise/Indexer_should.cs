using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Weights
{
    [TestFixture]
    public class Indexer_should
    {
        double[] array = new double[] { 1, 2, 3, 4 };

/*        [Test]
        public void HaveCorrectLength()
        {
            var indexer = new Indexer(array, 1, 2);
            Assert.AreEqual(2,indexer.Length);
        } */

        [Test]
        public void GetCorrectly()
        {
            var indexer = new Indexer(array, 1, 8);
 //           Assert.AreEqual(2, indexer[0]);
 //           Assert.AreEqual(3, indexer[15]);
            Assert.AreEqual(3, indexer[1]);
            Assert.AreEqual(4, indexer[2]);
            Assert.AreEqual(5, indexer[3]);
            Assert.AreEqual(3, indexer[4]);
            Assert.AreEqual(3, indexer[5]);
            Assert.AreEqual(3, indexer[6]);
        }

/*       [Test]
        public void SetCorrectly()
        {
            var indexer = new Indexer(array, 1, 2);
            indexer[0] = 10;
            Assert.AreEqual(10,array[1]);
        }

        [Test]
        public void FailWithWrongArguments1()
        {
            Assert.Throws(typeof(ArgumentException), () => new Indexer(array, -1, 3));
        }

        [Test]
        public void FailWithWrongArguments2()
        {
            Assert.Throws(typeof(ArgumentException), () => new Indexer(array, 1, -1));
        }

        [Test]
        public void FailWithWrongArguments3()
        {
            Assert.Throws(typeof(ArgumentException), () => new Indexer(array, 1, 10));
        }

        [Test]
        public void FailWithWrongIndexing1()
        {
            var indexer = new Indexer(array, 1, 2);
            Assert.Throws(typeof(IndexOutOfRangeException), () => { var a=indexer[-1]; });
        }

        [Test]
        public void FailWithWrongIndexing2()
        {
            var indexer = new Indexer(array, 1, 2);
            Assert.Throws(typeof(IndexOutOfRangeException), () => { var a = indexer[10]; });
        } */
    }
}
