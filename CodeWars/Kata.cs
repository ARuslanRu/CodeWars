using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CodeWars
{
    public class Kata
    {
        #region <6kyu>
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            if (b.Length == 0)
            {
                return a;
            }

            int counter = 0;

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        counter++;
                        break;
                    }

                }
            }

            int[] rez = new int[a.Length - counter];
            int x = 0;
            bool mark;

            for (int i = 0; i < a.Length; i++)
            {
                mark = false;

                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        mark = false;
                        break;
                    }
                    mark = true;
                }

                if (mark)
                {
                    rez[x] = a[i];
                    x++;
                }
            }
            return rez;
        }

        public static int FindEvenIndex(int[] arr)
        {
            //Code goes here!
            for (int i = 0; i < arr.Length; i++)
            {
                var arraySum = arr.Sum();
                var arrayBefore = arr.Take(i).Sum();
                var arrayAfter = arraySum - arrayBefore - arr[i];

                if (arrayBefore == arrayAfter)
                {
                    return i;
                }
            }
            return -1;
        }

        public static long FindNb(long m)
        {
            var i = 0;
            while (m > 0)
            {
                m = m - Convert.ToInt64(Math.Pow(i, 3));

                if (m == 0)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public static string Likes(string[] name)
        {
            switch (name.Length)
            {
                case 0:
                    return $"no one likes this";
                case 1:
                    return $"{name[0]} likes this";
                case 2:
                    return $"{name[0]} and {name[1]} like this";
                case 3:
                    return $"{name[0]}, {name[1]} and {name[2]} like this";
                default:
                    return $"{name[0]}, {name[1]} and {name.Length - 2} others like this";
            }
        }

        public static int Find(int[] integers)
        {
            var i = integers.Where(x => x % 2 == 0).ToArray();
            if (i.Length == 1)
            {
                return i[0];
            }
            i = integers.Where(x => x % 2 != 0).ToArray();
            if (i.Length == 1)
            {
                return i[0];
            }
            return -1;
        }

        /// <summary>
        /// In a factory a printer prints labels for boxes. The printer uses colors which, for the sake of simplicity, are named with letters from a to z (except letters u, w, x or z that are for errors).
        /// The colors used by the printer are recorded in a control string. For example a control string would be aaabbbbhaijjjm meaning that the printer used three times color a, four times color b, one time color h then one time color a... and so on.
        /// Sometimes there are problems: lack of colors, technical malfunction and a control string is produced e.g.uuaaaxbbbbyyhwawiwjjjwwxym where errors are reported with letters u, w, x or z.
        /// You have to write a function hist which given a string will output the errors as a string representing a histogram of the encountered errors.
        /// Format of the output string:
        /// letter(error letters are sorted in alphabetical order) in a field of 2 characters, a white space, number of error for that letter in a field of 6, as many "*" as the number of errors for that letter and "\r".
        /// The string has a length greater or equal to one and contains only letters from a to z.
        /// Bash examples
        /// s="uuaaaxbbbbyyhwawiwjjjwwxym"
        /// hist(s) => "u  2     **\rw  5     *****\rx  2     **"
        /// or with dots to see white spaces:
        /// hist(s) => "u..2.....**\rw..5.....*****\rx..2.....**"
        /// s="uuaaaxbbbbyyhwawiwjjjwwxymzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz"
        /// hist(s) => "u..2.....**\rw..5.....*****\rx..2.....**\rz..31....*******************************"
        /// or printed:
        /// u  2     **
        /// w  5     *****
        /// x  2     **
        /// z  31    *******************************
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Hist(string s)
        {
            var chrArray = new char[] { 'u', 'w', 'x', 'z' };
            string rez = "";
            foreach (var item in chrArray)
            {
                var chrCount = s.Count(chr => chr == item);
                if (chrCount > 0)
                {
                    rez += $"{item,-2} {chrCount,-6}{new string('*', chrCount)}\r";
                }
            }
            rez = Regex.Replace(rez, @"\r$", "");
            return rez;
        }

        /// <summary>
        /// Count the number of Duplicates
        /// Write a function that will return the count of distinct case-insensitive alphabetic characters and numeric digits that occur more than once in the input string. The input string can be assumed to contain only alphabets(both uppercase and lowercase) and numeric digits.
        /// Example
        /// "abcde" -> 0 # no characters repeats more than once
        /// "aabbcde" -> 2 # 'a' and 'b'
        /// "aabBcde" -> 2 # 'a' occurs twice and 'b' twice (`b` and `B`)
        /// "indivisibility" -> 1 # 'i' occurs six times
        /// "Indivisibilities" -> 2 # 'i' occurs seven times and 's' occurs twice
        /// "aA11" -> 2 # 'a' and '1'
        /// "ABBA" -> 2 # 'A' and 'B' each occur twice
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int DuplicateCount(string str)
        {
            return str.ToLower().GroupBy(c => c).Count(c => c.Count() > 1); ;
        }

        /// <summary>
        /// John has invited some friends. His list is:
        /// s = "Fred:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
        /// Could you make a program that
        /// makes this string uppercase
        /// gives it sorted in alphabetical order by last name.
        /// When the last names are the same, sort them by first name.Last name and first name of a guest come in the result between parentheses separated by a comma.
        /// So the result of function meeting(s) will be:
        /// "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)"
        /// It can happen that in two distinct families with the same family name two people have the same first name too.
        /// Notes
        /// You can see another examples in the "Sample tests".
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Meeting(string s)
        {
            return string.Join("", s.Split(';')
                                    .Select(x => $"({string.Join(", ", x.Split(':').Reverse()).ToUpper()})")
                                    .OrderBy(x => x));
        }
        #endregion
    }
}
