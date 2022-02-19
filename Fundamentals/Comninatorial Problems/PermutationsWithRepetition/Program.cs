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



            GenPermutations(0, elements);

        }

        private static void GenPermutations(int idx, string[] elements)
        {
            if (idx >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }


            GenPermutations(idx + 1, elements);
            var used = new HashSet<string> { elements[idx] };

            for (int i = idx + 1; i < elements.Length; i++)
            {

                if (!used.Contains(elements[i]))
                {
                    Swap(idx, i, elements);
                    GenPermutations(idx + 1, elements);
                    Swap(idx, i, elements);

                    used.Add(elements[i]);
                }

            }
        }

        private static void Swap(int first, int second, string[] elements)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
