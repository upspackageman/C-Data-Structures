using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DblyLinkedList
{
    class DoubleLinkedList
    {
        private Node start;

        public DoubleLinkedList()
        {
            start = null;
        }
        public void createList()
        {
            int i, n, data;
            Console.Write("Enter number of nodes: ");
            n = Convert.ToInt32(Console.ReadLine());

            if (n == 0)
                return;
            Console.WriteLine("Enter the first element to be inserted: ");
            data = Convert.ToInt32(Console.ReadLine());
            insertInEmptyList(data);

            for (i = 2; i <= n; i++)
            {
                Console.Write("Enter the next element to be inserted: ");
                data = Convert.ToInt32(Console.ReadLine());
                insertAtEnd(data);
            }

        }
        public void displayList()
        {
            Node p;
            if (start == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            p = start;
            Console.Write("List is: ");
            while (p != null)
            {
                Console.Write(p.info + " ");
                p = p.next;

            }
            Console.WriteLine();
        }
        public void insertInBeginning(int data)
        {
            Node temp = new Node(data);
            temp.next = start;
            start.prev = temp;
            start = temp;
        }
        public void insertInEmptyList(int data)
        {
            Node temp = new Node(data);
            start = temp;
        }

        public void insertAtEnd(int data)
        {
            Node temp = new Node(data);

            Node p = start;
            while (p.next != null)
                p = p.next;

            p.next = temp;
            temp.prev = p;


        }

        public void insertBefore(int data, int x)
        {
            if (start == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            if (start.info == x)
            {
                Node temp = new Node(data);
                temp.next = start;
                start.prev = temp;
                start = temp;
                return;
            }

            Node p = start;
            while (p != null)
            {
                if (p.info == x)
                    break;
                p = p.next;
            }
            if (p == null)
                Console.WriteLine(x + " not in the list.");
            else
            {
                Node temp = new Node(data);
                temp.prev = p.prev;
                temp.next = p;
                p.prev.next = temp;
            }
        }
        public void insertAfter(int data, int x)
        {
            Node temp = new Node(data);

            Node p = start;
            while (p != null)
            {
                if (p.info == x)
                    break;
                p = p.next;

            }
            if (p == null)
            {
                Console.WriteLine(x + " is not in the list");
            }
            else
            {
                temp.prev = p;
                temp.next = p.next;
                if (p.next != null)
                    p.next.prev = temp;
                p.next = temp;

            }

        }
        public void deleteFirstNode()
        {
            if (start == null)
                return;
            if (start.next == null)
            {
                start = null;
                return;
            }
            start = start.next;
            start.prev = null; 

        }
        public void deleteLastNode()
        {
            if (start == null)
                return;
            if (start.next == null)
            {
                start =null;
                return;
            }
            Node p = start;
            while (p.next != null)
                p = p.next;
            p.prev.next = null; 


        }
        public void deleteNode(int x)
        {
            if (start == null)//list is empty check
                return;
            if (start.next == null)
            {
                if (start.info == x)
                    start = null;
                else
                    Console.WriteLine(x + " not found.");
                return;
            }

            if (start.info == x)
            {
                start = start.next;
                start.prev = null;
                return;
            }

            Node p = start.next;
            while (p.next != null)
            {
                if (p.info == x)
                    break;
                p=p.next;
            }
            if(p.next != null)
            {
                p.prev.next = p.next;
                p.next.prev = p.prev;
            }
            else
            {
                if (p.info == x)
                    deleteLastNode();
                else
                    Console.WriteLine(x + " not found");
            }
        }
        public void reverseList()
        {
            if (start == null)
                return;
            Node p1 = start;
            Node p2 = p1.next;
            p1.next = null;
            p1.prev = p2;
            while (p2 != null)
            {
                p2.prev = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = p2.prev;
            }
            start = p1;
        }
    }
   
}