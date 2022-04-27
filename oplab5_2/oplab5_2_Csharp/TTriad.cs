using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oplab5_Csharp
{
    public abstract class TTriad
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Num3 { get; set; }
        protected TTriad(int num1, int num2, int num3)
        {
            Num1 = num1;
            Num2 = num2;
            Num3 = num3;
        }

        public abstract void IncreaseNum1(int n);
        public abstract void DecreaseNum1(int n);
        public abstract void IncreaseNum2(int n);
        public abstract void DecreaseNum2(int n);
        public abstract void IncreaseNum3(int n);
        public abstract void DecreaseNum3(int n);
    }
}
