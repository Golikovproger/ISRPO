using System.Collections.Generic;
using System;

namespace ComplexNumbers
{
    public class Complex
    {
        double a = 0;
        double b = 0;


      
        public Complex(double a, double b) 
        {
            A = a;
            B = b;
        }
        
       public double A
        {
            get { return a; }
            set { a = value; } 
        }
        public double B
        {
            get { return b; }
            set { b = value; }
        }

        public Complex sumnum (Complex first, Complex second)
        {
            return new Complex(first.A + second.A, first.B + second.B);
        }
        public Complex minnum(Complex first, Complex second)
        {
            return new Complex (first.A - second.A, first.B - second.B);
        }
        public Complex multiply(Complex first, Complex second)
        {
            return new Complex((first.A * second.A) - (second.B * first.B),
                        (first.B * second.A) + (first.A * second.B));
        }
        public Complex separate (Complex first, Complex second)
        {
            return new Complex(((first.A * second.A) + (first.B * second.B)) / (Math.Pow(second.A, 2) + Math.Pow(second.B, 2)), ((first.B * second.A) - (first.A * second.B)) / (Math.Pow(second.A, 2) + Math.Pow(second.B, 2)));
        }
        public string Print ()
        {
            if (B >= 0) return $"{A}+{B}i";
            else return $"{A}{B}i";
        }
    }
}

