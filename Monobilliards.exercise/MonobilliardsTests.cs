using NUnit.Framework;

namespace Monobilliards
{
	[TestFixture]
	public class MonobilliardsTests
	{
		[Test]
		public void InspectEmpty()
		{
			AssertCheater(false, new int[] { });
		}
		[Test]
		public void SingleBallShouldBeFirst()
		{
			AssertCheater(false, new[] { 1 });
		}
		[Test]
		public void IncreasingShouldBeValid()
		{
			AssertCheater(false, new[] { 1, 2 });
			AssertCheater(false, new[] { 1, 2, 3 });
			AssertCheater(false, new[] { 1, 2, 3, 4 });
		}
		[Test]
		public void DereasingShouldBeValid()
		{
			AssertCheater(false, new[] { 2, 1 });
			AssertCheater(false, new[] { 3, 2, 1 });
			AssertCheater(false, new[] { 4, 3, 2, 1 });
		}

		[Test]
		public void Sample()
		{
			AssertCheater(true, new[] { 3, 1, 2 });
        }

        [Test]
        public void Hidden5()
        {
            AssertCheater(false, new[] { 2, 3, 1 });
        }

        [Test]
        public void Hidden11()
        {
            AssertCheater(false, new[] { 3, 5, 4, 2, 7, 6, 1, 9, 10, 8, 11 });
        }
 
		public void AssertCheater(bool isCheater, int[] balls)
		{
			Assert.AreEqual(
				isCheater, 
				Factory.CreateMonobilards().IsCheater(balls), 
				"IsCheater(new int[]{{{0}}})", string.Join(", ", balls));
		}
	}
}