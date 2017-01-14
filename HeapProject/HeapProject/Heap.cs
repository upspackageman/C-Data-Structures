using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapProject
{
    class Heap
    {
        private int[] a;
        private int n;
        private int max;

        public Heap()
        {
            a = new int[10];
            n = 0;
            a[0] = 99999; 
        }

        public Heap(int maxSize)
        {
            max = maxSize;
            a = new int[max];
            n = 0;
            a[0] = 99999;
        }

        public void insert(int val)
        {
            n++;
            a[n] = val;
            restoreUp(n);
        }
        private void restoreUp(int i)
        {
            int k = a[i];
            int iParent = i / 2;

            while (a[iParent] < k)
            {
                a[i] = a[iParent];
                i = iParent;
                iParent = i / 2;
            }
            a[i] = k;
        }
        public int DeleteRoot()
        {
            if (n == 0)
                Console.WriteLine("heap is empty");

               // throw new System.InvalidOperationException("Heeap is empty");
                
            int maxVal = a[1];
            a[1] = a[n];
            n--;
            restoreDown(1);
            return maxVal;
        }

        private void restoreDown(int i)
        {
            int k = a[i];
            int lchild = 2 * i, rchild = lchild + 1;

            while (rchild <= n)
            {
                if(k>=a[lchild]&& k >= a[rchild])
                {
                    a[i] = k;
                    return;
                }
                else if (a[lchild] > a[rchild])
                {
                    a[i] = a[lchild];
                    i = lchild;
                }
                else
                {
                    a[i] = a[rchild];
                    i = rchild;
                }
                lchild = 2 * i;
                rchild = lchild + 1;
            }
            //if even
            if(lchild==n && k < a[lchild])
            {
                a[i] = a[lchild];
                i = lchild;

            }
            a[i] = k;
        }

        public void display()
        {
            int i = 1;
            while (i<=n)
            {
                Console.Write(a[i] +" ");
                i++;
            }
            Console.WriteLine();
        }
    }
}

