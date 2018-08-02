using System;
using Ddd.Taxi.Domain;
using NUnit.Framework;

namespace Ddd.Infrastructure
{
	[TestFixture]
	public class ValueType_Tests
	{
		[Test]
		public void AddressesWithNullsAreEqual()
		{
			var address = new Address(null, null);
			var other = new Address(null, null);
			Assert.IsTrue(address.Equals(other));
		}

		[Test]
		public void AddressNotEqualToNull()
		{
			var address1 = new Address("ул. Тургенева", "4");
			var equal = address1.Equals(null);
			Assert.IsFalse(equal);
		}

		[Test]
		public void AddressNotEqualToPersonName()
		{
			var address = new Address("A", "B");
			var person = new PersonName("A", "B");
			// ReSharper disable once SuspiciousTypeConversion.Global
			Assert.IsFalse(address.Equals(person));
		}

		[Test]
		public void CompareAddressesWithoutSomeValues()
		{
			var address = new Address("A", null);
			var other = new Address(null, "Y");
			Assert.IsFalse(address.Equals(other));
		}

		[Test]
		public void ComplexTypesAreEqual()
		{
			var person1 = new Person(new PersonName("A", "B"), 180, new DateTime(1988, 2, 29));
			var person2 = new Person(new PersonName("A", "B"), 180, new DateTime(1988, 2, 29));
			Assert.IsTrue(person1.Equals(person2));
		}

		[Test]
		public void DifferentAddressesAreNotEqual()
		{
			var address = new Address("A", "B");
			var other = new Address("X", "Y");
			Assert.IsFalse(address.Equals(other));
		}

		[Test]
		public void HasTypedEqualsMethod()
		{
			var method = typeof(PersonName).GetMethod("Equals", new[] { typeof(PersonName) });
			var errorMessage = "PersonName should contain method public bool Equals(PersonName name)";
			Assert.IsNotNull(method, errorMessage);
			Assert.IsTrue(method.IsPublic, errorMessage);
			Assert.IsTrue(method.ReturnType == typeof(bool), errorMessage);
			Assert.IsTrue(method.GetParameters()[0].ParameterType == typeof(PersonName), errorMessage);
		}

		[Test]
		public void NotEqualComplexProperty()
		{
			var person1 = new Person(new PersonName("A", "B"), 180, new DateTime(1988, 2, 29));
			var person2 = new Person(new PersonName("A", "XXX"), 180, new DateTime(1988, 2, 29));
			Assert.IsFalse(person1.Equals(person2));
		}

		[Test]
		public void NotEqualDateProperties()
		{
			var person1 = new Person(new PersonName("A", "B"), 180, new DateTime(1988, 2, 29));
			var person2 = new Person(new PersonName("A", "B"), 180, new DateTime(1988, 2, 28));
			Assert.IsFalse(person1.Equals(person2));
		}

		[Test]
		public void NotEqualIntProperties()
		{
			var person1 = new Person(new PersonName("A", "B"), 180, new DateTime(1988, 2, 29));
			var person2 = new Person(new PersonName("A", "B"), 181, new DateTime(1988, 2, 29));
			Assert.IsFalse(person1.Equals(person2));
		}

		[Test]
		public void SameAdressesAreEqual()
		{
			var address1 = new Address("ул. Тургенева", "4");
			var address2 = new Address("ул. Тургенева", "4");
			var equal = address1.Equals((object) address2);
			Assert.IsTrue(equal);
		}

		[Test]
		public void ToString_ListAllPropertiesLexicografically()
		{
			Assert.AreEqual("PersonName(FirstName: A; LastName: B)", new PersonName("A", "B").ToString());
			Assert.AreEqual("Address(Building: Y; Street: X)", new Address("X", "Y").ToString());
			Assert.AreEqual("Address(Building: ; Street: )", new Address(null, null).ToString());
		}
	}

	public class Person : ValueType<Person>
	{
		public PersonName Name { get;  }
		public decimal Height { get; }
		public DateTime BirthDate { get; }

		public Person(PersonName name, decimal height, DateTime birthDate)
		{
			Name = name;
			Height = height;
			BirthDate = birthDate;
		}
	}
}