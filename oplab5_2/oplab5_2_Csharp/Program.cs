using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oplab5_Csharp
{
    class Program
    {
        public static void Main()
        {
            var random = new Random();

            int n = random.Next(3, 7);
            int m = random.Next(3, 7);

            Dates(n);
            Time(m);
        }

        public static void Dates(int n)
        {
            Console.WriteLine("======================================= Dates =======================================");

            var random = new Random();

            for (int i = 0; i < n; i++)
            {
                var date = new TDate(random.Next(1, 30), random.Next(1, 12), random.Next(1, 100));
                date.Print();
                if (date.Num1 <= 23 && date.Num2 <= 59 && date.Num3 <= 59)
                {
                    Console.WriteLine("IsTime");
                }
                else
                {
                    date.DecreaseNum1(5);
                    date.Print();
                }
                Console.WriteLine();
            }
        }

        public static void Time(int m)
        {
            var random = new Random();

            Console.WriteLine("======================================= Time =======================================");

            for (int i = 0; i < m; i++)
            {
                var time = new TTime(random.Next(0, 23), random.Next(1, 59), random.Next(1, 59));
                time.Print();
                time.IncreaseNum2(15);
                time.Print();
                Console.WriteLine();
            }
        }
    }
}
