using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    class StackNode
    {
        private Node[] stackArray;
        private int top; 

        public StackNode()
        {
            stackArray = new Node[10];
            top = -1;
        }

        public StackNode(int maxSize)
        {
            stackArray = new Node[maxSize];
            top = -1;
        }

        public int Size()
        {
            return top + 1; 
        }

        public bool IsEmpty()
        {
            return (top == -1);
        }

        public bool IsFull()
        {
            return (top == stackArray.Length - 1);
        }

        public void Push(Node x)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack Overflow\n");
                return;
            }
            top = top + 1;
            stackArray[top] = x;
        }

        public Node Pop()
        {
            Node x;
            if (IsEmpty())
            {
                Console.WriteLine("Stack UnderFlow\n");
                throw new System.InvalidOperationException();
            }
            x = stackArray[top];
            top = top - 1;
            return x; 
        }
    }
}
