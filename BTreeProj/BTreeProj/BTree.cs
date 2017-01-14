using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeProj
{
    class BTree
    {
        private Node root;
        private static readonly int M = 5;
        private static readonly int MAX = M - 1;
        private static readonly int MIN = (int)Math.Ceiling((double)M / 2)-1;

        

        public BTree()
        {
            root = null;
        }

        public bool Search(int x)
        {
            if (Search(x, root) == null)
                return false;
            return true;
        }

        public void insert(int x)
        {
            int iKey = 0;
            Node iKeyRchild = null;

            bool taller = insert(x, root, ref iKey, ref iKeyRchild);

            if (taller)// Height increased by one, new root node has to be created
            {
                Node temp = new Node(M);
                temp.child[0] = root;
                root = temp;

                root.numKeys = 1;
                root.key[1] = iKey;
                root.child[1] = iKeyRchild;
            }
        }

        private bool insert(int x, Node p, ref int iKey, ref Node iKeyRchild)
        {
            if (p == null) //First Base case : key not found 
            {
                iKey = x;
                iKeyRchild = null;
                return true;
            }

            int n = 0;
            if (SearchNode(x, p, ref n) == true) // second base case: key found
            {
                Console.WriteLine("Key already present in the tree");
                return false; // no need to insert the key
            }

            bool flag = insert(x, p.child[n], ref iKey, ref iKeyRchild);

            if (flag == true)
            {
                if (p.numKeys < MAX)
                {
                    InsertByShift(p, n, iKey, iKeyRchild);
                    return false; // insertion over
                }
                else
                {
                    split(p, n, ref iKey, ref iKeyRchild);
                    return true; // insertion not over: Median key yet to inserted
                }
            }
            return false;
        }

        private void InsertByShift(Node p, int n, int iKey, Node iKeyRchild)
        {
            for (int i = p.numKeys; i > n; i--)
            {
                p.key[i + 1] = p.key[i];
                p.child[i + 1] = p.child[i];
            }

            p.key[n + 1] = iKey;
            p.child[n + 1] = iKeyRchild;
            p.numKeys++;

        }

        private void split(Node p, int n, ref int iKey, ref Node iKeyRchild)
        {
            int i, j;
            int lastKey;
            Node lastChild;

            if (n == MAX)
            {
                lastKey = iKey;
                lastChild = iKeyRchild;
            }
            else
            {
                lastKey = p.key[MAX];
                lastChild = p.child[MAX];

                for (i = p.numKeys - 1; i > n; i--)
                {
                    p.key[i + 1] = p.key[i];
                    p.child[i + 1] = p.child[i];
                }

                p.key[i + 1] = iKey;
                p.child[i + 1] = iKeyRchild;
            }

            int d = (M + 1) / 2;
            int medianKey = p.key[d];
            Node newNode = new Node(M);
            newNode.numKeys = M - d;

            newNode.child[0] = p.child[d];
            for (i = 1, j = d + 1; j <= MAX; i++, j++)
            {
                newNode.key[i] = p.key[j];
                newNode.child[i] = p.child[j];
            }
            newNode.key[i] = lastKey;
            newNode.child[i] = lastChild;

            p.numKeys = d - 1;
            iKey = medianKey;
            iKeyRchild = newNode;
        }

        private Node Search(int x, Node p)
        {
            if (p == null) //key x not present in the tree
                return null;

            int n = 0;
            if (SearchNode(x, p, ref n) == true) //key x not found in node p;
                return p;

            return Search(x, p.child[n]); //Search in node p.child            
        }

        private bool SearchNode(int x, Node p, ref int n)
        {
            if (x < p.key[1]) // key x is less than left most element
            {
                n = 0;
            }

            n = p.numKeys;
            while ((x < p.key[n]) && n > 1)
                n--;

            if (x == p.key[n])
                return true;
            else
                return false;

        }

        public void Inorder()
        {
            Inorder(root);
        }

        private void Inorder(Node p)
        {
            
            if (p == null)
            {
                return;
            }
               
           int i;
            for (i = 0; i < p.numKeys; i++)
            {
                Inorder(p.child[i]);
                Console.Write(p.key[i+1] + " ");
            }
           Inorder(p.child[i]);
        }

        public void display()
        {
            display(root, 0);
        }

        private void display(Node p, int blanks)
        {
            if (p != null)
            {
                int i;
                for (i = 1; i <= blanks; i++)
                    Console.Write(" ");

                for (i = 1; i <= p.numKeys; i++)
                    Console.Write(p.key[i] + " ");
                Console.Write("\n");

                for (i = 0; i <= p.numKeys; i++)
                    display(p.child[i], blanks + 10);
            }
        }

        public void delete(int x)
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }

            delete(x, root);

            if (root != null && root.numKeys == 0) //height of tree decreased by 1 
                root = root.child[0];
        }

        private void delete(int x, Node p) //Key x found in node p
        {
            int n = 0;

            if (SearchNode(x, p, ref n) == true)
            {
                if (p.child[n] == null) //node leaf
                {
                    DeleteByShift(p, n);
                    return;
                }
                else // Node p is a non-leaf
                {
                    Node s = p.child[n];
                    while (s.child[0] != null)
                        s = s.child[0];
                    p.key[n] = s.key[1];
                    delete(s.key[1], p.child[n]);
                }
            }
            else
            {
                if (p.child[n] == null)
                {
                    Console.WriteLine("Value " + x + " not present in the tree");
                    return;
                }
                else
                    delete(x, p.child[n]);
            }
            if (p.child[n].numKeys < MIN)
                Restore(p, n);
        }
        private void DeleteByShift(Node p, int n)
        {
            for (int i = n + 1; i <= p.numKeys; i++)
            {
                p.key[i - 1] = p.key[i];
                p.child[i - 1] = p.child[i];
            }
            p.numKeys--;
        }

        private void Restore(Node p, int n)// call wher p.Child[n] becomes underflow
        {
            if (n != 00 && p.child[n + 1].numKeys > MIN)
            {
                BorrowLeft(p, n);
            }
            else if (n != p.numKeys && p.child[n + 1].numKeys > MIN)
            {
                BorrowRight(p, n);
            }
            else
            {
                if (n != 0) //left sibling
                    Combine(p, n);
                else
                    Combine(p, n + 1);//right sibling
            }
        }

        private void BorrowLeft(Node p, int n)
        {
            Node underflow = p.child[n];
            Node leftSib = p.child[n - 1];

            underflow.numKeys++;

            //shift ass the key and children in underflow one position right
            for(int i=underflow.numKeys; i > 0; i--)
            {
                underflow.key[i + 1] = underflow.key[i];
                underflow.child[i + 1] = underflow.child[i];
            }

            //move the sepereator key from parent node p to underflow
            underflow.child[1] = underflow.child[0];

            //move righmost ket of node leftsibling to the parent node p
            p.key[n] = leftSib.key[leftSib.numKeys];
            leftSib.numKeys--;
        }

        private void BorrowRight(Node p, int n)
        {
            Node underflow=p.child[n];
            Node rightSib = p.child[n + 1];

            underflow.numKeys++;
            underflow.key[underflow.numKeys] = p.key[n + 1];

            underflow.child[underflow.numKeys] = rightSib.child[0];

            rightSib.numKeys--;

            p.key[n + 1] = rightSib.key[1];
            rightSib.child[0] = rightSib.child[1];
            for(int i=1; i <= rightSib.numKeys; i++)
            {
                rightSib.key[i] = rightSib.key[i + 1];
                rightSib.child[i] = rightSib.child[i + 1];
            }
        }

        private void Combine(Node p, int m)
        {
            Node A = p.child[m - 1];
            Node B = p.child[m];
 
            A.numKeys++;
            //Move the separator key from the parent node p to A
            A.key[A.numKeys] = p.key[m];

            //Shift the keys and children that are after separator key in node p one pos left

            for(int i=m; i<p.numKeys; i++)
            {
                p.key[i] = p.key[i + 1];
                p.child[i] = p.child[i + 1]; 
            }
            p.numKeys--;

            //leftmost child of B becomes rightmost child of A 
            A.child[A.numKeys] = B.child[0];

            //insert all keys and children of B at the end of A
            for(int i=1; i < B.numKeys; i++)
            {
                A.numKeys++;
                A.key[A.numKeys] = B.key[i];
                A.child[A.numKeys] = B.child[i];
            }
        }


    }
    
}
