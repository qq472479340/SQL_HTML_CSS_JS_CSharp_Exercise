using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise2
{
    class Arithmetic
    {
        public int A { get; set; }
        public int B { get; set; }
        int Addition()
        {
            return A + B;
        }
        int Subtraction()
        {
            return A - B;
        }
        int Multiplication()
        {
            return A * B;
        }
        int Division()
        {
            return A / B;
        }
        public int CalculateResult()
        {
            Console.WriteLine("Please enter +, -, *, /");
            string operation = Console.ReadLine();
            int res;
            switch (operation)
            {
                case "+":
                    res = Addition();
                    break;
                case "-":
                    res = Subtraction();
                    break;
                case "*":
                    res = Multiplication();
                    break;
                case "/":
                    res = Division();
                    break;
                default:
                    Console.WriteLine("Invalid Operator");
                    res = 0;
                    break;
            }
            return res;
        }
    }
}
