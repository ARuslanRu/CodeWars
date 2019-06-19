using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// In this example you have to validate if a user input string is alphanumeric. The given string is not nil, so you don't have to check that.
        /// The string has the following conditions to be alphanumeric:
        /// At least one character("" is not valid)
        /// Allowed characters are uppercase / lowercase latin letters and digits from 0 to 9
        /// No whitespaces/underscore
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Alphanumeric(string str) => Regex.IsMatch(str, @"^[a-zA-Z0-9]+$");

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
        /// nough is enough!
        /// Alice and Bob were on a holiday.Both of them took many pictures of the places they've been, and now they want to show Charlie their entire collection. However, Charlie doesn't like this sessions, since the motive usually repeats.He isn't fond of seeing the Eiffel tower 40 times. He tells them that he will only sit during the session if they show the same motive at most N times. Luckily, Alice and Bob are able to encode the motive as a number. Can you help them to remove numbers such that their list contains each number only up to N times, without changing the order?
        /// Task
        /// Given a list lst and a number N, create a new list that contains each number of lst at most N times without reordering.For example if N = 2, and the input is [1,2,3,1,2,1,2,3], you take[1, 2, 3, 1, 2], drop the next[1, 2] since this would lead to 1 and 2 being in the result 3 times, and then take 3, which leads to[1, 2, 3, 1, 2, 3].
        /// Example
        /// Kata.DeleteNth (new int[] {20,37,20,21}, 1) // return [20,37,21]
        /// Kata.DeleteNth(new int[] {1,1,3,3,7,2,2,2,2}, 3) // return [1, 1, 3, 3, 7, 2, 2, 2]
        /// </summary>
        /// <param name=""></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int[] DeleteNth(int[] arr, int x)
        {
            var list = new List<int>();
            foreach (var item in arr)
            {
                if (list.Count(n => n == item) < x)
                {
                    list.Add(item);
                }
            }
            return list.ToArray();
        }
        /// <summary>
        /// Given two arrays of strings a1 and a2 return a sorted array r in lexicographical order of the strings of a1 which are substrings of strings of a2.
        /// # Example 1: a1 = ["arp", "live", "strong"]
        /// a2 = ["lively", "alive", "harp", "sharp", "armstrong"]
        /// returns["arp", "live", "strong"]
        /// # Example 2: a1 = ["tarp", "mice", "bull"]
        /// a2 = ["lively", "alive", "harp", "sharp", "armstrong"]
        /// returns[]
        /// Notes:
        /// Arrays are written in "general" notation.See "Your Test Cases" for examples in your language.
        /// In Shell bash a1 and a2 are strings.The return is a string where words are separated by commas.
        /// Beware: r must be without duplicates.
        /// Don't mutate the inputs.
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static string[] InArray(string[] array1, string[] array2)
        {
            var list = new List<string>();
            foreach (var item in array1.OrderBy(x => x).ToArray())
            {
                if (array2.Where(x => x.Contains(item)).Count() > 0)
                {
                    list.Add(item);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// #Find the missing letter
        /// Write a method that takes an array of consecutive(increasing) letters as input and that returns the missing letter in the array.
        /// You will always get an valid array. And it will be always exactly one letter be missing. The length of the array will always be at least 2.
        /// The array will always contain letters in only one case.
        /// Example:
        /// ['a','b','c','d','f'] -> 'e'
        /// ['O','Q','R','S'] -> 'P'
        /// (Use the English alphabet with 26 letters!)
        /// Have fun coding it and please don't forget to vote and rank this kata! :-)
        /// I have also created other katas.Take a look if you enjoyed this kata!
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static char FindMissingLetter(char[] array)
        {
            char missing = ' ';
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (Convert.ToChar(array[i] + 1) != array[i + 1])
                {
                    missing = Convert.ToChar(array[i] + 1);
                }
            }
            return missing;
        }

        /// <summary>
        /// Write a function that accepts a string, and returns true if it is in the form of a phone number. 
        /// Assume that any integer from 0-9 in any of the spots will produce a valid phone number.
        /// Only worry about the following format:
        /// (123) 456-7890 (don't forget the space after the close parentheses) 
        /// Examples:
        /// validPhoneNumber("(123) 456-7890") => returns true
        /// validPhoneNumber("(1111)555 2345") => returns false
        /// validPhoneNumber("(098) 123 4567") => returns false
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool ValidPhoneNumber(string phoneNumber) =>
            Regex.IsMatch(phoneNumber, @"^\(\d{3}\)\s\d{3}-\d{4}$");

        /// <summary>
        /// You have a string. The string consists of words. Before words can be an exclamation mark !. Also some words are marked as one set with square brackets []. You task is to split the string into separate words and sets.
        /// The set can't be contained in another set.
        /// Input:
        /// String with words(separated by spaces), ! and[].
        /// Output:
        /// Array with separated words and sets.
        /// Examples:
        /// ('Buy a !car [!red green !white] [cheap or !new]') =>  ['Buy', 'a', '!car', '[!red green !white]', '[cheap or !new]']
        /// ('!Learning !javascript is [a joy]')                =>  ['!Learning', '!javascript', 'is', '[a joy]']
        /// ('[Cats and dogs] are !beautiful and [cute]')       =>  ['[Cats and dogs]', 'are', '!beautiful', 'and', '[cute]']
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string[] CleverSplit(string s)
        {
            return Regex.Matches(s, @"[!\w#]+|\[[!\w\s#]+\]").Cast<Match>().Select(m => m.Value).ToArray();
        }

        /// <summary>
        /// Description:
        /// Given an array(arr) as an argument complete the function countSmileys that should return the total number of smiling faces.
        /// Rules for a smiling face:
        /// -Each smiley face must contain a valid pair of eyes. Eyes can be marked as : or ;
        /// -A smiley face can have a nose but it does not have to.Valid characters for a nose are - or ~
        /// -Every smiling face must have a smiling mouth that should be marked with either ) or D.
        /// No additional characters are allowed except for those mentioned.
        /// Valid smiley face examples:
        /// :) :D ;-D :~)
        /// Invalid smiley faces:
        /// ;( :> :} :] 
        /// Example cases:
        /// countSmileys([':)', ';(', ';}', ':-D']);       // should return 2;
        /// countSmileys([';D', ':-(', ':-)', ';~)']);     // should return 3;
        /// countSmileys([';]', ':[', ';*', ':$', ';-D']); // should return 1;
        /// Note: In case of an empty array return 0. You will not be tested with invalid input(input will always be an array). Order of the face(eyes, nose, mouth) elements will always be the same
        /// Happy coding!
        /// </summary>
        /// <param name="smileys"></param>
        /// <returns></returns>
        public static int CountSmileys(string[] smileys)
        {
            return Regex.Matches(string.Join(",", smileys), "[:;][-~]?[)D]").Count;
        }

        /// <summary>
        /// Complete the solution so that it splits the string into pairs of two characters. If the string contains an odd number of characters then it should replace the missing second character of the final pair with an underscore ('_').
        /// Examples:
        /// SplitString.Solution("abc"); // should return ["ab", "c_"]
        /// SplitString.Solution("abcdef"); // should return ["ab", "cd", "ef"]
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] SplitString(string str)
        {
            var matches = str.Length % 2 == 0 ? Regex.Matches(str, @"\w\w") : Regex.Matches(str + "_", @"\w\w");
            return matches.Cast<Match>().Select(m => m.Value).ToArray();
        }

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
        /// Define a method/function that removes from a given array of integers all the values contained in a second array.
        /// Examples:
        /// int[] integerList = new int[] { 1, 1, 2, 3, 1, 2, 3, 4 }
        /// int[] valuesList = new int[] { 1, 3 }
        /// Kata.Remove(integerList, valuesList) == new int[]{ 2, 2, 4 } // --> true
        /// int[] integerList = new int[] { 1, 1, 2, 3, 1, 2, 3, 4, 4, 3, 5, 6, 7, 2, 8 }
        /// int[] valuesList = new int[] { 1, 3, 4, 2 }
        /// Kata.Remove(integerList, valuesList) == new int[]{ 5, 6 ,7 ,8 } // --> true
        /// int[] integerList = new int[] { 8, 2, 7, 2, 3, 4, 6, 5, 4, 4, 1, 2, 3 }
        /// int[] valuesList = new int[] { 2, 4, 3 }
        /// Kata.Remove(integerList, valuesList) == new int[]{ 8, 7, 6, 5, 1 } // --> true
        /// Enjoy it!!
        /// </summary>
        /// <param name="integerList"></param>
        /// <param name="valuesList"></param>
        /// <returns></returns>
        public static int[] Remove(int[] integerList, int[] valuesList) => integerList.Where(x => !valuesList.Contains(x)).ToArray();
        /// <summary>
        /// Your task
        /// You are given a dictionary/hash/object containing some languages and your test results in the given languages.Return the list of languages where your test score is at least 60, in descending order of the results.
        /// Note: There will be no duplicate values.
        /// Examples
        /// new Dictionary<string, int> {{"Java", 10}, {"Ruby", 80}, {"Python", 65}} => {"Ruby", "Python"}
        /// new Dictionary<string, int> {{"Hindi", 60}, {"Greek", 71}, {"Dutch", 93}} => {"Dutch", "Greek", "Hindi"}
        /// new Dictionary<string, int> {{"C++", 50}, {"ASM", 10}, {"Haskell", 20}} => {}
        /// My other katas
        /// If you enjoyed this kata then please try my other katas! :-)
        /// Translations are welcome!
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        public static IEnumerable<string> MyLanguages(Dictionary<string, int> results)
            => results.Where(x => x.Value >= 60).OrderByDescending(x => x.Value).Select(x => x.Key);
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

        #region <8kyu>
        /// <summary>
        /// Count the number of occurrences of each character and return it as a list of tuples in order of appearance.
        /// Example:
        /// Kata.orderedCount("abracadabra") == new List<Tuple<char, int>>() { new Tuple<char, int>('a', 5), new Tuple<char, int>('b', 2), new Tuple<char, int>('r', 2), new Tuple<char, int>('c', 1), new Tuple<char, int>('d', 1)}
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<Tuple<char, int>> OrderedCount(string input) => 
            input.GroupBy(x => x).Select(x => new Tuple<char, int>(x.Key, x.Count())).ToList();
        #endregion
    }
}
