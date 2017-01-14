using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeProj
{
    class Program
    {
        static void Main(string[] args)
        {

            BTree t= new BTree();
            int key, select;

            while (true)
            {
                Console.WriteLine("1. Search");
                Console.WriteLine("2. Insert");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Display");
                Console.WriteLine("5. Inorder traversal");
                Console.WriteLine("6. Quit");

                Console.Write("Enter your selection: ");
                select = Convert.ToInt32(Console.ReadLine());

                if (select == 6)
                    break;

                switch (select)
                {
                    case 1:
                        Console.Write("Enter the key to be searched: ");
                        key = Convert.ToInt32(Console.ReadLine());

                        if (t.Search(key) == true)
                            Console.WriteLine("Key present");
                        else
                            Console.WriteLine("key not present");
                        break;

                    case 2:
                        Console.Write("Enter the key to be inserted: ");
                        key = Convert.ToInt32(Console.ReadLine());
                        t.insert(key);
                        break;

                    case 3:
                        Console.Write("Enter the key to be deleted: ");
                        key = Convert.ToInt32(Console.ReadLine());
                        t.delete(key);
                        break;

                    case 4:
                        Console.WriteLine("B-Tree is: \n\n");
                        t.display();
                        Console.WriteLine("\n\n");
                        break;
                    case 5:
                        t.Inorder();
                        Console.WriteLine("\n\n");
                        break;
                    default:
                        Console.WriteLine("Not with parameters!");
                        break;
                }
            }
        }
    }
}
