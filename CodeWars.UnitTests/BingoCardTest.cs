﻿using System;
using System.Linq;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace CodeWars.UnitTests
{
    [TestFixture]
    public class BingoCardTest
    {
        [Test]
        public void CardHas24Numbers()
        {
            Assert.AreEqual(24, BingoCard.GetCard().Length);
        }

        [Test]
        public void EachNumberOnCardIsUnique()
        {
            var card = BingoCard.GetCard();
            Assert.AreEqual(card.Length, card.ToList().Distinct().Count());
        }

        [TestCase("B", 5)]
        [TestCase("I", 5)]
        [TestCase("N", 4)]
        [TestCase("G", 5)]
        [TestCase("O", 5)]
        public void ColumnContainsCorrectNumberOfItems(string column, int count)
        {
            var numbers = BingoCard.GetCard().Where(x => x.StartsWith(column)).ToList();
            Assert.AreEqual(count, numbers.Count);
        }

        [Test]
        public void NumbersAreOrderedByColumn()
        {
            var columns = string.Join("", BingoCard.GetCard().ToList()
                .Select(x => x.Substring(0, 1)).ToArray());

            Assert.IsTrue(Regex.IsMatch(columns, "^[B]*[I]*[N]*[G]*[O]*$"));
        }

        [TestCase("B", 1, 15)]
        [TestCase("I", 16, 30)]
        [TestCase("N", 31, 45)]
        [TestCase("G", 46, 60)]
        [TestCase("O", 61, 75)]
        public void NumbersWithinColumnAreAllInTheCorrectRange(string column, int start, int end)
        {
            var numbers = BingoCard.GetCard().Where(x => x.StartsWith(column)).ToList();
            Assert.AreNotEqual(0, numbers.Count, "Column {0} not found", column);

            foreach (var number in numbers)
            {
                var n = Convert.ToInt32(number.Substring(1));
                Assert.GreaterOrEqual(n, start, "Column {0} should be in the range between {1} and {2}, found: {3}", column, start, end, number);
                Assert.LessOrEqual(n, end, "Column {0} should be in the range between {1} and {2}, found: {3}", column, start, end, number);
            }
        }

        [Test]
        public void NumbersWithinColumnAreInRandomOrder()
        {
            var card = BingoCard.GetCard().Select(x => Convert.ToInt32(x.Substring(1))).ToArray();

            var isRandom = false;
            for (var i = 1; i < card.Length; i++)
            {
                if (card[i - 1] > card[i])
                {
                    isRandom = true;
                    break;
                }
            }

            Assert.IsTrue(isRandom, "Unlikely result, is the list ordered?");
        }

        [Test]
        public void RandomnessTest()
        {
            var card = BingoCard.GetCard();
            var cardNumberCount = (new int[24]).ToList();

            for (var i = 0; i < 100; i++)
            {
                var c = BingoCard.GetCard();
                for (var j = 0; j < 24; j++)
                {
                    if (card[j] == c[j])
                    {
                        cardNumberCount[j]++;
                    }
                }
            }

            Assert.IsFalse(cardNumberCount.Any(x => x > 30), "The same number appeared on more than 30 of the 100 cards on the same spot, are the cards random?");
        }
    }
}
