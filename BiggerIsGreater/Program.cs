using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using static System.Console;

namespace BiggerIsGreater
{
    internal static class Program
    {
        private static string BiggerIsGreater(string str)
        {
            var chars = str.ToCharArray();

            var i = chars.Length - 1;
            while (i > 0)
            {
                if (chars[i - 1] >= chars[i]) i--;
                else
                {
                    var j = i;
                    while (j < chars.Length && chars[j] > chars[i - 1]) j++;

                    (chars[i - 1], chars[j - 1]) = (chars[j - 1], chars[i - 1]);

                    var newChar = new char[chars.Length];
                    for (var k = 0; k < i; k++)
                    {
                        newChar[k] = chars[k];
                    }

                    var end = chars.Length - 1;
                    for (var k = i; k < chars.Length; k++)
                    {
                        newChar[k] = chars[end--];
                    }

                    return new stzring(newChar);
                }
            }

            return "no answer";
        }

        // private static bool IsAllCharsSame(IReadOnlyList<char> arr)
        // {
        //     var isSame = true;
        //     foreach (var t in arr)
        //         if (t != arr[0])
        //             isSame = false;
        //
        //     return isSame;
        // }
        //
        // private static bool IsPossibleWord(IReadOnlyList<char> arr)
        // {
        //     if (arr.Count == 1) return false;
        //     return !IsAllCharsSame(arr);
        // }
        //
        //
        // private static string Rearrange(char[] arr)
        // {
        //     for (var i = arr.Length - 2; i >= 0; i--)
        //     {
        //         for (var j = arr.Length - 1; j >= i + 1; j--)
        //             if (string.CompareOrdinal(arr[j].ToString(), arr[i].ToString()) > 0)
        //             {
        //                 (arr[i], arr[j]) = (arr[j], arr[i]);
        //
        //                 var leftSlice = arr.Take(i + 1).ToArray();
        //                 var rightSlice = arr.Skip(i + 1).ToArray();
        //
        //                 Array.Sort(rightSlice);
        //                 return new string(leftSlice) + new string(rightSlice);
        //             }
        //     }
        //
        //     return "no answer";
        // }
        //
        // private static string BiggerIsGreater(string w)
        // {
        //     var arr = w.ToCharArray();
        //     var result = "no answer";
        //
        //     if (IsPossibleWord(arr))
        //         result = Rearrange(arr);
        //
        //
        //     return result;
        // }


        private static void Main(string[] args)
        {
            var input = ReadLine();
            WriteLine(BiggerIsGreater(input));
        }
    }
}