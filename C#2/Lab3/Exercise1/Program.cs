using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.GetValues();
            Calculate(rectangle);
            Circle circle = new Circle();
            circle.GetValues();
            Calculate(circle);
        }
        public static void Calculate(Shape1 S)
        {
            
            Console.WriteLine("Area : {0}", S.Area());
            Console.WriteLine("Circumference : {0}", S.Circumference());

        }
    }
}
