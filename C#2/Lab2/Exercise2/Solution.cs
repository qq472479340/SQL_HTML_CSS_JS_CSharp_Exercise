using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise2
{
    class Solution
    {
        public int solution(int[] A)
        {
            int maxCount = 0;
            int res = A[0];
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var num in A)
            {
                if (dic.ContainsKey(num))
                    dic[num] += 1;
                else
                    dic.Add(num, 1);
                if (dic[num] > maxCount)
                {
                    maxCount = dic[num];
                    res = num;
                }
            }
            return res;
        }
        public int Run()
        {
            Console.WriteLine("enter the array size: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            Console.WriteLine("enter the array value: ");
            for (int i = 0 ; i < size; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            return solution(arr);
        }
    }
}
