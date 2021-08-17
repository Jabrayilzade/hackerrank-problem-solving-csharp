using System;
using System.Collections.Generic;
using static System.Console;

namespace MatrixLayerRotation
{
    internal static class Program
    {
        private static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (var t in matrix)
            {
                foreach (var t1 in t)
                {
                    if (t1 < 10) Write(t1 + "  ");
                    else Write(t1 + " ");
                }

                WriteLine("");
            }
        }

        private static void MatrixRotation(IReadOnlyList<List<int>> matrix, int r)
        {
            var matrixBuilder = new List<List<int>>(matrix);

            var rowBegin = 0;
            var rowEnd = matrix.Count - 1;
            var columnBegin = 0;
            var columnEnd = matrix[0].Count - 1;

            while (rowBegin <= rowEnd && columnBegin <= columnEnd)
            {
                for (var i = columnBegin; i <= columnEnd; i++)
                {
                    if (rowBegin == i)
                    {
                        continue;
                    }
                    else
                    {
                        matrixBuilder[rowBegin][i - r] = matrix[rowBegin][i];
                    }
                }

                rowBegin++;

                for (var i = rowBegin; i <= rowEnd; i++)
                {
                    matrixBuilder[i - r][columnEnd] = matrix[i][columnEnd];
                }

                columnEnd--;

                if (rowBegin <= rowEnd)
                {
                    for (var i = columnEnd; i >= columnBegin; i--)
                    {
                        matrixBuilder[rowEnd][i + r] = matrix[rowEnd][i];
                    }
                }

                rowEnd--;

                if (columnBegin <= columnEnd)
                {
                    for (var i = rowEnd; i >= rowBegin; i--)
                    {
                        matrixBuilder[i + r][columnBegin] = matrix[i][columnBegin];
                    }
                }

                columnBegin++;
                
                WriteLine(rowBegin);
                WriteLine(columnBegin);
            }

            PrintMatrix(matrixBuilder);
        }

        private static void Main()
        {
            var matrix = new List<List<int>>
            {
                new List<int>() { 1, 2, 3, 4, 5 },
                new List<int>() { 6, 7, 8, 9, 10 },
                new List<int>() { 11, 12, 13, 14, 15 },
                new List<int>() { 15, 16, 17, 18, 19 }
            };

            MatrixRotation(matrix, 1);
        }
    }
}

// if (i == indent && j == indent)
// {
//     matrixBuilder[i + 1][j] = matrix[i][j];
// }
// else if (i == indent)
// {
//     matrixBuilder[i][j - 1] = matrix[i][j];
// }
// else if (j == indent)
// {
//     matrixBuilder[i + 1][j] = matrix[i][j];
// }
// else if (j == matrix[i].Count - 1 - indent)
// {
//     matrixBuilder[i - 1][j] = matrix[i][j];
// }
// else if (i == matrix.Count - 1 - indent)
// {
//     matrixBuilder[i][j + 1] = matrix[i][j];
// }
// else if (i == matrix.Count - 1 - indent && j == matrix[i].Count - 1 - indent)
// {
//     matrixBuilder[i][j + 1] = matrix[i][j + 1];
// }
//
// indent++;