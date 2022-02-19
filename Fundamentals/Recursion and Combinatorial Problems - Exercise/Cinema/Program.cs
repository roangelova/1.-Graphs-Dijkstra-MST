using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema
{
    class Program
    {


        private static List<string> nonStaticPeople;
        private static string[] people; //permutations
        private static bool[] locked;



        static void Main(string[] args)
        {
            nonStaticPeople = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .ToList();
            people = new string[nonStaticPeople.Count];
            locked = new bool[nonStaticPeople.Count];


            while (true)
            {
                var line = Console.ReadLine();

                if (line == "generate")
                {
                    break;
                }

                var parts = line.Split(" - ");
                var name = parts[0];
                var position = int.Parse(parts[1]) - 1;

                people[position] = name;
                locked[position] = true;
                nonStaticPeople.Remove(name);
            }

            Permute(0);

        }

        private static void Permute(int idx)
        {

            if (idx >= nonStaticPeople.Count)
            {
                PrintPermitation();
                return;
            }


            Permute(idx + 1);

            for (int i = idx + 1; i < nonStaticPeople.Count; i++)
            {
                Swap(idx, i);
                Permute(idx + 1);
                Swap(idx, i);

            }

        }

        private static void PrintPermitation()
        {
            var peopleIdx = 0;
            for (int i = 0; i < people.Length; i++)
            {
                if (i == people.Length - 1)
                {
                    if (locked[i])
                    {
                        Console.Write($"{people[i]}");
                    }
                    else
                    {
                        Console.Write($"{nonStaticPeople[peopleIdx++]}");
                    }
                }
                else
                {
                    if (locked[i])
                    {
                        Console.Write($"{people[i]} ");
                    }
                    else
                    {
                        Console.Write($"{nonStaticPeople[peopleIdx++]} ");
                    }
                }
            }

            Console.WriteLine();
        }

        private static void Swap(int first, int second)
        {
            var temp = nonStaticPeople[first];
            nonStaticPeople[first] = nonStaticPeople[second];
            nonStaticPeople[second] = temp;

        }
    }
}
