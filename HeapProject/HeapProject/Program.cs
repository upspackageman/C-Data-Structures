using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Heap t= new Heap(50);

            int select, value;

            while (true)
            {
                Console.WriteLine("1. Insert");
                Console.WriteLine("2. Delete root");
                Console.WriteLine("3. Display");
                Console.WriteLine("4. Quit");
                Console.Write("Enter selection: ");
                select = Convert.ToInt32(Console.ReadLine());

                if (select == 4)
                    break;

                switch (select)
                {
                    case 1:
                        Console.Write("Enter the value to be inserted: ");
                        value = Convert.ToInt32(Console.ReadLine());
                        t.insert(value);
                        break;
                        
                    case 2:
                        Console.WriteLine("Max value us " + t.DeleteRoot());
                        break;
                        
                    case 3:
                        t.display();
                        break;

                    default:
                        Console.WriteLine("Not in the list");
                        break;

                }
            }
        }
    }
}
