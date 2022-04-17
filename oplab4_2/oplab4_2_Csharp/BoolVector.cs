using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oplab4_Csharp
{
    class BoolVector
    {
        private int[] BoolVectorArr;

        public int[] GetBoolVectorArr()
        {
            return BoolVectorArr;
        }


        public BoolVector(int n)
        {
            BoolVectorArr = new int[n];
            for (int i = 0; i < n; i++)
            {
                BoolVectorArr[i] = GetRandom();
            }
        }

        public BoolVector(int n, int a, int b)
        {
            if (a == 0 && b == 1 || a == 1 && b == 0)
            {
                BoolVectorArr = new int[n];
                for (int i = 0; i < n; i++)
                {
                    if (i % 2 == 0) BoolVectorArr[i] = a;
                    else BoolVectorArr[i] = b;
                }
            }
            else Console.WriteLine("Error with initializing Boolean Vector!");
        }

        public BoolVector(int a, int na, int b, int nb)
        {
            if (a == 0 && b == 1 || a == 1 && b == 0)
            {
                int n = na + nb;
                BoolVectorArr = new int[n];
                for (int i = 0; i < n; i++)
                {
                    if (i < na) BoolVectorArr[i] = a;
                    else BoolVectorArr[i] = b;
                }
            }
            else Console.WriteLine("Error with initializing Boolean Vector!");
        }



        public void Print()
        {
            Console.WriteLine("[{0}]", string.Join(", ", BoolVectorArr));
        }
        private int GetRandom()
        {
            Random rnd = new Random();
 
            int value = rnd.Next(0, 2);

            return value;
        }

        public int GetLen()
        {
            int len = 0;
            foreach (int v in BoolVectorArr)
            {
                len++;
            }
            return len;
        }

        public void PrintLen()
        {
            Console.WriteLine(GetLen());
        }
        public int GetWeight()
        {
            int sum = 0;
            foreach(int v in BoolVectorArr)
            {
                if (v == 1) sum ++;
            }
            return sum;
        }
        public void PrintWeight()
        {
            Console.WriteLine(GetWeight());
        }


        public static BoolVector operator ~(BoolVector vector)
        {
            for (int i = 0; i < vector.GetLen(); i++)
            {
                if (vector.BoolVectorArr[i] == 0) vector.BoolVectorArr[i] = 1;
                else if (vector.BoolVectorArr[i] == 1) vector.BoolVectorArr[i] = 0;
            }
            return vector;
        }

        public static BoolVector operator &(BoolVector vector1, BoolVector vector2)
        {
            var vector3 = new BoolVector(vector1.GetLen());

            for (int i = 0; i < vector3.GetLen(); i++)
            {
                if(vector1.BoolVectorArr[i] == 1 && vector2.BoolVectorArr[i] == 1) vector3.BoolVectorArr[i] = 1;
                else vector3.BoolVectorArr[i] = 0;
            }

            return vector3;
        }
    }
}
