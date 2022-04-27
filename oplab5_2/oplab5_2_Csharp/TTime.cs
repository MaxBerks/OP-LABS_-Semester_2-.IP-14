using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oplab5_Csharp
{
    public class TTime : TTriad
    {
        // Num1 - hours | Num2 - minutes | Num3 - seconds

        public TTime(int num1, int num2, int num3) : base(num1, num2, num3)
        {
        }

        public override void IncreaseNum1(int n)
        {
            Num1 += n;
        }
        public override void IncreaseNum2(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Num2++;
                if (Num2 == 60)
                {
                    Num2 = 0;
                    IncreaseNum1(1);
                }
            }

        }
        public override void IncreaseNum3(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Num3++;
                if (Num3 == 60)
                {
                    Num3 = 0;
                    IncreaseNum2(1);
                }
            }
        }

        public override void DecreaseNum1(int n)
        {
            Num1 -= n;
        }
        public override void DecreaseNum2(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Num2--;
                if (Num2 == 0)
                {
                    Num2 = 59;
                    DecreaseNum1(1);
                }
            }
        }
        public override void DecreaseNum3(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Num3--;
                if (Num3 == 0)
                {
                    Num3 = 59;
                    DecreaseNum2(1);
                }
            }
        }

        public void Print()
        {
            Console.WriteLine($"{Correction(Num1)}:{Correction(Num2)}:{Correction(Num3)}");
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
