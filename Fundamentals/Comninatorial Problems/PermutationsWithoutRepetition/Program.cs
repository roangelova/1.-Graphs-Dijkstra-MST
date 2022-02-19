using System;

using System.Linq;

namespace ConsoleApp11
{
    class Program
    {
        private static string[] elements;
        private static string[] permitations;
        private static bool[] used;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();

            permitations = new string[elements.Length]; // here we will store out elements

            used = new bool[elements.Length];


            Permute(0); // we start from the first element 


        }

        private static void Permute(int idx)
        {
            if (idx >= permitations.Length)
            {
                //means that the [] is finished
                Console.WriteLine(string.Join(" ", permitations));

                return;
            }


            //[A/B/C][][]

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    //we won't be able to reuse the same letter; Is some sort of backtracking
                    permitations[idx] = elements[i];
                    used[i] = true;

                    Permute(idx + 1); //we call the func with the next func 

                    //Start reusing the elements for the next permutation, meaning we need to unmark;
                    used[i] = false;
                }



            }


        }
    }
}
