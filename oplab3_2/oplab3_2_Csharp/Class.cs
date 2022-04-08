using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oplab3_Csharp
{
    class Vector
    {
        private double X;
        private double Y;
        private double Z;

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector()
        {
        }

        public double GetX()
        {
            return X;
        }

        public double GetY()
        {
            return X;
        }

        public double GetZ()
        {
            return X;
        }

        public double VectorLength()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
        }

        public void Print()
        {
            Console.WriteLine($"x: {X}  y: {Y} z:{Z}");
        }

        public void PrintWithLength()
        {
            Console.WriteLine($"x: {X}  y: {Y} z:{Z} len:{Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2))}");
        }
    }
}
