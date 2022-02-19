using System;
using System.Collections.Generic;
using System.Linq;

namespace VariationsWITHRepetiton
{
    class Program
    {

        private static string[] nums;
        private static string[] variations;
        private static int k;
        private static HashSet<string> used;
        static void Main(string[] args)
        {
            nums = Console.ReadLine().Split().ToArray();
            k = int.Parse(Console.ReadLine());

            variations = new string[k];
            used = new HashSet<string>();

            Variations(0);
        }

        private static void Variations(int idx)
        {
            if (idx >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (!used.Contains(nums[i]))
                {
                    used.Add(nums[i]);
                    variations[idx] = nums[i];
                    Variations(idx + 1);
                    used.Remove(nums[i]);
                }

            }
        }
    }
}
