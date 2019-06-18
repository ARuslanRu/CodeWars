using System.Text.RegularExpressions;

namespace CodeWars
{
    public static class StringExtensions
    {
        /// <summary>
        /// Is the string uppercase?
        /// Task
        /// Create a method is_uppercase() to see whether the string is ALL CAPS.For example:
        /// is_uppercase("c") == False
        ///  is_uppercase("C") == True
        /// is_uppercase("hello I AM DONALD") == False
        /// is_uppercase("HELLO I AM DONALD") == True
        /// is_uppercase("ACSKLDFJSgSKLDFJSKLDFJ") == False
        /// is_uppercase("ACSKLDFJSGSKLDFJSKLDFJ") == True
        /// Corner Cases
        /// For simplicity, you will not be tested on the ability to handle corner cases(e.g. "%*&#()%&^#" or similar strings containing alphabetical characters at all) - an ALL CAPS(uppercase) string will simply be defined as one containing no lowercase letters.Therefore, according to this definition, strings with no alphabetical characters (like the one above) should return True.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUpperCase(this string str) => !Regex.IsMatch(str, "[a-z]");

        // SayHello...
        // SayGoodbye...
        /// <summary>
        /// An extension method allows you to add a fuction to an exsisting type. (See: https://msdn.microsoft.com/en-us//library/bb383977.aspx for examples.) Your challenge for this Kata is to write two basic extention methods: SayHello and SayGoodbye.
        /// Examples:
        /// string name = "Kathy"
        /// name.SayHello() --> "Hello, Kathy!"
        /// name.SayGoodbye() --> "Goodbye, Kathy. See you again soon!"
        /// You will not be expected to handle any erroneous data in your solution.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string SayHello(this string s) => $"Hello, {s}!";
        public static string SayGoodbye(this string s) => $"Goodbye, {s}. See you again soon!";
    }
}
