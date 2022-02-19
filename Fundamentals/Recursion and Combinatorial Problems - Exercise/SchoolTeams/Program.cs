using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTeams
{
    class Program
    {
        static void Main(string[] args)
        {

            var girls = Console.ReadLine().Split(", "); 
            var girlsComb = new string[3];
            var girlsCombs = new List<string[]>();
            //girls number is fixed by default
            GenCombs(0, 0, girls, girlsComb, girlsCombs);

            var boys = Console.ReadLine().Split(", ");
            var boysComb = new string[2];
            var boysCombs = new List<string[]>();

            GenCombs(0, 0, boys, boysComb, boysCombs);

            PrintFinalCombs(girlsCombs, boysCombs);
        }

        private static void PrintFinalCombs(List<string[]> girlsCombs, List<string[]> gboysCombs)
        {
            foreach (var girlComb in girlsCombs)
            {
                foreach (var boyComb in gboysCombs)
                {
                    Console.WriteLine($"{string.Join(", ", girlComb)}, {string.Join(", ",boyComb)}");
                }
            }
        }

        private static void GenCombs(int idx, int start, string[] elements, string[] comb, List<string[]> combs)
        {
            if (idx >= comb.Length)
            {
                combs.Add(comb.ToArray());
                return;
            }


            for (int i = start; i < elements.Length; i++)
            {
                comb[idx] = elements[i];
                GenCombs(idx + 1, i + 1, elements, comb, combs);
            }
        }
    }
}
