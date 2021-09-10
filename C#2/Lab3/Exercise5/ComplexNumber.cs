using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    class ComplexNumber
    {
        public int RealPart { get; set; }
        public int ImaginaryPart { get; set; }
        public ComplexNumber(int a, int b)
        {
            RealPart = a;
            ImaginaryPart = b;
        }
        public int GetReal()
        {
            return RealPart;
        }
        public void SetReal(int a)
        {
            RealPart = a;
        }
        public int GetImaginary()
        {
            return ImaginaryPart;
        }
        public void SetImaginary(int b)
        {
            ImaginaryPart = b;
        }
        public new string ToString()
        {
            return $"({RealPart},{ImaginaryPart})";
        }
        public double GetMagnitude()
        {
            return Math.Sqrt(RealPart * RealPart + ImaginaryPart * ImaginaryPart);
        }
        public void Add(ComplexNumber number)
        {
            RealPart += number.RealPart;
            ImaginaryPart += number.ImaginaryPart;
        }
    }
}
