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

        [TestMethod]
        public void FindNbTest()
        {
            Assert.AreEqual(2022, Kata.FindNb(4183059834009));
            Assert.AreEqual(-1, Kata.FindNb(24723578342962));
            Assert.AreEqual(4824, Kata.FindNb(135440716410000));
            Assert.AreEqual(3568, Kata.FindNb(40539911473216));

        }

        [TestMethod]
        public void Likes()
        {
            Assert.AreEqual("no one likes this", Kata.Likes(new string[0]));
            Assert.AreEqual("Peter likes this", Kata.Likes(new string[] { "Peter" }));
            Assert.AreEqual("Jacob and Alex like this", Kata.Likes(new string[] { "Jacob", "Alex" }));
            Assert.AreEqual("Max, John and Mark like this", Kata.Likes(new string[] { "Max", "John", "Mark" }));
            Assert.AreEqual("Alex, Jacob and 2 others like this", Kata.Likes(new string[] { "Alex", "Jacob", "Mark", "Max" }));
        }

        [TestMethod]
        public void FindTest()
        {
            int[] exampleTest1 = { 2, 6, 8, -10, 3 };
            int[] exampleTest2 = { 206847684, 1056521, 7, 17, 1901, 21104421, 7, 1, 35521, 1, 7781 };
            int[] exampleTest3 = { int.MaxValue, 0, 1 };

            Assert.IsTrue(3 == Kata.Find(exampleTest1));
            Assert.IsTrue(206847684 == Kata.Find(exampleTest2));
            Assert.IsTrue(0 == Kata.Find(exampleTest3));
        }

        [TestMethod]
        public void HistTest()
        {
            Assert.AreEqual("u  3     ***\rw  4     ****\rx  6     ******\rz  6     ******",
                Kata.Hist("tpwaemuqxdmwqbqrjbeosjnejqorxdozsxnrgpgqkeihqwybzyymqeazfkyiucesxwutgszbenzvgxibxrlvmzihcb"));
            Assert.AreEqual("u  2     **\rw  1     *\rz  1     *",
                Kata.Hist("aaifzlnderpeurcuqjqeywdq"));
            Assert.AreEqual("u  4     ****\rw  3     ***\rx  4     ****\rz  4     ****",
                Kata.Hist("sjeneccyhrcpfvpujfaoaykqllteovskclebmzjeqepilxygdmzvdfmxbqdzubkzturnuqxsewrwgmdfwgdx"));
            Assert.AreEqual("u  1     *\rw  4     ****\rx  2     **\rz  1     *",
                Kata.Hist("bnxyytdtqrkeaswymiwbxnuydwthweyzny"));
            Assert.AreEqual("u  5     *****\rw  4     ****\rx  4     ****\rz  4     ****",
                Kata.Hist("ttopvdaxgwfpzjmomkwssytktaizqtsekfmfhrabidwaugioqyyzrxbugsusxkfdevmijqyprcoxfyjqwsutoutjgozyhsoytg"));
        }

        [TestMethod]
        public void DuplicateCountTest()
        {
            Assert.AreEqual(0, Kata.DuplicateCount(""));
            Assert.AreEqual(0, Kata.DuplicateCount("abcde"));
            Assert.AreEqual(2, Kata.DuplicateCount("aabbcde"));
            Assert.AreEqual(2, Kata.DuplicateCount("aabBcde"), "should ignore case");
            Assert.AreEqual(1, Kata.DuplicateCount("Indivisibility"));
            Assert.AreEqual(2, Kata.DuplicateCount("Indivisibilities"), "characters may not be adjacent");
        }

        [TestMethod]
        public static void MeetingTest()
        {
            string actual;
            string expect;
            actual = "Alexis:Wahl;John:Bell;Victoria:Schwarz;Abba:Dorny;Grace:Meta;Ann:Arno;Madison:STAN;Alex:Cornwell;Lewis:Kern;Megan:Stan;Alex:Korn";
            expect = "(ARNO, ANN)(BELL, JOHN)(CORNWELL, ALEX)(DORNY, ABBA)(KERN, LEWIS)(KORN, ALEX)(META, GRACE)(SCHWARZ, VICTORIA)(STAN, MADISON)(STAN, MEGAN)(WAHL, ALEXIS)";
            Assert.AreEqual(expect, actual);

            actual = "John:Gates;Michael:Wahl;Megan:Bell;Paul:Dorries;James:Dorny;Lewis:Steve;Alex:Meta;Elizabeth:Russel;Anna:Korn;Ann:Kern;Amber:Cornwell";
            expect = "(BELL, MEGAN)(CORNWELL, AMBER)(DORNY, JAMES)(DORRIES, PAUL)(GATES, JOHN)(KERN, ANN)(KORN, ANNA)(META, ALEX)(RUSSEL, ELIZABETH)(STEVE, LEWIS)(WAHL, MICHAEL)";
            Assert.AreEqual(expect, actual);

            actual = "Alex:Arno;Alissa:Cornwell;Sarah:Bell;Andrew:Dorries;Ann:Kern;Haley:Arno;Paul:Dorny;Madison:Kern";
            expect = "(ARNO, ALEX)(ARNO, HALEY)(BELL, SARAH)(CORNWELL, ALISSA)(DORNY, PAUL)(DORRIES, ANDREW)(KERN, ANN)(KERN, MADISON)";
            Assert.AreEqual(expect, actual);
        }

        #endregion
    }
}
