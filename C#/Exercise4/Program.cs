using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the start number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the end number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            FindArmstrongNumbers.FindNumbers(num1, num2);
        }
    }
}
