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
        #endregion
    }
}
