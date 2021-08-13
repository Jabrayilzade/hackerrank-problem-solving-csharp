using System;
using System.Text;

namespace Encryption
{
    internal static class Program
    {
        private static char[,] GetCharMatrix(char[,] matrix, int rows, int columns, string sentence)
        {
            var index = 0;
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < columns; col++)
                {
                    try
                    {
                        matrix[row, col] = sentence[index];
                    }
                    catch (Exception)
                    {
                        matrix[row, col] = ' ';
                    }
                    finally
                    {
                        index++;
                    }
                }
            }

            return matrix;
        }

        private static string Encrypt(char[,] matrix, int rows, int columns)
        {
            var builder = new StringBuilder(rows * columns);

            for (var col = 0; col < columns; col++)
            {
                for (var row = 0; row < rows; row++)
                {
                    if (matrix[row, col] != ' ')
                        builder.Append(matrix[row, col]);
                }

                builder.Append(' ');
            }

            return builder.ToString();
        }

        private static string Encryption(string s)
        {
            var column = Convert.ToInt32(Math.Ceiling(Math.Sqrt(
                Math.Floor(Math.Sqrt(s.Length)) * Math.Ceiling(Math.Sqrt(s.Length)))));

            var row = Convert.ToInt32(Math.Floor(Math.Sqrt(
                Math.Floor(Math.Sqrt(s.Length)) * Math.Ceiling(Math.Sqrt(s.Length)))));
            if (row * column < 9)
            {
                row = 3;
                column = 3;
            }

            var matrix = new char[row, column];


            matrix = GetCharMatrix(matrix, row, column, s);
            s = Encrypt(matrix, row, column);
            return s;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}