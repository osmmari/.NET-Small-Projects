using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TableParser;
using System.Collections.Generic;

namespace table_parser.Test
{
    [TestClass]
    public class UnitTest1
    {

        void Test(string input, List<string> array)
        {
            var result = FieldsParserTask.ParseLine(input);

            CollectionAssert.AreEqual(result, array);
            //Assert.AreEqual(result, array);
        }

        [TestMethod]
        public void Test1()
        {
            Test("hello world", new List<string> { "hello", "world" });
        }

        [TestMethod]
        public void Test2()
        {
            Test("a \"bcd ef\" \'x y\'", new List<string> { "a", "bcd ef", "x y" });
        }

        [TestMethod]
        public void Test3()
        {
            Test("\'\"1\" \"2\" \"3\"\'", new List<string> { "\"1\" \"2\" \"3\"" });
        }

        [TestMethod]
        public void Test4()
        {
            Test("\"a \'b\' \'c\' d\"", new List<string> { "a \'b\' \'c\' d" });
        }

        [TestMethod]
        public void Test5()
        {
            Test("a\"b", new List<string> { "a", "b" });
        }

        [TestMethod]
        public void Test6()
        {
            Test("\"\\\\\"", new List<string> { "\\" });
        }

        [TestMethod]
        public void Test7()
        {
            Test(" ", new List<string> { });
        }

        [TestMethod]
        public void Test10()
        {
            Test("   a    b    c     ", new List<string> { "a", "b", "c" });
        }

        [TestMethod]
        public void Test11()
        {
            Test("\\", new List<string> { "\\" });
        }

        [TestMethod]
        public void Test14()
        {
            Test("\'a ", new List<string> { "a " });
        }

        [TestMethod]
        public void Test15()
        {
            Test("\'a\\\'\\\\\'", new List<string> { "a\'\\" });
        }
    }
}
