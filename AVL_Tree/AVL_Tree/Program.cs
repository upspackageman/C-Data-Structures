using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVL_Tree tree = new AVL_Tree();
            int select,x;

            while (true)
            {
                Console.WriteLine("1. Display Tree");
                Console.WriteLine("2. Insert a new node");
                Console.WriteLine("3. Delete a node");
                Console.WriteLine("4. Inorder Traversal");
                Console.WriteLine("5. Quit");
                Console.Write("Enter your selection: ");
                select = Convert.ToInt32(Console.ReadLine());

                if (select == 5)
                    break;

                switch (select)
                {
                    case 1:
                        tree.display();
                        break;
                    case 2:
                        Console.Write("Enter key to be inserted: ");
                        x = Convert.ToInt32(Console.ReadLine());
                        tree.Insert(x);
                        break;
                    case 3:
                        Console.Write("Enter key to be inserted: ");
                        x = Convert.ToInt32(Console.ReadLine());
                        tree.delete(x);
                        break;

                    case 4:
                        tree.inOrder();
                        break;
                    default:
                        Console.WriteLine("Not witin parameter.");
                        break;

                }

                
            }
        }
    }
}
