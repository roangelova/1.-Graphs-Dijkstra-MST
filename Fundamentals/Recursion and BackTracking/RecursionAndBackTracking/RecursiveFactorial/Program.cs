using System;
using System.Linq;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFactRecur(n));



        }

        private static int CalcFactRecur(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * CalcFactRecur(n - 1);

        }
    }
}
