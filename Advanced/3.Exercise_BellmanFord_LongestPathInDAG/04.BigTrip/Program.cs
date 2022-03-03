﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_BellmanFord_LongestPathInDAG
{

    public class Edge
    {

        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            var graph = new List<Edge>[nodes + 1];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var edge = new Edge { From = edgeData[0], To = edgeData[1] , Weight = edgeData[2]};

                graph[edge.From].Add(edge);
            }


            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distance = new double[graph.Length];
            var prev = new int[graph.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                distance[i] = double.NegativeInfinity;
                prev[i] = -1;
            }

            distance[source] = 0;

            var sorted = TopologicalSort(graph);

            while (sorted.Count > 0)
            {
                var node = sorted.Pop();

                foreach (var edge in graph[node])
                {
                    var newDistance = distance[node] + edge.Weight;
                    if (newDistance > distance[edge.To])
                    {
                        distance[edge.To] = newDistance;
                        prev[edge.To] = node;
                    }
                }
            }

            Console.WriteLine(distance[destination]);

            var path = new Stack<int>();
            var currentNode = destination;
            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = prev[currentNode];
            }

            Console.WriteLine(String.Join(" ", path));
            
        }

        private static Stack<int> TopologicalSort(List<Edge>[] graph)
        {
            var result = new Stack<int>();

            var visited = new bool[graph.Length];

            for (int node = 1; node < graph.Length; node++)
            {
                DFS(node,graph,  result, visited);
            }

            return result;
        }

        private static void DFS(int node, List<Edge>[] graph ,Stack<int> result, bool[] visited)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var edge in graph[node])
            {
                DFS(edge.To, graph, result, visited);
            }

            result.Push(node);
        }
    }
}