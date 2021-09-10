using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1
{
    class Circle : Shape1
    {
        public override float Area()
        {
            return 3.14f * R * R;
        }

        public override float Circumference()
        {
            return 2 * 3.14f * R;
        }
        public void GetValues()
        {
            Console.WriteLine("enter Radius: ");
            R = Convert.ToSingle(Console.ReadLine());
            
        }
    }
}
