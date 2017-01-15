using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    class Program
    {
        static void Main(string[] args)
        {
           Recursive f = new Recursive();
            int n,fact_1, sum,sumInt,k,x,y,a,b, fibo;

            Console.Write("Enter a number: ");
            n = Convert.ToInt32(Console.ReadLine());
            fact_1 = f.fact(n);
            sum = f.sum(n);
            sumInt = f.sum_int(123459874);

            Console.Write("Enter a number to countdown from: ");
            k = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter a base number: ");
            x= Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter a power number: ");
            y= Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter a number for A: ");
            a= Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter a number for B: ");
            b= Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter a number for Fibonacci Series: ");
            fibo = Convert.ToInt32(Console.ReadLine());



            Console.WriteLine("\nThe factorial of " + n + " is: " + fact_1);
            Console.WriteLine("\nThe Sum of " + n + " is: " + sum);
            Console.WriteLine("\nThe Sum of " + n + " is: " + sumInt);
            Console.Write("\n\nCountdown from: ");
            f.count(k);
            Console.Write("\n\nCounting to: ");
            f.countRev(k);

            Console.Write("\nBinary number of "+k+" is: ");
            f.binary(k);

            Console.Write("\n" + k + " to the power of" +" is: " + f.power(x, y));

            Console.Write("\n\nThe greatest common denumerator is: " + f.GCD(a, b));
            Console.Write("\n\nFibonacci number sequence of " +fibo+" is: " );

            for(int start=0; start<=fibo; start++)
            {
                Console.Write(f.fib(start) + " ");
            }

            Console.ReadKey();
        }
    }
}
