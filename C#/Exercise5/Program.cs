using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Number of Rows: ");
            int row = Convert.ToInt32(Console.ReadLine());
            BinaryTriangle.Print(row);
        }
    }
}
