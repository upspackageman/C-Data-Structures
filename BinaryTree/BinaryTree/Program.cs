using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree f = new BinaryTree();

            f.CreateTree();

            f.display();
            Console.WriteLine();

            Console.WriteLine("Preorder: ");
            f.preorder();
            Console.WriteLine("");

            Console.WriteLine(" Inorder: ");
            f.inorder();
            Console.WriteLine("");

            Console.WriteLine("Postorder: ");
            f.postorder();
            Console.WriteLine();

            Console.WriteLine("Height if tree is " + f.height());

            Console.ReadKey();
        }
    }
}
