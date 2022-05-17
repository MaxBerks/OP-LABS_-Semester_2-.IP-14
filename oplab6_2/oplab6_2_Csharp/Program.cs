using System;

namespace oplab6_Csharp
{
    class Program
    {
        static void Main()
        {
            Tree tree = new Tree();

            tree.Add(-1);
            tree.Add(3);
            tree.Add(0);
            tree.Add(-8);
            tree.Add(5);
            tree.Add(-27);
            tree.Add(101);
            tree.Add(100);
            tree.Add(-2);

            tree.numOfEl();

            tree.Print();
        }
    }
}

