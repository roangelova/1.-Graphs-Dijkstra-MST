using System;
using System.Linq;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();


            Console.WriteLine(SumRecursively(numbers, 0));

        }

        private static int SumRecursively(int[] numbers, int index)
        {

            //nasheto duno
            if (index == numbers.Length - 1)
            {
                return numbers[index];
            }

            return numbers[index] + SumRecursively(numbers, index + 1);


        }
    }
}