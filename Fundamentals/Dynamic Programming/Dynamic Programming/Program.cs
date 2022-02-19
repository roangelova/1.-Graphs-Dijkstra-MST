using System;
using System.Collections.Generic;

namespace Fibonacci
{
    class Program
    {
        private static Dictionary<int, long> cache = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            //recursive approach
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFib(n));


        }

        private static long CalcFib(int n)
        {

            if (cache.ContainsKey(n))
            {
                //veche imame rezultata
                return cache[n];
            }

            if (n <2)
            {
                return n;
            }
            

            // vurni predishnoto i po-predishnoto i mi gi suberi
            //purvo vloazme v CalcFib(n - 1) 
            var result =  CalcFib(n - 1) + CalcFib(n - 2);
            cache[n] = result;

            return result;
        }
    }
}
