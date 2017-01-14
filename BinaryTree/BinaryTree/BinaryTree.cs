using BinaryTreeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BinaryTree
    {
        private Node root;
        
        public BinaryTree()
        {
            root=null;
        }

        public void display()
        {
            display(root, 0);
            Console.WriteLine();
        }
        private void display(Node p, int level)
        {
            int i;
            if (p == null)
                return;

            display(p.rchild, level + 1);
            Console.WriteLine();

            for(i=0; i<level; i++)
            {
                Console.Write("   ");

            }
            Console.Write(p.info);

            display(p.lchild, level + 1);
        }
        public void preorder()
        {
            preorder(root);
            Console.WriteLine();

        }
        private void preorder(Node p)
        {
            if (p == null)
                return;
            Console.Write(p.info + " ");
            preorder(p.lchild);
            preorder(p.rchild);
        }

        public void inorder()
        {
            inorder(root);
            Console.WriteLine();
        }

        private void inorder(Node p)
        {
            if (p == null)
                return;
            inorder(p.lchild);
            Console.Write(p.info + " ");
            inorder(p.rchild);
        }

        public void postorder()
        {
            postorder(root);
            Console.WriteLine(); 
        }

        private void postorder(Node p)
        { 
            if (p == null)
                return;
            postorder(p.lchild);
            postorder(p.rchild);
            Console.Write(p.info + " ");
        }

        public void levelorder()
        {
            if (root == null)
            {
                Console.WriteLine("tree is empty");
                return;
            }
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            Node p;
            while (queue.Count != 0)
            {
                p = queue.Dequeue();
                Console.Write(p.info + " ");
                if (p.lchild != null)
                    queue.Enqueue(p.lchild);
                if (p.rchild != null)
                    queue.Enqueue(p.rchild);

            }
            Console.WriteLine();


        }

        public int height()
        {
            return height(root);
        }

        private int height(Node p)
        {
            if (p == null)
                return 0;

            int hl = height(p.lchild);
            int hr = height(p.rchild);

            if (hl > hr)
                return 1 + hl;
            else
                return 1 + hr;

        }

        public void CreateTree()
        {
            root = new Node('P');
            root.lchild = new Node('Q');
            root.rchild = new Node('R');
            root.lchild.lchild = new Node('A');
            root.lchild.rchild = new Node('B');
            root.rchild.lchild = new Node('X');
        }
    }
}
