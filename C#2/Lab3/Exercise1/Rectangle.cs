using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1
{
    class Rectangle : Shape1
    {
        public override float Area()
        {
            return L * B;
        }

        public override float Circumference()
        {
            return (L + B) * 2;
        }
        public void GetValues()
        {
            Console.WriteLine("enter Length: ");
            L = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("enter Breadth: ");
            B = Convert.ToSingle(Console.ReadLine());
        }
    }
}
