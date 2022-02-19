using System;
using System.Collections.Generic;

namespace WordCrunche
{
    class Program
    {
        private static Dictionary<int, List<string>> wordsByIdx;
        private static Dictionary<string, int> wordsCount;

        private static LinkedList<string> used;

        private static string target;

        static void Main(string[] args)
        {
            //text, me, so, do, m, ran
            //somerandomtext

            var words = Console.ReadLine().Split(", ");
            target = Console.ReadLine();

            wordsByIdx = new Dictionary<int, List<string>>();
            wordsCount = new Dictionary<string, int>();
            used = new LinkedList<string>();

            foreach (var word in words)
            {
                var idx = target.IndexOf(word);
                if (idx == -1)
                {
                    continue;
                }
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                    continue;
                }

                wordsCount[word] = 1;


                while (idx != -1)
                {
                    if (!wordsByIdx.ContainsKey(idx))
                    {
                        wordsByIdx[idx] = new List<string>();
                    }
                    wordsByIdx[idx].Add(word);
                    idx = target.IndexOf(word, idx + 1);
                }

            }
            GenSolutions(0);

        }

        private static void GenSolutions(int idx)
        {
            if (idx == target.Length)
            {
                Console.WriteLine(string.Join(" ", used));
                return;
            }

            if (!wordsByIdx.ContainsKey(idx))
            {
                return;
            }


            foreach (var word in wordsByIdx[idx])
            {
                if (wordsCount[word] == 0)
                {
                    continue;
                }
                wordsCount[word] -= 1; 
                used.AddLast(word);
                GenSolutions(idx + word.Length);
                wordsCount[word] += 1;
                used.RemoveLast();
            }


        }
    }
}
