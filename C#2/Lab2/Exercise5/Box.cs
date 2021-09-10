using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    class Box
    {
        double length = 1, breadth = 1, height = 1;
        public double getVolume()
        {
            return length * breadth * height;
        }
        public void setLength(double len)
        {
            length = len;
        }

        public void setBreadth(double bre)
        {
            breadth = bre;
        }

        public void setHeight(double hei)
        {
            height = hei;
        }
    }
}
