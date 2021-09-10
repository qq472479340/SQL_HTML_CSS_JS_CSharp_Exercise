using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise3
{
    class Solution
    {
        public int solution(int A, int B)
        {
            int res = 0;
            for (int num = A; num <= B; num++)
            {
                if(Math.Sqrt(num)%1 == 0)
                {
                    res += 1;
                }
            }
            return res;
        }
        public void Run()
        {
            Console.WriteLine("enter first number: ");
            int A = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter second number: ");
            int B = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("result = "+solution(A, B));
        }
    }
}
