using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;


namespace CodeWars
{
    public class Kata
    {

        #region <4kyu>

        /// <summary>
        /// We have a string s
        /// Let's say you start with this: "String"
        /// The first thing you do is reverse it: "gnirtS"
        /// Then you will take the string from the 1st position and reverse it again: "gStrin"
        /// Then you will take the string from the 2nd position and reverse it again: "gSnirt"
        /// Then you will take the string from the 3rd position and reverse it again: "gSntri"
        /// Continue this pattern until you have done every single position, and then you will return the string you have created. For this particular string, you would return: "gSntir"
        /// now,
        /// The Task:
        /// In this kata, we also have a number x
        /// take that reversal function, and apply it to the string x times.
        /// return the result of the string after applying the reversal function to it x times.
        /// example where s = "String" and x = 3:
        /// after 0 iteration s = "String"
        /// after 1 iteration s = "gSntir"
        /// after 2 iterations s = "rgiStn"
        /// after 3 iterations s = "nrtgSi"
        /// so you would return "nrtgSi".
        /// Note
        /// String lengths may exceed 2 million
        /// x exceeds a billion
        /// be read to optimize
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string StringFunc(string s, long x)
        {
            //TODO: Тест на CodeWars работает более 12 сек. Вероятно требуется оптимизация.
            var len = s.Length;
            var resultS = s;

            for (int k = 0; k < x; k++)
            {
                StringBuilder a = new StringBuilder();
                for (int i = 0; i < len; i++)
                {
                    if (i % 2 == 0)
                    {
                        a.Append(resultS[len - 1 - i / 2]);
                    }
                    else
                    {
                        a.Append(resultS[i / 2]);
                    }
                }
                resultS = a.ToString();
                if (resultS.Equals(s))
                {
                    x = x % k;
                    k = 0;
                }
            }
            return resultS;
        }

        #endregion

        #region <5kyu>
        /// <summary>
        /// Complete the function scramble(str1, str2) that returns true if a portion of str1 characters can be rearranged to match str2, otherwise returns false.
        /// Notes:
        /// Only lower case letters will be used(a-z). No punctuation or digits will be included.
        /// Performance needs to be considered
        /// Input strings s1 and s2 are null terminated.
        /// Examples
        /// scramble('rkqodlw', 'world') ==> True
        /// scramble('cedewaraaossoqqyt', 'codewars') ==> True
        /// scramble('katas', 'steak') ==> False
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool Scramble(string str1, string str2)
        {
            foreach (var item in str2)
            {
                var isFind = str1.Count(x => x == item) >= str2.Count(x => x == item);
                if (!isFind)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Welcome
        /// This kata is inspired by This Kata
        /// We have a string s
        /// We have a number n
        /// Here is a function that takes your string, concatenates the even-indexed chars to the front, odd-indexed chars to the back.
        /// Examples
        /// s = "Wow Example!"
        /// result = "WwEapeo xml!"
        /// s = "I'm JomoPipi"
        /// result = "ImJm ii' ooPp"
        /// The Task:
        /// return the result of the string after applying the function to it n times.
        /// example where s = "qwertyuio" and n = 2:
        /// after 1 iteration s = "qetuowryi"
        /// after 2 iterations s = "qtorieuwy"
        /// return "qtorieuwy"
        /// Note
        /// there's a lot of tests, big strings, and n is greater than a billion
        /// so be ready to optimize.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string JumbledString(string s, long n)
        {
            //TODO: Работает, но необходима оптимизация. Тест на CodeWars выполняется более 12 секунд.
            var str = s;
            var dict = new Dictionary<long, string>();

            for (int i = 1; i <= n; i++)
            {
                str = string.Concat(str.Where((x, index) => index % 2 == 0)) + string.Concat(str.Where((x, index) => index % 2 != 0));
                dict.Add(i, str);
                if (str.Equals(s))
                {
                    dict.TryGetValue(n % i, out string value);
                    return value;
                }
            }
            return str;
        }

        #endregion

        #region <6kyu>
        /// <summary>
        /// Complete the method/function so that it converts dash/underscore delimited words into camel casing. The first word within the output should be capitalized only if the original word was capitalized (known as Upper Camel Case, also often referred to as Pascal case).
        /// Examples
        /// Kata.ToCamelCase("the-stealth-warrior") // returns "theStealthWarrior"
        /// Kata.ToCamelCase("The_Stealth_Warrior") // returns "TheStealthWarrior"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToCamelCase(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            var words = Regex.Split(str, "[-_]", RegexOptions.IgnoreCase);
            var newStr = string.Join("", words.Select(x => char.ToUpper(x[0]) + x.Substring(1, x.Length - 1)));
            return str[0] + newStr.Substring(1, newStr.Length - 1);
        }


        /// <summary>
        /// Write an algorithm that will identify valid IPv4 addresses in dot-decimal format. IPs should be considered valid if they consist of four octets, with values between 0 and 255, inclusive.
        /// Input to the function is guaranteed to be a single string.
        /// Examples
        /// Valid inputs:
        /// 1.2.3.4
        /// 123.45.67.89
        /// Invalid inputs:
        /// 1.2.3
        /// 1.2.3.4.5
        /// 123.456.78.90
        /// 123.045.067.089
        /// Note that leading zeros(e.g. 01.02.03.04) are considered invalid.
        /// </summary>
        /// <param name="ipAddres"></param>
        /// <returns></returns>
        public static bool IsValidIp(string ipAddres)
        {
            return Regex.IsMatch(ipAddres, @"^(\d|[1-9]\d|[1]\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|[1]\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|[1]\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|[1]\d\d|2[0-4]\d|25[0-5])$");
        }

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

        /// <summary>
        /// You are given a small extract of a catalog:
        /// s = "<prod><name>drill</name><prx>99</prx><qty>5</qty></prod>
        /// <prod><name>hammer</name><prx>10</prx><qty>50</qty></prod>
        /// <prod><name>screwdriver</name><prx>5</prx><qty>51</qty></prod>
        /// <prod><name>table saw</name><prx>1099.99</prx><qty>5</qty></prod>
        /// <prod><name>saw</name><prx>9</prx><qty>10</qty></prod>
        /// ...
        /// (prx stands for price, qty for quantity) and an article i.e "saw".
        /// The function catalog(s, "saw") returns the line(s) corresponding to the article with $ before the prices:
        /// "table saw > prx: $1099.99 qty: 5\nsaw > prx: $9 qty: 10\n..."
        /// If the article is not in the catalog return "Nothing".
        /// Notes
        /// There is a blank line between two lines of the catalog.
        /// The same article may appear more than once.If that happens return all the lines concerned by the article (in the same order as in the catalog).
        /// The line separator of results may depend on the language \nor \r\n.You can see examples in the "Sample tests".
        /// </summary>
        /// <param name="s"></param>
        /// <param name="article"></param>
        /// <returns></returns>
        public static string Catalog(string s, string article)
        {
            s = $"<data>{s.Replace("\n\n", "")}</data>";
            XDocument xDoc = XDocument.Parse(s);

            var products = xDoc.XPathSelectElements("./data/prod")
                               .Where(x => x.XPathSelectElement("./name").Value.Contains(article));

            if (products.Any())
            {
                return products.Select(x => $"{x.XPathSelectElement("./name").Value} > prx: ${x.XPathSelectElement("./prx").Value} qty: {x.XPathSelectElement("./qty").Value}\n")
                               .Aggregate((x, y) => x + y)
                               .Trim();
            }
            else
            {
                return "Nothing";
            }
        }
        #endregion

        #region <7kyu>
        /// <summary>
        /// Trolls are attacking your comment section!
        /// A common way to deal with this situation is to remove all of the vowels from the trolls' comments, neutralizing the threat.
        /// Your task is to write a function that takes a string and return a new string with all vowels removed.
        /// For example, the string "This website is for losers LOL!" would become "Ths wbst s fr lsrs LL!".
        /// Note: for this kata y isn't considered a vowel.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Disemvowel(string str)
        {
            return new Regex(@"[a|u|e|o|i]", RegexOptions.IgnoreCase).Replace(str, "");
        }

        /// <summary>
        /// Complete the function/method so that it returns the url with anything after the anchor (#) removed.
        /// Examples:
        /// Kata.RemoveUrlAnchor("www.codewars.com#about") => "www.codewars.com"
        /// Kata.RemoveUrlAnchor("www.codewars.com?page=1") => "www.codewars.com?page=1"
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string RemoveUrlAnchor(string url)
        {
            return Regex.Replace(url, @"#\w*", "");
        }
        #endregion
    }
}
