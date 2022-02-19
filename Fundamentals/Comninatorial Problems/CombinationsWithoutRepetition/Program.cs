using System;

namespace CombinationsWithoutRepetition
{
    class Program
    {
        private static string[] nums;
        private static string[] combinations;
        private static int k;
        static void Main(string[] args)
        {
            nums = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());

            combinations = new string[k];

            GenCombinations(0, 0);
        }

        private static void GenCombinations(int idx, int elementsStartIndex)
        {
            if (idx >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementsStartIndex; i < nums.Length; i++)
            {
                combinations[idx] = nums[i];
                GenCombinations(idx + 1, i + 1) ;
            }
        }
    }
}
