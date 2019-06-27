using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace CodeWars.UnitTests
{
    [TestFixture]
    public class JosephusSurvivorTest
    {
        private static void testing(int actual, int expected)
        {
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public static void test1()
        {
            Console.WriteLine("Basic Tests JosSurvivor");
            testing(Kata.JosSurvivor(7, 3), 4);
            testing(Kata.JosSurvivor(11, 19), 10);
            testing(Kata.JosSurvivor(40, 3), 28);
            testing(Kata.JosSurvivor(14, 2), 13);
            testing(Kata.JosSurvivor(100, 1), 100);
            testing(Kata.JosSurvivor(1, 300), 1);
            testing(Kata.JosSurvivor(2, 300), 1);
            testing(Kata.JosSurvivor(5, 300), 1);
            testing(Kata.JosSurvivor(7, 300), 7);
            testing(Kata.JosSurvivor(300, 300), 265);
        }
        //-----------------------
        private static Random rnd = new Random();

        public static int JosSurvivorSol(int n, int k)
        {
            if (n == 1)
                return 1;
            return (JosSurvivorSol(n - 1, k) + k - 1) % n + 1;
        }
        //-----------------------
        private static void test2()
        {
            for (int i = 0; i < 40; i++)
            {
                int n = rnd.Next(1, 5000);
                int k = rnd.Next(1, 5000);
                testing(Kata.JosSurvivor(n, k), JosSurvivorSol(n, k));
            }
        }
        [Test]
        public static void RandomTests()
        {
            Console.WriteLine("Random Tests******* JosSurvivor");
            test2();
        }
    }
}
