using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Clones
{
	[TestFixture]
	public class CloneVersionSystem_should
	{
		[Test]
		public void Learn()
		{
			var clone1 = Execute("learn 1 45", "check 1").Single();
			Assert.AreEqual("45", clone1);
		}

		[Test]
		public void RollbackToBasic()
		{
			var clone1 = Execute("learn 1 45", "rollback 1", "check 1").Single();
			Assert.AreEqual("basic", clone1);
		}

		[Test]
		public void RollbackToPreviousProgram()
		{
			var clone1 = Execute("learn 1 45", "learn 1 100500", "rollback 1", "check 1").Single();
			Assert.AreEqual("45", clone1);
		}

		[Test]
		public void RelearnAfterRollback()
		{
			var clone1 = Execute("learn 1 45", "rollback 1", "relearn 1", "check 1").Single();
			Assert.AreEqual("45", clone1);
		}

		[Test]
		public void CloneBasic()
		{
			var clone2 = Execute("clone 1", "check 2").Single();
			Assert.AreEqual("basic", clone2);
		}

		[Test]
		public void CloneLearned()
		{
			var clone2 = Execute("learn 1 42", "clone 1", "check 2").Single();
			Assert.AreEqual("42", clone2);
		}

		[Test]
		public void LearnClone_DontChangeOriginal()
		{
			List<string> res = Execute("learn 1 42", "clone 1", "learn 2 100500", "check 1", "check 2");
			Assert.AreEqual(new []{ "42", "100500"}, res);
		}

		[Test]
		public void RollbackClone_DontChangeOriginal()
		{
			var res = Execute("learn 1 42", "clone 1", "rollback 2", "check 1", "check 2");
			Assert.AreEqual(new[] { "42", "basic" }, res);
		}

		[Test]
		public void ExecuteSample()
		{
			var res = Execute("learn 1 5",
				"learn 1 7",
				"rollback 1",
				"check 1",
				"clone 1",
				"relearn 2",
				"check 2",
				"rollback 1",
				"check 1");
			Assert.AreEqual(new[] { "5", "7", "basic" }, res);
		}

 /*       [Test]
        public void Test6()
        {
            var res = Execute("learn 1 47",
                "learn 1 52",
                "rollback 1",
                "rollback 1",
                "relearn 1",
                "relearn 1",
                "learn 1 37",
                "learn 1 29",
                "learn 1 10",
                "learn 1 50",
                "rollback 1",
                "learn 1 36",
                "rollback 1",
                "rollback 1",
                "relearn 1",
                "check 1",
                "learn 1 8",
                "rollback 1",
                "rollback 1",
                "clone 1",
                "check 2",
                "learn 1 34",
                "check 1",
                "learn 1 19",
                "check 1",
                "learn 2 64",
                "check 2",
                "learn 2 13",
                "check 2",
                "check 1",
                "learn 2 15",
                "learn 1 35",
                "learn 1 18",
                "rollback 1",
                "relearn 1",
                "rollback 2",
                "rollback 2",
                "rollback 1",
                "rollback 1",
                "check 2",
                "relearn 2",
                "relearn 1",
                "learn 2 61",
                "rollback 2",
                "rollback 1",
                "check 2",
                "learn 2 54",
                "learn 2 20",
                "learn 1 24",
                "learn 2 40",
                "rollback 2",
                "rollback 2",
                "rollback 2",
                "relearn 2",
                "rollback 2",
                "check 1",
                "learn 1 12",
                "learn 1 22",
                "learn 1 35",
                "relearn 2",
                "learn 1 13",
                "relearn 2",
                "relearn 2",
                "learn 2 25",
                "rollback 1",
                "learn 2 49",
                "clone 1",
                "learn 1 11",
                "relearn 3",
                "rollback 2",
                "rollback 2",
                "relearn 2",
                "rollback 3",
                "relearn 2",
                "rollback 1",
                "rollback 3",
                "rollback 3",
                "clone 3",
                "relearn 1",
                "learn 2 15",
                "rollback 4"
                );
            //Assert.AreEqual(new[] { "5", "7", "basic" }, res);
        } */

		private List<string> Execute(params string[] queries)
		{
			var cvs = Factory.CreateCVS();
			var results = new List<string>();
			foreach (var command in queries)
			{
				var result = cvs.Execute(command);
				if (result != null) results.Add(result);
			}
			return results;
		}
	}
}