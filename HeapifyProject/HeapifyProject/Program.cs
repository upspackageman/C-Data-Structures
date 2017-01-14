using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapifyProject
{
    class Program
    {
        public static void buildHeap_topDown(int[] a, int n)
        {
            for (int i = 2; i <= n; i++)
                restoreUp(i, a);
        }
        public static void buildHeap_bottomUp(int[] a, int n)
        {
            for (int i = n / 2; i >= 1; i--)
                restoreDown(i, a, n);
        }
        private static void restoreUp(int i, int[] a)
        {
            int k = a[i];
            int iparent = i / 2;

            while (a[iparent] < k)
            {
                a[i] = a[iparent];
                i = iparent;
                iparent = i / 2;
            }
            a[i] = k;
        }

        private static void restoreDown(int i, int[] a,int n)
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
            if(lchild==n && k < a[lchild])
            {
                a[i] = a[lchild];
                i = lchild;
            }
            a[i]= k;
        }
        static void Main(string[] args)
        {
            int[] a1 = { 99999, 1, 4, 5, 7, 9, 10 };
            int n1 = a1.Length - 1;

            buildHeap_bottomUp(a1, n1);

            for(int i =1; i < n1; i++)
            {
                Console.Write(a1[i] + " ");
            }
            Console.WriteLine("\n");

            int[] a2 = { 99999, 1, 4, 5, 7, 9, 10 };
            int n2 = a2.Length - 1;

            buildHeap_topDown(a2, n2);

            for (int k = 1; k < n2; k++)
            {
                Console.Write(a2[k] + " ");
            }
            Console.WriteLine("\n");

            Console.ReadKey();


        }
    }
}
