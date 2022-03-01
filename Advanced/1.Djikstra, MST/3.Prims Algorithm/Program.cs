using System;
using Wintellect.PowerCollections;

namespace GraphsDijkstra_MST
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    internal class Program
    {
        private static Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();
        private static HashSet<int> forestNodes = new HashSet<int>();
        private static List<Edge> forestEdges = new List<Edge>();

        static void Main(string[] args)
        {
            var edges = int.Parse(Console.ReadLine());

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeData[0];
                var secondNode = edgeData[1];

                if (!graph.ContainsKey(firstNode))
                {
                    graph.Add(firstNode, new List<Edge>());
                }

                if (!graph.ContainsKey(secondNode))
                {
                    graph.Add(secondNode, new List<Edge>());
                }

                var edge = new Edge() { First = firstNode, Second = secondNode, Weight = edgeData[2] };

                graph[firstNode].Add(edge); 
                graph[secondNode].Add(edge);

            }

            foreach (var node in graph.Keys)
            {
                if (!forestNodes.Contains(node))
                {
                    Prim(node);
                }
            }

            foreach (var edge in forestEdges)
            {
                Console.WriteLine($"{edge.First} - {edge.Second}");
            }
        }

        private static void Prim(int node)
        {
            forestNodes.Add(node);

            var bag = new OrderedBag<Edge>(
                Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            bag.AddMany(graph[node]);

            while (bag.Count > 0)
            {
                var minEdge = bag.RemoveFirst();

                var nonTreeNode = -1;

                if (forestNodes.Contains(minEdge.First)
                     && !forestNodes.Contains(minEdge.Second))
                { 
                    nonTreeNode = minEdge.Second;   
                    
                }

                if (!forestNodes.Contains(minEdge.First)
                     && forestNodes.Contains(minEdge.Second))
                {
                    nonTreeNode = minEdge.First;
                }

                if (nonTreeNode == -1)
                {
                    continue;
                }

                forestNodes.Add(nonTreeNode);
                forestEdges.Add(minEdge);   
                bag.AddMany(graph[nonTreeNode]);
            }
        }
    }
}