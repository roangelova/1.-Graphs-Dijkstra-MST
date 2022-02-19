using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            //recursive approach
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFib(n));

        }

        private static long CalcFib(int n)
        {

            if (n <= 1)
            {
                return 1;
            }
           
            return CalcFib(n - 1) + CalcFib(n - 2);

        }
    }
}