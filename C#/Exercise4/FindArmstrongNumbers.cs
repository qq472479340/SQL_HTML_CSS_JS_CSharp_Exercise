using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise4
{
    class FindArmstrongNumbers
    {
        public static void FindNumbers(int num1, int num2)
        {
            List<int> res = new List<int>();
            for (int num = num1; num <= num2; num++)
            {
                string strNum = Convert.ToString(num);
                int sum = 0;
                for (int i = 0; i < strNum.Length; i++)
                {
                    int bitNum = strNum[i] -'0';
                    sum += Convert.ToInt32(Math.Pow(bitNum, 3));
                }
                if (sum == num)
                {
                    res.Add(num);
                }
            }
            foreach (var number in res)
            {
                Console.WriteLine(number);
            }
        }
    }
}
