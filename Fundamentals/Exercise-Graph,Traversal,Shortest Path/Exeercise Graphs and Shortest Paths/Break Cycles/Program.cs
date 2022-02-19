using System;
using System.Collections.Generic;
using System.Linq;

namespace Break_Cycles
{
    class Program
    {
        static void Main(string[] args)
        {


            var elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var permutations = new string[elements.Length];
            var used = new bool[elements.Length];

            GenPermutations(0, elements, permutations, used);

        }

        private static void GenPermutations(int idx, string[] elements, string[] permutations, bool[] used)
        {
            if (idx >= permutations.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }



            for (int i = 0; i < elements.Length; i++)
            {

                if (!used[idx])
                {
                    permutations[idx] = elements[i];
                    used[i] = true;
                    GenPermutations(idx + 1, elements, permutations, used);
                    used[i] = false;
                }

            }
        }
    }
}
