using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion
    }
}
