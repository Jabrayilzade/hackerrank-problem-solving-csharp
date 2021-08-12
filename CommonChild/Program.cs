using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace CommonChild
{
    internal static class Program
    {
        private static int CommonChild(string s1, string s2)
        {
            var list1 = new List<char>(s1.ToCharArray());
            var list2 = new List<char>(s2.ToCharArray());
            var counter = 0;

            for (var i = 0; i < list1.Count; i++)
            {
                if (list2.Contains(list1[i]))
                {
                    WriteLine($"{list1[i]} char of list1 array has matched with char of list array at index {2}");
                }
            }

            // S H I N C H A N 
            // N O H A R A A A


            return counter;
        }


        private static void Main()
        {
            WriteLine($"count - {CommonChild("SHINCHAN", "NOHARAAA")}");
        }
    }
}