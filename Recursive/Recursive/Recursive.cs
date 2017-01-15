using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    public class Recursive 
    {
        int n { get; set; }

     

        public int fact(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * fact(n - 1); 

        }

        public int sum(int n)
        {
            if (n == 0)
                return 0;
            else
                return n + sum(n - 1);
        }

        public int sum_int(int n)
        {

            if (n == 0)
                return 0;
            else
                return n % 10 + sum_int(n / 10);

        }
        public void count(int n)
        {
           
            if (n == 0)
                return;
            else
                Console.Write( + n + ", ");
                count(n - 1); 
                
        }
        public void countRev(int n)
        {

            if (n == 0)
                return;
            else
                countRev(n - 1);
                Console.Write(+n + ", ");
        }
        public void binary(int n)
        {
            if (n == 0)
                return;
            else
                binary(n / 2);
            Console.Write(n % 2 + "");
         }
        
        public float power(int x, int n)
        {
            if (n == 0)
                return 1;
            else
                return x * power(x, n - 1);
        }

        public int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return GCD(b, a % b);
        }

        public int fib(int n)
        {
            if (n==0)
                return 0;
            if (n == 1)
                return 1;
            else
                return fib(n - 1) + fib(n - 2);
        }



    }
}
