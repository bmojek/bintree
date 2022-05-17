using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tB = new BinTreeNode<char>('B');
            tB.Left = new BinTreeNode<char>('D');
            tB.Right = new BinTreeNode<char>('E');
            var tC = new BinTreeNode<char>('C',
                        new BinTreeNode<char>('F',
                            new BinTreeNode<char>('H'),
                            new BinTreeNode<char>('I')),
                        new BinTreeNode<char>('G')
                     );
            var t = new BinTreeNode<char>('A', tB, tC);
            var list = GetTraversePreorder(t);
            Console.WriteLine(string.Join(',', list));
        }

        public static void TraversePreOrder<T>(BinTreeNode<T> tree, Action<T> action)
        {
            if (tree == null) return;
            action(tree.Value);
            TraversePreOrder(tree.Left, action);
            TraversePreOrder(tree.Right, action);
        }

        public static List<T> GetTraversePreorder<T>(BinTreeNode<T> tree)
        {
            List<T> ts = new List<T>();

            Action<T> action = delegate (T a) { ts.Add(a); };

            TraversePreOrder<T>(tree, action);

            return ts;
        }

        public static BinTreeNode<char> CreateTreeOfChars()
        {
            BinTreeNode<char> tree = new BinTreeNode<char>('A');
            tree.Left = new BinTreeNode<char>('B');
            tree.Right = new BinTreeNode<char>('C');
            tree.Left.Left = new BinTreeNode<char>('D');
            tree.Left.Right = new BinTreeNode<char>('E');
            tree.Right.Right = new BinTreeNode<char>('G');
            tree.Right.Left = new BinTreeNode<char>('F');
            tree.Right.Left.Left = new BinTreeNode<char>('H');
            tree.Right.Left.Right = new BinTreeNode<char>('I');
            return tree;
        }

        public static void PrintTree<T>(BinTreeNode<T> p, int level = 0)
        {
            if (p == null) return;
            Console.WriteLine("".PadLeft(level, '.') + p.Value);
            PrintTree(p.Left, level + 1);
            PrintTree(p.Right, level + 1);
        }

        public static int NoOfNodes<T>(BinTreeNode<T> tree)
        {
            int i = 1;
            if (tree == null) return 0;
            else
            {
                i += NoOfNodes(tree.Left);
                i += NoOfNodes(tree.Right);
                return i;
            }
        }

        public static int Depth<T>(BinTreeNode<T> tree)
        {
            if (tree == null)
            {
                return 0;
            }
            else
            {
                return Math.Max(Depth(tree.Left), Depth(tree.Right)) + 1;
            }
        }

        public static void DoMirrorOfTree<T>(BinTreeNode<T> tree)
        {
            if (tree == null) return;

            DoMirrorOfTree(tree.Left);

            DoMirrorOfTree(tree.Right);
            BinTreeNode<T> binTree = new BinTreeNode<T>(default(T));
            binTree.Left = tree.Left;
            tree.Left = tree.Right;
            tree.Right = binTree.Left;
        }

        public static void Print<T>(BinTreeNode<T> p, int level = 0)
        {
            if (p == null) return;
            Print(p.Right, level + 1);
            Console.WriteLine("".PadLeft(level, '.') + p.Value);
            Print(p.Left, level + 1);
        }
    }

    public class BinTreeNode<T>
    {
        public T Value { get; set; }
        public BinTreeNode<T> Left { get; set; }
        public BinTreeNode<T> Right { get; set; }

        public BinTreeNode(T value, BinTreeNode<T> left = null, BinTreeNode<T> right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
}