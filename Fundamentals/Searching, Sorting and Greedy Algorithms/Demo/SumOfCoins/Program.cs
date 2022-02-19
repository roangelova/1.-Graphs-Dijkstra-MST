using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCoins
{
    class Program
    {
        static void Main(string[] args)
        {

            var coins = new Queue<int>(Console.ReadLine().Split(", ")
                .Select(int.Parse)
                .OrderByDescending(x => x));

            var target = int.Parse(Console.ReadLine());
            var selectedCoins = new Dictionary<int, int>();
            var totalCoints = 0;

            while (target > 0 && coins.Count > 0)
            {
                var current = coins.Dequeue();
                var count = target / current;

                if (count == 0)
                {
                    continue;
                }

                selectedCoins[current] = count;
                totalCoints += count;
                target %= current;
            }

            if (target == 0)
            {
                Console.WriteLine($"Number of coins to take: {totalCoints}");

                foreach (var coin in selectedCoins)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }


        }
    }
}
