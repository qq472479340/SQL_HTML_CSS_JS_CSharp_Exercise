using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise4
{
    public class Person
    {
        public int age = 20;
        public void SetAge(int n)
        {
            age = n;
        }
        public void Hello()
        {
            Console.WriteLine("Hello");
        }
    }
}
