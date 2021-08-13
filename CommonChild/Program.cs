using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace CommonChild
{
    internal static class Program
    {
        // private static int CommonChild(string s1, string s2)
        // {
        //     var arr1 = new List<char>(s1);
        //     var arr2 = new List<char>(s2);
        //
        //     var arr = new int[arr1.Count + 1, arr2.Count + 1];
        //
        //     for (var i = arr1.Count - 1; i >= 0; i--)
        //     {
        //         for (var j = arr2.Count - 1; j >= 0; j--)
        //         {
        //             if (arr1[i] == arr2[j]) arr[i, j] = arr[i + 1, j + 1] + 1;
        //             else arr[i, j] = Math.Max(arr[i + 1, j], arr[i, j + 1]);
        //         }
        //     }
        //
        //     int k = 0, t = 0;
        //     var sb = new StringBuilder();
        //
        //     while (k < arr1.Count && t < arr2.Count)
        //     {
        //         if (arr1[k] == arr2[t])
        //         {
        //             sb.Append(arr1[k]);
        //             k++;
        //             t++;
        //         }
        //         else if (arr[k + 1, t] >= arr[k, t + 1]) k++;
        //         else t++;
        //     }
        //
        //     return sb.Length;
        // }

        private static int CommonChild(string s1, string s2)
        {
            var arr1 = s1.Where(s2.Contains).ToList();
            var arr2 = s2.Where(s1.Contains).ToList();

            var pointer = -1;
            var length = 0;
            var max = 0;

            for (var i = 0; i < arr1.Count; i++)
            {
                for (var j = i; j < arr1.Count; j++)
                {
                    var matchedIndex = arr2.FindIndex(c => (c == arr1[j]) && (arr2.IndexOf(c) > pointer));
                    if (matchedIndex <= -1) continue;
                    pointer = matchedIndex;
                    length++;
                }

                if (max < length) max = length;
                pointer = -1;
                length = 0;
            }

            return max;
        }

        private static void Main()
        {
            CommonChild("SHINCHAN", "NOHARAAA");
        }
    }
}