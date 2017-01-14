using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class BinarySearchTree
    {
        private Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        public bool isEmpty()
        {
            return (root == null);
        }

        public void insert(int x)
        {
            root = insert(root, x);
        }

        private Node insert(Node p, int x)
        {
            if (p == null)
                p = new Node(x);
            else if (x < p.info)
                p.lchild = insert(p.lchild, x);
            else if (x < p.info)
                p.rchild = insert(p.rchild, x);
            else
                Console.WriteLine(x + " already present in tree");
            return p;
        }

        public void insert_1(int x)
        {
            Node p = root;
            Node param = null;

            while (p != null)
            {
                param = p;
                if (x < p.info)
                    p = p.lchild;
                else if (x > p.info)
                    p = p.rchild;
                else
                {
                    Console.WriteLine(x + " already present in the tree");
                    return;
                }
            }

            Node temp = new Node(x);

            if (param == null)
                root = temp;
            else if (x < param.info)
                param.lchild = temp;
            else
                param.rchild = temp;
                                  
        }

        public bool search(int x)
        {
            return (search(root, x) != null);
        }

        private Node search(Node p, int x)
        {
            if (p == null)
                return null;//key not found
            if (x < p.info)//search left subtree
                return search(p.lchild, x);
            if (x > p.info) //search in right subtree
                return search(p.rchild, x);
            return p;


        }
        public bool search_1(int x)
        {
            Node p = root;
            while (p != null)
            {
                if (x < p.info)
                    p = p.lchild;
                else if (x > p.info)
                    p = p.rchild;
                else
                    return true;
            }
            return false;
        }

        public void delete(int x)
        {
            root = delete(root, x);
        }

        private Node delete(Node p,int x)
        {
            Node ch, s;

            if (p == null)
            {
                Console.WriteLine(x + " not found");
                return p;
            }
            if (x < p.info)
                p.lchild = delete(p.lchild, x);
            else if (x > p.info)
                p.rchild = delete(p.rchild, x);
            else
            {
                //key to be deleted is found
                if(p.lchild!=null && p.rchild != null)//2 children
                {
                    s = p.rchild;
                    while (s.lchild != null)
                        s = s.lchild;
                    p.info = s.info;
                    p.rchild = delete(p.rchild, s.info);
                }
                else // 1 child or no child
                {
                    if (p.lchild != null)//only child 
                        ch = p.lchild;
                    else                //only right child or no child
                        ch = p.rchild;
                    p = ch;
                   
                }
               
            }
            return p;
        }
        public void delete_1(int x)
        {
            Node p = root;
            Node param = null;

            while (p != null)
            {
                if (x == p.info)
                    break;
                param = p;
                if (x < p.info)
                    p = p.lchild;
                else
                    p = p.rchild;

            }
            if (p == null)
            {
                Console.WriteLine(x + " not found");
                return;
            }

            Node s, ps; 
            if(p.lchild!=null && p.rchild != null)
            {
                ps = p;
                s = p.rchild;
                while (s.lchild != null)
                {
                    ps = s;
                    s = s.lchild; 
                }
                p.info = s.info;
                p = s;
                param = ps;
            }

            Node ch;
            if (p.lchild != null)
                ch = p.lchild;
            else
                ch = p.rchild;
            if (param == null)
                root = ch;
            else if (p == param.lchild)
                param.lchild = ch;
            else
                param.rchild = ch;


        }
        public int min()
        {
            if (isEmpty())
                throw new InvalidOperationException("Treeis empty");
            return min(root).info;
        }

        private Node min(Node p)
        {
            if (p.lchild == null)
                return p;
            return min(p.lchild);

        }
        public int max()
        {
            if (isEmpty())
                throw new InvalidOperationException("Tree is empty");
            return max(root).info;
        }
        private Node max(Node p)
        {
            if (p.rchild == null)
                return p;
            return max(p.rchild);

        }

        public int min_1()
        {
            if (isEmpty())
                throw new InvalidOperationException("Tree is empty");
            Node p = root;
            while (p.lchild != null)
                p = p.lchild;
            return p.info;
        }

        public int max_1()
        {
            if (isEmpty())
                throw new InvalidOperationException("Tree is empty");
            Node p = root;
            while (p.rchild != null)
                p = p.rchild;
            return p.info; 
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

            for (i = 0; i < level; i++)
                Console.Write("   ");
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

        public int height()
        {
            return height(root);
        }

        private int height(Node p)
        {
            int hl, hr;

            if (p == null)
                return 0;

            hl = height(p.lchild);
            hr = height(p.rchild);

            if (hl > hr)
                return 1 + hl;
            else
                return 1 + hr;
        }
    }
}
