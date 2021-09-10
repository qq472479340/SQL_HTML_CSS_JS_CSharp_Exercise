using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            double res;
            Box box1 = new Box();
            box1.setBreadth(20);
            box1.setHeight(30);
            box1.setLength(40);
            res = box1.getVolume();
            Console.WriteLine("Volume of Box1 : "+res);
            Box box2 = new Box();
            box1.setBreadth(20);
            box1.setHeight(20);
            box1.setLength(40);
            res = box1.getVolume();
            Console.WriteLine("Volume of Box2 : " + res);
            Box box3 = new Box();
            box1.setBreadth(20);
            box1.setHeight(30);
            box1.setLength(20);
            res = box1.getVolume();
            Console.WriteLine("Volume of Box3 : " + res);
        }
    }
}
