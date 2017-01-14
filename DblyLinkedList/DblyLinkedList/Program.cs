using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DblyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            int select, data, x;
            DoubleLinkedList list = new DoubleLinkedList();
            list.createList();

            while (true)
            {
                Console.WriteLine("1. Display List");
                Console.WriteLine("2. Insert in empty List");
                Console.WriteLine("3. Insert a node in beginning of list");
                Console.WriteLine("4. Insert a node at the end of the list");
                Console.WriteLine("5. Insert a node after a specific node");
                Console.WriteLine("6. Insert a node before a specified node");
                Console.WriteLine("7. Delete first node");
                Console.WriteLine("8. Delete last node");
                Console.WriteLine("9. Delete any node");
                Console.WriteLine("10. Reverse the list");
                Console.WriteLine("11. Quit");
                Console.WriteLine("Enter your selection");
                select = Convert.ToInt32(Console.ReadLine());

                if (select == 11)
                    break;

                switch (select)
                {
                    case 1:
                        list.displayList();
                        break;
                    case 2:
                        Console.Write("Enter the element to be inserted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.insertInEmptyList(data);
                        break;
                    case 3:
                        Console.Write("Enter the element to be inserted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.insertInBeginning(data);
                        break;
                    case 4:
                        Console.Write("Enter the element to be inserted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.insertAtEnd(data);
                        break;
                    case 5:
                        Console.Write("Enter the element to be inserted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the element before which to insert: ");
                        x = Convert.ToInt32(Console.ReadLine());
                        list.insertAfter(data, x);
                        break;
                    case 6:
                        Console.Write("Enter the element to be inserted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the element before which to insert: ");
                        x = Convert.ToInt32(Console.ReadLine());
                        list.insertAfter(data, x);
                        break;
                    case 7:
                        list.deleteFirstNode();
                        break;
                    case 8:
                        list.deleteLastNode();
                        break;
                    case 9:
                        Console.Write("Enter the element to be deleted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.deleteNode(data);
                        break;
                    case 10:
                        list.reverseList();
                        break;
                    
                   
                }
            }
        }
    }
}
