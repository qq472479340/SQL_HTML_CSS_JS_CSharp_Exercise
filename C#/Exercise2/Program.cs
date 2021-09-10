using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Arithmetic arithmetic = new Arithmetic();
            Console.Write("Enter first number: ");
            arithmetic.A = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number: ");
            arithmetic.B = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"The result is: {arithmetic.CalculateResult()}");
        }
    }
}
