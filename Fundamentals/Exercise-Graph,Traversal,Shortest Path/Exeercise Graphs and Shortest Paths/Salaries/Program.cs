using System;
using System.Collections.Generic;
using System.Linq;

namespace Salaries
{
    class Program
    {
        private static List<int>[] graph;
        private static int node;
        private static Dictionary<int, int> visited;

        public static void Main(string[] args)
        {

            var n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            visited = new Dictionary<int, int>();

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();

                var nodeChildren = Console.ReadLine();

                for (int child = 0; child < nodeChildren.Length; child++)
                {
                    if (nodeChildren[child] == 'Y')
                    {
                        graph[node].Add(child);
                    }
                }
            }

            var salary = 0;
            for (node = 0; node < graph.Length; node++)
            {
               salary += DFS(node);

            }
            Console.WriteLine(salary);
        }

        private static int DFS(int node)
        {

            if (visited.ContainsKey(node))
            {
                return visited[node];
            }

            var salary = 0;
            if (graph[node].Count == 0)
            {
                salary = 1;
            }
            else
            {
                foreach (var child in graph[node])
                {
                    salary += DFS(child);
                }
            }
            visited[node] = salary;

            return salary;
        }
    }
}
