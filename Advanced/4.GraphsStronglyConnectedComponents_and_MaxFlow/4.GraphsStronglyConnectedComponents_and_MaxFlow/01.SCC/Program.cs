using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphsStronglyConnectedComponents_and_MaxFlow
{

    public class Edge
    {

        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    //using Kosaraju-Sharir's algorithm.
    internal class Program
    {
        static void Main(string[] args)
        { 
            var nodes = int.Parse(Console.ReadLine());
            var lines = int.Parse(Console.ReadLine());

            var graph = new List<int>[nodes];
            var reversedGraph = new List<int>[nodes];    

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
                reversedGraph[i] = new List<int>();
            }

            for (int i = 0; i < lines; i++)
            { 
                var line = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                var node = line[0];

                for (int j = 1; j < line.Length; j++)
                {
                    var child = line[j];

                    graph[node].Add(child);
                    reversedGraph[child].Add(node);
                }

            }

            var visited = new bool[graph.Length];
            var sorted =new Stack<int>();   

            for (int node = 0; node < graph.Length; node++)
            {
                DFS(node, graph, visited, sorted);
            }

            visited = new bool[reversedGraph.Length];

            Console.WriteLine("Strongly Connected Components:");
            while (sorted.Count > 0)
            {
                var node = sorted.Pop();

                var component = new Stack<int>();

                if (visited[node])
                {
                    continue;
                }

                DFS(node, reversedGraph, visited, component);

                Console.WriteLine($"{{{String.Join(", ", component)}}}");
            }


        }

        private static void DFS(int node, List<int>[] graph, bool[] visited, Stack<int> result)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, graph, visited, result);
            }

            result.Push(node);
        }
    }
}

//Example input and output

//14
//13
//0, 1, 11, 13
//1, 6
//2, 0
//3, 4
//4, 3, 6
//5, 13
//6, 0, 11
//7, 12
//8, 6, 11
//9, 0
//10, 4, 6, 10
//12, 7
//13, 2, 9
//Output:
//
//Strongly Connected Components:
//{ 10}
//{ 8}
//{ 7, 12}
//{ 5}
//{ 3, 4}
//{ 0, 9, 6, 1, 2, 13}
//{ 11}
