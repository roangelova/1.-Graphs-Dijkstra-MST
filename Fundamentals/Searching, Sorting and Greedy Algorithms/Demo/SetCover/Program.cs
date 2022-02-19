using System;
using System.Collections.Generic;
using System.Linq;

namespace SetCover
{
    class Program
    {
        static void Main(string[] args)
        {

            var universe = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToHashSet();

            var n = int.Parse(Console.ReadLine());

            var sets = new List<int[]>();

            for (int i = 0; i < n; i++)
            {
                var set = Console.ReadLine().Split(", ")
                    .Select(int.Parse).ToArray();

                sets.Add(set);
            }

            var selectredSets = new List<int[]>();
            while (universe.Count > 0)
            {
                var set = sets.OrderByDescending(x => x.Count
                (e => universe.Contains(e))).FirstOrDefault();

                selectredSets.Add(set);
                sets.Remove(set);

                foreach (var element in set)
                {
                    universe.Remove(element);
                }
            }


            Console.WriteLine($"Sets to take ({selectredSets.Count}):");

            foreach (var set in selectredSets)
            {
                Console.WriteLine(string.Join(", ", set));
            }

        }
    }
}
