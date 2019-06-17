using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars.Tests
{
    [TestClass]
    public class KataTests
    {

        #region <4kyu>
        [TestMethod]
        public void StringFuncTest()
        {
            string s, a;
            s = "This is a string exemplification!";
            a = s;
            Assert.AreEqual(a, Kata.StringFunc(s, 0));
            s = "String for test: incommensurability";
            a = "ySttirliinbga rfuosrn etmemsotc:n i";
            Assert.AreEqual(a, Kata.StringFunc(s, 1));
            s = "Ohh Man God Damn";
            a = " nGOnmohaadhMD  ";
            Assert.AreEqual(a, Kata.StringFunc(s, 7));
            s = "Ohh Man God Damnn";
            a = "haG mnad MhO noDn";
            Assert.AreEqual(a, Kata.StringFunc(s, 19));
        }

        #endregion

        #region <5kyu>
        [TestMethod]
        public void AlphanumericTest()
        {
            Assert.AreEqual(true, Kata.Alphanumeric("Mazinkaiser"));
            Assert.AreEqual(false, Kata.Alphanumeric("hello world_"));
            Assert.AreEqual(true, Kata.Alphanumeric("PassW0rd"));
            Assert.AreEqual(false, Kata.Alphanumeric("     "));
        }

        [TestMethod]
        public void JumbledStringTest()
        {
            string s, a;
            s = "c#";
            a = "c#";
            Assert.AreEqual(a, Kata.JumbledString(s, 0));
            s = "Such Wow!";
            a = "Sc o!uhWw";
            Assert.AreEqual(a, Kata.JumbledString(s, 1));
            s = "better example";
            a = "bexltept merae";
            Assert.AreEqual(a, Kata.JumbledString(s, 2));
            s = "qwertyuio";
            a = "qtorieuwy";
            Assert.AreEqual(a, Kata.JumbledString(s, 2));
            s = "Greetings";
            a = "Gtsegenri";
            Assert.AreEqual(a, Kata.JumbledString(s, 8));
        }

        [TestMethod]
        public void ScrambleTest()
        {
            Assert.AreEqual(true, Kata.Scramble("rkqodlw", "world"));
            Assert.AreEqual(true, Kata.Scramble("cedewaraaossoqqyt", "codewars"));
            Assert.AreEqual(false, Kata.Scramble("katas", "steak"));
            Assert.AreEqual(false, Kata.Scramble("scriptjavx", "javascript"));
            Assert.AreEqual(true, Kata.Scramble("scriptingjava", "javascript"));
            Assert.AreEqual(true, Kata.Scramble("scriptsjava", "javascripts"));
            Assert.AreEqual(false, Kata.Scramble("javscripts", "javascript"));
            Assert.AreEqual(true, Kata.Scramble("aabbcamaomsccdd", "commas"));
            Assert.AreEqual(true, Kata.Scramble("commas", "commas"));
            Assert.AreEqual(true, Kata.Scramble("sammoc", "commas"));
        }
        #endregion

        #region <6kyu>
        [TestMethod]
        public void FindMissingLetterTest()
        {
            Assert.AreEqual('e', Kata.FindMissingLetter(new[] { 'a', 'b', 'c', 'd', 'f' }));
            Assert.AreEqual('P', Kata.FindMissingLetter(new[] { 'O', 'Q', 'R', 'S' }));
        }

        [TestMethod]
        public void ValidPhoneNumberTest()
        {
            Assert.IsTrue(Kata.ValidPhoneNumber("(123) 456-7890"));
            Assert.IsFalse(Kata.ValidPhoneNumber("(1111)5X5 2345"));
        }

        [TestMethod]
        public void CleverSplitTest()
        {
            CollectionAssert.AreEqual(new string[] { "Buy", "a", "!car", "[!red green !white]", "[cheap or !new]" }, Kata.CleverSplit("Buy a !car [!red green !white] [cheap or !new]"));
            CollectionAssert.AreEqual(new string[] { "!Learning", "!C#", "is", "[a joy]" }, Kata.CleverSplit("!Learning !C# is [a joy]"));
            CollectionAssert.AreEqual(new string[] { "[Cats and dogs]", "are", "!beautiful", "and", "[cute]" }, Kata.CleverSplit("[Cats and dogs] are !beautiful and [cute]"));
        }     

        [TestMethod]
        public void CountSmileysTest()
        {
            Assert.AreEqual(4, Kata.CountSmileys(new string[] { ":D", ":~)", ";~D", ":)" }));
            Assert.AreEqual(2, Kata.CountSmileys(new string[] { ":)", ":(", ":D", ":O", ":;" }));
            Assert.AreEqual(1, Kata.CountSmileys(new string[] { ";]", ":[", ";*", ":$", ";-D" }));
            Assert.AreEqual(0, Kata.CountSmileys(new string[] { ";", ")", ";*", ":$", "8-D" }));
        }

        [TestMethod]
        public void SplitStringTest()
        {
            CollectionAssert.AreEqual(new string[] { "ab", "c_" }, Kata.SplitString("abc"));
            CollectionAssert.AreEqual(new string[] { "ab", "cd", "ef" }, Kata.SplitString("abcdef"));
        }

        [TestMethod]
        public void ToCamelCaseTest()
        {
            Assert.AreEqual("theStealthWarrior", Kata.ToCamelCase("the_stealth_warrior"), "Kata.ToCamelCase('the_stealth_warrior') did not return correct value");
            Assert.AreEqual("TheStealthWarrior", Kata.ToCamelCase("The-Stealth-Warrior"), "Kata.ToCamelCase('The-Stealth-Warrior') did not return correct value");
        }

        [TestMethod]
        public void IsValidIpTest()
        {
            Assert.AreEqual(true, Kata.IsValidIp("0.0.0.0"));
            Assert.AreEqual(true, Kata.IsValidIp("12.255.56.1"));
            Assert.AreEqual(true, Kata.IsValidIp("137.255.156.100"));
            Assert.AreEqual(false, Kata.IsValidIp(""));
            Assert.AreEqual(false, Kata.IsValidIp("abc.def.ghi.jkl"));
            Assert.AreEqual(false, Kata.IsValidIp("123.456.789.0"));
            Assert.AreEqual(false, Kata.IsValidIp("12.34.56"));
            Assert.AreEqual(false, Kata.IsValidIp("12.34.56.00"));
            Assert.AreEqual(false, Kata.IsValidIp("12.34.56.7.8"));
            Assert.AreEqual(false, Kata.IsValidIp("12.34.256.78"));
            Assert.AreEqual(false, Kata.IsValidIp("1234.34.56"));
            Assert.AreEqual(false, Kata.IsValidIp("pr12.34.56.78"));
            Assert.AreEqual(false, Kata.IsValidIp("12.34.56.78sf"));
            Assert.AreEqual(false, Kata.IsValidIp("12.34.56 .1"));
            Assert.AreEqual(false, Kata.IsValidIp("12.34.56.-1"));
            Assert.AreEqual(false, Kata.IsValidIp("123.045.067.089"));
        }

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

        public static string catalogString =
        "<prod><name>drill</name><prx>99</prx><qty>5</qty></prod>\n\n" +
        "<prod><name>hammer</name><prx>10</prx><qty>50</qty></prod>\n\n" +
        "<prod><name>screwdriver</name><prx>5</prx><qty>51</qty></prod>\n\n" +
        "<prod><name>table saw</name><prx>1099.99</prx><qty>5</qty></prod>\n\n" +
        "<prod><name>saw</name><prx>9</prx><qty>10</qty></prod>\n\n" +
        "<prod><name>chair</name><prx>100</prx><qty>20</qty></prod>\n\n" +
        "<prod><name>fan</name><prx>50</prx><qty>8</qty></prod>\n\n" +
        "<prod><name>wire</name><prx>10.8</prx><qty>15</qty></prod>\n\n" +
        "<prod><name>battery</name><prx>150</prx><qty>12</qty></prod>\n\n" +
        "<prod><name>pallet</name><prx>10</prx><qty>50</qty></prod>\n\n" +
        "<prod><name>wheel</name><prx>8.80</prx><qty>32</qty></prod>\n\n" +
        "<prod><name>extractor</name><prx>105</prx><qty>17</qty></prod>\n\n" +
        "<prod><name>bumper</name><prx>150</prx><qty>3</qty></prod>\n\n" +
        "<prod><name>ladder</name><prx>112</prx><qty>12</qty></prod>\n\n" +
        "<prod><name>hoist</name><prx>13.80</prx><qty>32</qty></prod>\n\n" +
        "<prod><name>platform</name><prx>65</prx><qty>21</qty></prod>\n\n" +
        "<prod><name>car wheel</name><prx>505</prx><qty>7</qty></prod>\n\n" +
        "<prod><name>bicycle wheel</name><prx>150</prx><qty>11</qty></prod>\n\n" +
        "<prod><name>big hammer</name><prx>18</prx><qty>12</qty></prod>\n\n" +
        "<prod><name>saw for metal</name><prx>13.80</prx><qty>32</qty></prod>\n\n" +
        "<prod><name>wood pallet</name><prx>65</prx><qty>21</qty></prod>\n\n" +
        "<prod><name>circular fan</name><prx>80</prx><qty>8</qty></prod>\n\n" +
        "<prod><name>exhaust fan</name><prx>62</prx><qty>8</qty></prod>\n\n" +
        "<prod><name>cattle prod</name><prx>990</prx><qty>2</qty></prod>\n\n" +
        "<prod><name>window fan</name><prx>62</prx><qty>8</qty></prod>";

        private static void DoCatalogTest(string s, string article, string exp)
        {
            Console.Write("article: " + article + "\n");
            string ans = Kata.Catalog(s, article);
            Console.Write("ACTUAL:\n" + ans + "\n");
            Console.Write("EXPECT:\n" + exp + "\n");
            Console.Write("{0:D}\n", exp == ans);
            Assert.AreEqual(exp, ans);
            Console.WriteLine("-");
        }

        [TestMethod]
        public void CatalogTest()
        {
            Console.WriteLine("Basic Tests");
            DoCatalogTest(catalogString, "ladder", "ladder > prx: $112 qty: 12");
            DoCatalogTest(catalogString, "saw", "table saw > prx: $1099.99 qty: 5\nsaw > prx: $9 qty: 10\nsaw for metal > prx: $13.80 qty: 32");
            DoCatalogTest(catalogString, "nails", "Nothing");

        }

        #endregion

        #region <7kyu>
        [TestMethod]
        public void MyLanguagesTest()
        {
            CollectionAssert.AreEqual(new string[] { "Ruby", "Python" }, 
                Kata.MyLanguages(new Dictionary<string, int> { { "Java", 10 }, { "Ruby", 80 }, { "Python", 65 } }).ToArray());
            CollectionAssert.AreEqual(new string[] { "Dutch", "Greek", "Hindi" },
                Kata.MyLanguages(new Dictionary<string, int> { { "Hindi", 60 }, { "Greek", 71 }, { "Dutch", 93 } }).ToArray());
            CollectionAssert.AreEqual(new string[] { },
                Kata.MyLanguages(new Dictionary<string, int> { { "C++", 50 }, { "ASM", 10 }, { "Haskell", 20 } }).ToArray());
        }

        [TestMethod]
        public void DisemvowelTest()
        {
            Assert.AreEqual("Ths wbst s fr lsrs LL!", Kata.Disemvowel("This website is for losers LOL!"));
        }

        [TestMethod]
        public void RemoveUrlAnchorTest()
        {
            Assert.AreEqual("www.codewars.com", Kata.RemoveUrlAnchor("www.codewars.com#about"));
            Assert.AreEqual("www.codewars.com/katas/?page=1", Kata.RemoveUrlAnchor("www.codewars.com/katas/?page=1#about"));
            Assert.AreEqual("www.codewars.com/katas/", Kata.RemoveUrlAnchor("www.codewars.com/katas/"));
        }
        #endregion
    }
}
