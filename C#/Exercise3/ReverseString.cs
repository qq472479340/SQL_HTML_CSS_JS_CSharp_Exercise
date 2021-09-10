using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise3
{
    class ReverseString
    {
        public static string Reverse(string str)
        {
            int length = str.Length;
            string res = "";
            for (int i = length-1; i >= 0; i--)
            {
                res += str[i];
            }
            return res;
        }
    }
}
