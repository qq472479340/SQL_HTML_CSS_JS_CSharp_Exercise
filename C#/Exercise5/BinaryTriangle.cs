using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    class BinaryTriangle
    {
        public static void Print(int row)
        {
            for (int i = 1; i <= row; i++)
            {
                string res = "";
                while (res.Length < i)
                {
                    if (res == "")
                        res += "1";
                    else
                    {
                        if (res[res.Length - 1] == '1')
                            res += "0";
                        else
                            res += "1";
                    }
                }
                Console.WriteLine(res);
            }
        }
    }
}
