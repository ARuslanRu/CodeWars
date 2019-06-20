using System;
using System.Collections.Generic;

namespace CodeWars
{
    /// <summary>
    /// After yet another dispute on their game the Bingo Association decides to change course and automize the game.
    /// Can you help the association by writing a method to create a random Bingo card?
    /// Task:
    /// Finish method:
    /// BingoCard.GetCard()
    /// A Bingo card contains 24 unique and random numbers according to this scheme:
    /// 5 numbers from the B column in the range 1 to 15
    /// 5 numbers from the I column in the range 16 to 30
    /// 4 numbers from the N column in the range 31 to 45
    /// 5 numbers from the G column in the range 46 to 60
    /// 5 numbers from the O column in the range 61 to 75
    /// The card must be returned as an array of Bingo style numbers:
    /// { "B14", "B12", "B5", "B6", "B3", "I28", "I27", ... }
    /// The numbers must be in the order of their column: B, I, N, G, O.Within the columns the order of the numbers is random.
    /// </summary>
    public class BingoCard
    {
        public static string[] GetCard()
        {
            var list = new List<string>();
            list.AddRange(GetColumn("B", 5, 1, 15));
            list.AddRange(GetColumn("I", 5, 16, 30));
            list.AddRange(GetColumn("N", 4, 31, 45));
            list.AddRange(GetColumn("G", 5, 46, 60));
            list.AddRange(GetColumn("O", 5, 61, 75));
            return list.ToArray();
        }
        static string[] GetColumn(string ch, int numbers, int startNum, int endNum)
        {
            var list = new List<string>();
            int i = 0;
            while (i < numbers)
            {
                var num = ch + new Random().Next(startNum, endNum);
                if (!list.Contains(num))
                {
                    list.Add(num);
                    i++;
                }
            }
            return list.ToArray();
        }
    }
}
