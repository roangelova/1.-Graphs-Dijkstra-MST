using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph_Theory__Traversal_and_Shortest_Path
{
    class Program
    {
        //01. Connected Components 

        private static List<int>[] graph;
        private static bool[] visited;

       public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            visited = new bool[n];


            for (int node = 0; node < n; node++)
            {
                //each line represents the children
                var line = Console.ReadLine();

                //if the line is empty, there are no children
                if (string.IsNullOrEmpty(line))
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    var children = line.Split().Select(int.Parse).ToList();
                    graph[node] = children;
                }
            }


            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                {
                    continue;
                }

                var component = new List<int>();
                DFS(node, component);

                Console.WriteLine($"Connected component: {string.Join(" ", component)}");
            }



        }

        private static void DFS(int node, List<int> component)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, component);
            }


            component.Add(node);

        }
    }
}
