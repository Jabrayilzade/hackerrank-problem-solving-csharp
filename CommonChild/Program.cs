using System.Linq;
using static System.Console;

namespace CommonChild
{
    internal static class Program
    {
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