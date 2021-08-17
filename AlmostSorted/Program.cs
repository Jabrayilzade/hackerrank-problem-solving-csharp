using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;
using static System.Console;

namespace AlmostSorted
{
    internal static class Program
    {
        private static string AlmostSorted(IReadOnlyList<int> arr)
        {
            var arrLength = arr.Count - 1;
            var l = 0;
            var r = arr.Count - 1;

            for (var i = 0; i < arrLength; i++)
            {
                if (arr[i] <= arr[i + 1]) continue;
                l = i;
                break;
            }

            for (var i = arrLength; i >= 1; i--)
            {
                if (arr[i - 1] <= arr[i]) continue;
                r = i;
                break;
            }

            var rStrValue = "swap";

            for (var j = l + 1; j < r - 1; j++)
            {
                if (arr[j] <= arr[j + 1]) continue;
                rStrValue = "reverse";
                break;
            }
            
            // WriteLine(l);
            // WriteLine(r);

            var arrCopy = new List<int>(arr);
            arrCopy.Reverse(l, r - l + 1);

            foreach (var e in arrCopy)
            {
                Write(e);
            }

            if (rStrValue != "swap")
            {
                for (var i = 0; i < arrCopy.Count - 1; i++)
                {
                    if (arrCopy[i] <= arrCopy[i + 1]) continue;
                    rStrValue = "no";
                    break;
                }
            }

            return rStrValue == "no" ? "no" : $"{rStrValue} {l + 1} {r + 1}";
        }

        private static void Main()
        {
            WriteLine(AlmostSorted(new List<int> { 1, 2, 3, 8, 5, 6, 7, 4, 9 }));
        }
    }
}
// 1, 2, 3, 8, 5, 6, 7, 3, 9, 10