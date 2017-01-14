using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree
{
    class AVL_Tree
    {
        private Node root;

        static bool taller;
        static bool shorter; 

        public AVL_Tree()
        {
            root = null;
        }

        public bool isEmpty()
        {
            return (root == null);
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
            Console.Write("\n");

            for (i = 0; i < level; i++)
                Console.Write("   ");
            Console.Write(p.info);
            display(p.lchild, level + 1);


        }

        public void inOrder()
        {
            inOrder(root);
            Console.WriteLine();
        }

        private void inOrder(Node p)
        {
            if (p == null)
                return;
            inOrder(p.lchild);
            Console.Write(p.info + " ");
            inOrder(p.rchild);
        }

        public void Insert(int x)
        {
            root = Insert(root, x);
        }

        private Node Insert(Node p, int x)
        {
            if (p == null)
            {
                p = new Node(x);
                taller = true;
            }
            else if (x < p.info)
            {
                
                p.lchild = Insert(p.lchild, x);
                if (taller == true)
                    p = InsertionLeftSubtreeCheck(p);
            }
            else if (x > p.info)
            {
                p.rchild = Insert(p.rchild, x);
                if(taller==true)
                    p = InsertionRightSubtreeCheck(p);
            }
            else
            {
                Console.WriteLine(x + " already present in tree");
                taller = false;
            }
            return p; 

        }

        public void delete(int x)
        {
            root = delete(root, x);
        }
        private Node delete(Node p, int x)
        {
            Node ch, s;
            if (p == null)
            {
                Console.WriteLine(x + " not found");
                shorter = false;
                return p; 
            }
            if(x<p.info)//delete from left subtree
            {
                p.lchild = delete(p.lchild, x);
                if (shorter == true)
                    p = DeletionLeftSubtreeCheck(p);
            }
            else if(x>p.info)// delete from right subtree
            {
                p.rchild = delete(p.rchild, x);
                if (shorter == true)
                    p = DeletionRightSubtreeCheck(p);
            }
            else
            {
                //key to be deleted is found
                if(p.lchild!=null && p.rchild!=null) // 2 children
                {
                    s = p.rchild;
                    while (s.lchild != null)
                        s = s.lchild;
                    p.info = s.info;
                    p.rchild = delete(p.rchild, s.info);
                    if (shorter == true)
                        p = DeletionRightSubtreeCheck(p);
                }
                else //1 child or no child
                {
                    if (p.lchild != null) //only left child 
                        ch = p.lchild;
                    else //only right child or no child
                        ch = p.lchild;
                    p = ch;
                    shorter = true; ;
                }
            }
            return p;

        }

        private Node DeletionLeftSubtreeCheck(Node p)
        {
            switch (p.balance)
            {
                case 0: //balanced 
                    p.balance = -1; //now right heavy
                    shorter = false;
                    break;
                case 1: // was left heavy 
                    p.balance = 0; //now balanced
                    break;
                case -1: // was right heavy
                    p = DeletionRightBalance(p);
                    break;

            }
            return p;
        }

        private Node InsertionLeftSubtreeCheck(Node p)
        {
            switch (p.balance)
            {
                case 0: //was balanced 
                    p.balance = 0; //now left balanced
                    break;
                case -1: // was right heavy
                    p.balance = 0;
                    taller = false;
                    break;
                case 1:
                    p = InsertionLeftBalance(p); //left balancing
                    taller = false;
                    break;
            }
            return p;
        }

        private Node DeletionRightSubtreeCheck(Node p)
        {
            switch (p.balance)
            {
                case 0:
                    p.balance = 1;
                    shorter = false;
                    break;
                case -1:
                    p.balance = 0;
                    break;
                case 1:
                    p = DeletionLeftBalance(p);
                    break;
            }
            return p; 

        }

        private Node DeletionRightBalance(Node p)
        {
            Node a, b;

            a = p.rchild;
            if (a.balance == 0)
            {
                a.balance = 1;
                shorter = false;
                p = RotateLeft(p);
            }
            else if (a.balance == -1)
            {
                p.balance = 0;
                a.balance = 0;
                p = RotateLeft(p);
            }
            else
            {
                b = a.lchild;
                switch (b.balance)
                {
                    case 0:
                        p.balance = 0;
                        a.balance = 0;
                        break;
                    case 1:
                        p.balance = 0;
                        a.balance = -1;
                        break;
                    case -1:
                        p.balance = 1;
                        a.balance = 0;
                        break;
                }
                b.balance = 0;
                p.rchild = RotateRight(a);
                p = RotateLeft(p);

            }
            return p;
        }

        private Node DeletionLeftBalance(Node p)
        {
            Node a, b;
            a = p.lchild;
            if (a.balance == 0)
            {
                a.balance = -1;
                shorter = false;
                p = RotateRight(p);
            }
            else if (a.balance == 1)
            {
                p.balance = 0;
                a.balance = 0;
                p = RotateRight(p); 
            }
            else
            {
                b = a.rchild;
                switch (b.balance)
                {
                    case 0:
                        p.balance = 0;
                        a.balance = 0;
                        break;
                    case -1:
                        p.balance = 0;
                        a.balance = 1;
                        break;
                    case 1:
                        p.balance = -1;
                        a.balance = 0;
                        break;
                }
                b.balance = 0;
                p.lchild = RotateLeft(a);
                p = RotateRight(p);
            }
            return p;
        }

        private Node InsertionRightSubtreeCheck(Node p)
        {
            switch (p.balance)
            {
                case 0: //was balanced 
                    p.balance = -1; //now right balanced
                    break;
                case 1: // was left heavy
                    p.balance = 0;
                    taller = false;
                    break;
                case -1:
                    p = InsertionRightBalance(p); //right balancing
                    taller = false;
                    break;
            }
            return p;
        }

        private Node InsertionLeftBalance(Node p)
        {
            Node a;
            Node b;
            a = p.rchild;
           
            if(a.balance== 1)
            {
                p.balance = 0;
                a.balance = 0;
                p = RotateRight(p);
            }
            else
            {
                b = a.rchild;
                switch (b.balance)
                {
                    case 1: //insertion in Balance Left
                        p.balance = -1;
                        a.balance = 0;
                        break;
                    case -1: //insertion in Balance right
                        p.balance = 0;
                        a.balance = 1;
                        break;
                    case 0: //insertion in in newly node
                        p.balance = 0;
                        a.balance = 1;
                        break;


                }
                b.balance = 0;
                p.lchild = RotateLeft(a);
                p = RotateRight(p);
            }

            return p;

        }

        private Node InsertionRightBalance(Node p)
        {
            Node a, b;
            a = p.rchild;
            if (a.balance == -1) 
            {
                p.balance = 0;
                a.balance = 0;
                p = RotateLeft(p); 
            }
            else
            {
                b = a.lchild;
                switch (b.balance)
                {
                    case -1:
                        p.balance = 1;
                        a.balance = 0;
                        break;
                    case 1:
                        p.balance = 0;
                        a.balance = -1;
                        break;
                    case 0:
                        p.balance = 0;
                        a.balance = 0;
                        break; 
                }
                b.balance = 0;
                p.rchild = RotateRight(a);
                p = RotateLeft(p); 
            }
            return p;  
        }

        private Node RotateRight(Node p)
        {
            Node a = p.lchild;
            p.lchild = a.rchild;
            a.rchild = p;
            return a;
        }

        private Node RotateLeft(Node p)
        {
            Node a = p.rchild;
            p.rchild = a.lchild;
            a.lchild = p;
            return a;
        }
    }
}
