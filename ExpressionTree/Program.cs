using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpressionTree tree = new ExpressionTree();
            String postfix = "45+3/7*42/-";

            tree.BuildTree(postfix);
            tree.display();

            Console.Write("Prefix expression: ");
            tree.Prefix();

            Console.Write("Postfix expression: ");
            tree.Postfix();

            Console.Write("Parenthesized Infix expression: ");
            tree.ParenthesizedInfix();

            Console.Write("Value of the tree: ");
            Console.WriteLine(tree.Evaluate());
            Console.ReadKey();
        }
    }
}
