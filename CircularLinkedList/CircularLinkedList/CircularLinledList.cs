using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLinkedList
{
    class CircularLinkedList
    {
        private Node last; 

        public CircularLinkedList()
        {
            last = null;
        }
        public void displayList()
        {
            if (last == null)
            {
                Console.WriteLine("List is empty\n");
                return;
            }
            Node p = last.link;
            do
            {
                Console.Write(p.info + " ");
                p = p.link;
            } while (p != last.link);
            Console.WriteLine();
        }
        public void insertInBeginning(int data)
        {
            Node temp = new Node(data);
            temp.link = last.link;
            last.link = temp;
        }
        public void insertInEmptyList(int data)
        {
            Node temp = new Node(data);
            last = temp;
            last.link = last;

        }
        public void insertAtEnd(int data)
        {
            Node temp = new Node(data);
            temp.link = last.link;
            last.link = temp;
            last = temp;
        }
        public void createList()
        {
            int i, n, data;
            Console.Write("enter the number of nodes: ");
            n = Convert.ToInt32(Console.ReadLine());

            if (n == 0)
                return;
            Console.Write("Enter the element to be inserted: ");
            data = Convert.ToInt32(Console.ReadLine());
            insertInEmptyList(data);

            for (i = 2; i <= n; i++)
            {
                Console.Write("Enter the element to be inserted: ");
                data = Convert.ToInt32(Console.ReadLine());
                insertAtEnd(data);
            }

        }
        public void insertAfter(int data, int x)
        {
            Node p = last.link;
            do
            {
                if (p.info == x)
                    break;
                p = p.link;
            } while (p != last.link);

            if (p == last.link && p.info != x)
                Console.WriteLine(x + " not present in the list");
            else
            {
                Node temp = new Node(data);
                temp.link = p.link;
                p.link = temp;
                if (p == last)
                    last = temp;
            }
        }
        public void deleteFirstNode()
        {
            if (last == null)
                return;
            if (last.link == last)
            {
                last =null;
                return;

            }
            last.link = last.link.link;

        }
        public void deleteLastNode()
        {
            if (last == null)
                return;
            if (last.link == last)
            {
                last = null;
                return;
            }
            Node p = last.link;
            while (p.link != last)
                p = p.link;
            p.link = last.link;
            last = p;
        }

        public void deleteNode(int x)
        {
            if (last == null)//list empty
                return;
            if(last.link==last && last.info == x)
            {
                last.link = last.link.link;
                return;
            }
            Node p = last.link;
            while(p.link != last.link)
            {
                if (p.link.info == x)
                    break;
                p = p.link;
            }
            if (p.link == last.link)
                Console.WriteLine(x + " not found in the list");
            else
            {
                p.link = p.link.link;
                if (last.info == x)
                    last = p;
            }
        }

    }
}
