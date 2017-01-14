using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree t = new BinarySearchTree();

            int select, x;

            while (true)
            {
                Console.WriteLine("1. Display Tree");
                Console.WriteLine("2. Search");
                Console.WriteLine("3. Tnsert a new node");
                Console.WriteLine("4. Delete a node");
                Console.WriteLine("5. Preorder Traversal");
                Console.WriteLine("6. Inorder Traversal");
                Console.WriteLine("7. Postorder Traversal");
                Console.WriteLine("8. Height of tree");
                Console.WriteLine("9. Find min key");
                Console.WriteLine("10. Find max key");
                Console.WriteLine("11. Quit");
                Console.Write("Enter your selection: ");
                select = Convert.ToInt32(Console.ReadLine());

                if (select == 11)
                    break;

                switch (select)
                {
                    case 1:
                        t.display();
                        break;
                    case 2:
                        Console.Write("Enter the key to be searched: ");
                        x = Convert.ToInt32(Console.ReadLine());

                        if (t.search(x))
                            Console.WriteLine("Key found");
                        else
                            Console.WriteLine("Key not found");
                        break;
                    case 3:
                        Console.Write("Enter te key to be inserted: ");
                        x = Convert.ToInt32(Console.ReadLine());
                        t.insert_1(x);
                        break;
                    case 4:
                        Console.Write("Enter the key to be deleted: ");
                        x = Convert.ToInt32(Console.ReadLine());
                        t.delete(x);
                        break;
                    case 5:
                        t.preorder();
                        break;
                    case 6:
                        t.inorder();
                        break;
                    case 7:
                        t.postorder();
                        break;
                    case 8:
                        Console.WriteLine("Heigt of tree is " + t.height());
                        break;
                    case 9:
                        Console.WriteLine("Mininum key is " + t.min());
                        break;
                    case 10:
                        Console.WriteLine("Max key is " + t.max());
                        break;
                  }

            }
        }
    }
}
