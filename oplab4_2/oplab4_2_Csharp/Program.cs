using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oplab4_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var B1 = new BoolVector(7);
            var B2 = new BoolVector(7, 1, 0);
            var B3 = new BoolVector(0, 4, 1, 10);

            B1.Print();
            B2.Print();
            B3.Print();

            Console.WriteLine("~B1:");
            B1 = ~B1;
            B1.Print();
            Console.WriteLine("B2:");
            B2.Print();
            Console.WriteLine("B3 = ~B1 & B2:");
            B3 = B1 & B2;
            B3.Print();
        }
    }
}