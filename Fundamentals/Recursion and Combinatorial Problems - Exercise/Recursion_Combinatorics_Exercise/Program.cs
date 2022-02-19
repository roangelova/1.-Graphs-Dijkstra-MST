using System;
using System.Linq;

namespace Recursion_Combinatorics_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 2 3 4
            var elements = Console.ReadLine().Split()
                 .Select(int.Parse)
                 .ToArray();
            Reverse(elements, 0);
            Console.WriteLine(string.Join(" ", elements));
            // 4 3 2 1
        }

        private static void Reverse(int[] elements, int index)
        {
            if (index == elements.Length / 2)
            {
                return;
            }


            var temp = elements[index];
            elements[index] = elements[elements.Length - index - 1];
            elements[elements.Length - index - 1] = temp;

            Reverse(elements, index + 1);

        }
    }
}
