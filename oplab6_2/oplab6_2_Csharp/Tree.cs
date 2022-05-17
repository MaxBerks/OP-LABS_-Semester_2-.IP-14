using System;

namespace oplab6_Csharp
{
    public class Tree
    {
        private Node root;
        private int count { get; set; }
        private int countPlus { get; set; }
        private int countMinus { get; set; }
        private bool isZero { get; set; }
        private IComparer<int> _comparer = Comparer<int>.Default;


        public Tree()
        {
            root = null;
            count = 0;
            countPlus = 0;
            countMinus = 0;
            isZero = false;
        }
        public void numOfEl()
        {
            Console.WriteLine("======================================================");
            Console.WriteLine($"Number of elements more than zero: {countPlus}.");
            Console.WriteLine($"Number of elements less than zero: {countMinus}.");
            if (isZero) Console.WriteLine("Also there is zero element.");
            else Console.WriteLine("There is no zero element");
            Console.WriteLine("======================================================");
        }

        public bool Add(int Item)
        {
            if (Item < 0) countPlus++;
            else if (Item > 0) countMinus++;
            else isZero = true;

            if (root == null)
            {
                root = new Node(Item);
                count++;
                return true;
            }
            else
            {
                return Add_Sub(root, Item);
            }
        }

        private bool Add_Sub(Node Node, int Item)
        {
            if (_comparer.Compare(Node.item, Item) < 0)
            {
                if (Node.right == null)
                {
                    Node.right = new Node(Item);
                    count++;
                    return true;
                }
                else
                {
                    return Add_Sub(Node.right, Item);
                }
            }
            else if (_comparer.Compare(Node.item, Item) > 0)
            {
                if (Node.left == null)
                {
                    Node.left = new Node(Item);
                    count++;
                    return true;
                }
                else
                {
                    return Add_Sub(Node.left, Item);
                }
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            Print(root, 4);
        }

        public void Print(Node p, int padding)
        {
            if (p != null)
            {
                if (p.right != null)
                {
                    Print(p.right, padding + 4);
                }
                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }
                if (p.right != null)
                {
                    Console.Write("/\n");
                    Console.Write(" ".PadLeft(padding));
                }
                Console.Write(p.item.ToString() + "\n ");
                if (p.left != null)
                {
                    Console.Write(" ".PadLeft(padding) + "\\\n");
                    Print(p.left, padding + 4);
                }
            }
        }
    }
}
