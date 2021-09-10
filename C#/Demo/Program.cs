using System;

namespace Demo
{
    class Program
    {

        public class Student
        {
            string name, address;
            int mobile;
            public void GetData()
            {
                Console.WriteLine("Enter your Name");
                name = Console.ReadLine();
                Console.WriteLine("Enter your Address");
                address = Console.ReadLine();
                Console.WriteLine("Enter your Mobile");
                mobile = Convert.ToInt32(Console.ReadLine());
            }

            public void DisplayData()
            {
                Console.WriteLine("Student Name:" + name);
                Console.WriteLine("Student Address:" + address);
                Console.WriteLine("Student Mobile:" + mobile);
            }

        }

        static void Main(string[] args)
        {
            Student s1 = new Student();
            s1.GetData();
            s1.DisplayData();
            Console.ReadKey();
        }
    }
}
