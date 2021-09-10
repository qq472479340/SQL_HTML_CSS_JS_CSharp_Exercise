using System;
using System.Collections.Generic;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] arr = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
            List<int> res = new List<int>();
            res = SpiralOrder(arr);
            foreach (var item in res)
            {
                Console.WriteLine(item+"\t");
            }
        }
        public static List<int> SpiralOrder(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            int rowStart = -1;
            int rowEnd = m;
            int colStart = -1;
            int colEnd = n;

            // initial setting
            int direction = 0;
            int x = 0;
            int y = 0;
            var res = new List<int>();

            while (true)
            {
                if (res.Count == m * n) return res;
                res.Add(matrix[x][y]);

                switch (direction)
                {
                    case 0:
                        // keep moving to its right until it hit the border
                        if (y + 1 == colEnd)
                        {
                            direction = 1; // direction changes
                            x++; // move to next row
                            rowStart++; // border on top changes
                        }
                        else
                        {
                            y++; // move right
                        }
                        break;
                    case 1:
                        // keep moving down until it hit the border
                        if (x + 1 == rowEnd)
                        {
                            direction = 2;
                            y--;
                            colEnd--; // right border changes
                        }
                        else
                        {
                            x++;
                        }
                        break;
                    case 2:
                        // keep moving left until it hit border
                        if (y - 1 == colStart)
                        {
                            direction = 3;
                            x--;
                            rowEnd--;
                        }
                        else
                        {
                            y--;
                        }
                        break;
                    case 3:
                        // keep moving up
                        if (x - 1 == rowStart)
                        {
                            direction = 0;
                            y++;
                            colStart++;
                        }
                        else
                        {
                            x--;
                        }
                        break;
                    default:
                        break;
                }
            }
            //return res;
        }
    }
}
