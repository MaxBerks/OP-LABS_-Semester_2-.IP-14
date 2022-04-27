using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oplab5_Csharp
{
    public class TDate : TTriad
    {
        // Num1 - day | Num2 - month | Num3 - year

        public TDate(int num1, int num2, int num3) : base(num1, num2, num3)
        {
        }

        public override void IncreaseNum1(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Num1++;
                if (Num1 == 30)
                {
                    Num1 = 0;
                    IncreaseNum2(1);
                }
            }
        }
        public override void IncreaseNum2(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Num2++;
                if (Num2 == 12)
                {
                    Num2 = 0;
                    IncreaseNum3(1);
                }
            }

        }
        public override void IncreaseNum3(int n)
        {
            Num3 += n;
        }

        public override void DecreaseNum1(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Num1--;
                if (Num1 == 0)
                {
                    Num1 = 30;
                    DecreaseNum2(1);
                }
            }
        }
        public override void DecreaseNum2(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Num2--;
                if (Num2 == 0)
                {
                    Num2 = 12;
                    DecreaseNum3(1);
                }
            }
        }
        public override void DecreaseNum3(int n)
        {
            Num3 -= n;
        }

        public void Print()
        {
            Console.WriteLine($"{Correction(Num1)}.{Correction(Num2)}.{Correction(Num3)}");
        }

        private string Correction(int num)
        {
            string number;

            if (num < 10)
            {
                number = '0' + num.ToString();
            }
            else number = num.ToString();

            return number;
        }
    }
}
