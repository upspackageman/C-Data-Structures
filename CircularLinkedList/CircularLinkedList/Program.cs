using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            int select, data, x;

            CircularLinkedList list = new CircularLinkedList();
            list.createList();

            while (true)
            {
                Console.WriteLine("1. Display List");
                Console.WriteLine("2. Insert in empty list");
                Console.WriteLine("3. Insert in the beginning");
                Console.WriteLine("4. Insert at the end ");
                Console.WriteLine("5. Insert after a node");
                Console.WriteLine("6. Delete first node");
                Console.WriteLine("7. Delete last node");
                Console.WriteLine("8. Delete any node");
                Console.WriteLine("9. Quit");
                Console.Write("Select: ");

                select = Convert.ToInt32(Console.ReadLine());

                if (select == 9)
                    break;

                switch (select)
                {
                    case 1:
                        list.displayList();
                        break;
                    case 2:
                        Console.Write("Enter Element to be inserted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.insertInEmptyList(data);
                        break;
                    case 3:
                        Console.Write("Enter Element to be inserted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.insertInBeginning(data);
                        break;
                    case 4:
                        Console.Write("Enter Element to be inserted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.insertAtEnd(data);
                        break;
                    case 5:
                        Console.Write("Enter Element to be inserted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the element after which to insert: ");
                        x = Convert.ToInt32(Console.ReadLine());
                        list.insertAfter(data, x);
                        break;
                    case 6:
                        list.deleteFirstNode();
                        break;
                    case 7:
                        list.deleteLastNode();
                        break;
                    case 8:
                        Console.Write("Enter Element to be deleted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.deleteNode(data);
                        break;

                    default:
                        Console.WriteLine("Not in the parameter of selection.");
                        break;
                }



            }

        }
    }
}
