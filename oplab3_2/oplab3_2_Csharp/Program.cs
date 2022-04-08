using System;


namespace oplab3_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var vectors = InitList();
            OutPut(vectors, "Here your vectors:");
            Console.WriteLine("\nHere your vectors with length:");
            var longest = Longest(vectors);
            Console.WriteLine("\nThe longest vector is:");
            longest.Print();
        }

        private static List<Vector> InitList()
        {
            var vectors = new List<Vector>()
            {
                new Vector(1, 3, 6), //6.78...
                new Vector(4, 6, 2), //7.48...
                new Vector(1, 1, 4), //4.24...
            };

            return vectors;
        }

        public static Vector Longest(List<Vector> vectors)
        {
            Vector longest = new Vector();
            double length = 0;
            foreach (var vector in vectors)
            {
                vector.PrintWithLength();
                if (vector.VectorLength() > length)
                { 
                    length = vector.VectorLength();
                    longest = vector;
                }
            }
            return longest;
        }

        public static void OutPut(List<Vector> vectors, string prompt)
        {
            Console.WriteLine(prompt);
            foreach(var vector in vectors)
            {
                vector.Print();
            }
        }
    }

    
}