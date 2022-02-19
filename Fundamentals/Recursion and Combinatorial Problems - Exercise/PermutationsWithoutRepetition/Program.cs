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

            permitations = new string[elements.Length]; 
            // here we will store our elements

            used = new bool[elements.Length];


            Permute(0); 

        }

        private static void Permute(int idx)
        {
            if (idx >= permitations.Length)
            {
                Console.WriteLine(string.Join(" ", permitations));

                return;
            }


            //[A/B/C][][]

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    permitations[idx] = elements[i];
                    used[i] = true;
                    Permute(idx + 1); 
                    used[i] = false;
                }



            }


        }
    }
}
