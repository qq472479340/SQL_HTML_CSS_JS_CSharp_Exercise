using System;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your string: ");
            string str = Console.ReadLine();
            Console.Write("String after reversing: ");
            Console.WriteLine(ReverseString.Reverse(str));
        }
    }
}
