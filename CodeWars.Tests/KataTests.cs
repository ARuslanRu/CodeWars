using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars.Tests
{
    [TestClass]
    public class KataTests
    {
        #region <6kyu>
        [TestMethod]
        public void ArrayDiffTest()
        {
            CollectionAssert.AreEqual(new int[] { 2 }, Kata.ArrayDiff(new int[] { 1, 2 }, new int[] { 1 }));
            CollectionAssert.AreEqual(new int[] { 2, 2 }, Kata.ArrayDiff(new int[] { 1, 2, 2 }, new int[] { 1 }));
            CollectionAssert.AreEqual(new int[] { 1 }, Kata.ArrayDiff(new int[] { 1, 2, 2 }, new int[] { 2 }));
            CollectionAssert.AreEqual(new int[] { 1, 2, 2 }, Kata.ArrayDiff(new int[] { 1, 2, 2 }, new int[] { }));
            CollectionAssert.AreEqual(new int[] { }, Kata.ArrayDiff(new int[] { }, new int[] { 1, 2 }));
        }

        [TestMethod]
        public void FindEvenIndexTest()
        {
            Assert.AreEqual(3, Kata.FindEvenIndex(new int[] { 1, 2, 3, 4, 3, 2, 1 }));
            Assert.AreEqual(1, Kata.FindEvenIndex(new int[] { 1, 100, 50, -51, 1, 1 }));
            Assert.AreEqual(-1, Kata.FindEvenIndex(new int[] { 1, 2, 3, 4, 5, 6 }));
            Assert.AreEqual(3, Kata.FindEvenIndex(new int[] { 20, 10, 30, 10, 10, 15, 35 }));
        }

        #endregion
    }
}
