using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace CodeWars.UnitTests
{
    [TestFixture]
    public class KataTests
    {
        [Test]
        public void OrderedCountTest()
        {
            Assert.AreEqual(
                new List<Tuple<char, int>>() {
                    Tuple('a', 5),
                    Tuple('b', 2),
                    Tuple('r', 2),
                    Tuple('c', 1),
                    Tuple('d', 1)
                },
                Kata.OrderedCount("abracadabra")
            );
            Assert.AreEqual(
                new List<Tuple<char, int>>() {
                    Tuple('C', 1),
                    Tuple('o', 1),
                    Tuple('d', 1),
                    Tuple('e', 1),
                    Tuple(' ', 1),
                    Tuple('W', 1),
                    Tuple('a', 1),
                    Tuple('r', 1),
                    Tuple('s', 1)
                },
                Kata.OrderedCount("Code Wars")
            );
        }
        private static Tuple<char, int> Tuple(char character, int count)
        {
            return new Tuple<char, int>(character, count);
        }


        [Test]
        [TestCase(new int[] { 1, 1, 2, 3, 1, 2, 3, 4 }, new int[] { 1, 3 }, ExpectedResult = new int[] { 2, 2, 4 })]
        [TestCase(new int[] { 1, 1, 2, 3, 1, 2, 3, 4, 4, 3, 5, 6, 7, 2, 8 }, new int[] { 1, 3, 4, 2 }, ExpectedResult = new int[] { 5, 6, 7, 8 })]
        [TestCase(new int[] { }, new int[] { 2, 2, 4, 3 }, ExpectedResult = new int[] { })]
        public static int[] RemoveTest(int[] integerList, int[] valuesList)
        {
            return Kata.Remove(integerList, valuesList);
        }
    }

    [TestFixture]
    public class ReflectionTests
    {
        [Test]
        public void NullTest()
        {
            Assert.AreEqual(0, Kata.GetMethodNames(null).Length);
        }

        [Test]
        public void NewObjectTest()
        {
            var testObject = new object();
            var methodNameArray = Kata.GetMethodNames(testObject);
            Assert.IsTrue(methodNameArray.Contains("ToString"));
        }      
    }
}
