using System;
using System.Collections.Generic;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of rows: ");
            int row = Convert.ToInt32(Console.ReadLine());
            Diamond.Print(row);

        }
    }
}
