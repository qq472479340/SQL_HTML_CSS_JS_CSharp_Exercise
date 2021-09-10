using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise6
{
    class Diamond
    {
        public static void Print(int row)
        {
            for (int i = 1; i <= 2*row-1; i++)
            {
                string res = "";
                if (i <= row)
                {
                    for (int j = 0; j < 2 * i - 1; j++)
                    {
                        res += "*";
                    }
                }
                else
                {
                    for (int j = 0; j < 2 * (2 * row - i) - 1; j++)
                    {
                        res += "*";
                    }
                }
                string space = "";
                for (int k = 0; k < (2*row-1-res.Length)/2; k++)
                {
                    space += " ";
                }
                res = space + res + space;
                Console.WriteLine(res);
            }
        }
    }
}
