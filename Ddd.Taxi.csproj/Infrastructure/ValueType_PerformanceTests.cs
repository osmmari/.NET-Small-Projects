using System;
using System.Diagnostics;
using System.Linq;
using Ddd.Taxi.Domain;
using NUnit.Framework;

namespace Ddd.Infrastructure
{
	[TestFixture]
	public class ValueType_PerformanceTests
	{
		public class PersonName_WithHandcodedHashCode : ValueType<PersonName>
		{
			public PersonName_WithHandcodedHashCode(string firstName, string lastName)
			{
				FirstName = firstName;
				LastName = lastName;
			}

			public override int GetHashCode()
			{
				return unchecked((FirstName == null ? 0 : FirstName.GetHashCode()) * 16777619 + (LastName == null ? 0 : LastName.GetHashCode()));
			}

			public string FirstName { get; }
			public string LastName { get; }
		}

		[Test]
		public void GetHashCodePerformance()
		{
			// x20 - x40 times difference should be! 
			// But can be optimized to x2 slowdown with Expression Trees and their compilation. 
			// See Expression.Lambda(...).Compile()
			var count = 500000;
			new PersonName("", "").GetHashCode();
			new PersonName_WithHandcodedHashCode("", "").GetHashCode();
			var people1 = Enumerable.Range(1, count).Select(i => new PersonName(new string('f', i % 10), new string('s', i % 10))).ToList();
			var people2 = Enumerable.Range(1, count).Select(i => new PersonName_WithHandcodedHashCode(new string('f', i % 10), new string('s', i % 10))).ToList();
			var sw = Stopwatch.StartNew();
			foreach (var person in people1)
				person.GetHashCode();
			Console.WriteLine("ValueType<T> GetHashCode: " + sw.Elapsed);
			sw.Restart();
			foreach (var person in people2)
				person.GetHashCode();
			Console.WriteLine("Hand coded GetHashCode:   " + sw.Elapsed);
		}
	}
}