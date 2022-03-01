using System;

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
        private static List<Edge> edges = new List<Edge>();
        private static List<Edge> forest = new List<Edge>();
        private static int[] parent;


        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var maxNode = -1;

            for (int i = 0; i < count; i++)
            {
                var edgesData = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgesData[0];
                var secondNode = edgesData[1];
                var weight = edgesData[2];

                if (firstNode > maxNode)
                {
                    maxNode = firstNode;
                }
                if (secondNode > maxNode) 
                {
                    maxNode = secondNode;
                }

                var edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = weight
                };

                edges.Add(edge);
            }

            var sortedEdges = edges.OrderBy(e => e.Weight).ToArray();
            parent = new int[maxNode + 1];
            for (int node = 0; node < parent.Length; node++)
            {
                parent[node] = node;
            }

            foreach (var edge in sortedEdges)
            {
                var firstNodeRoot = FindRoot(edge.First);
                var secondNodeRoot = FindRoot(edge.Second);

                if (firstNodeRoot == secondNodeRoot)
                {
                    continue;
                }

                parent[firstNodeRoot] = secondNodeRoot;
                forest.Add(edge);
            }

            foreach (Edge edge in forest)
            {
                Console.WriteLine($"{edge.First} - {edge.Second}");
            }

        }

        private static int FindRoot(int node)
        {
            while (node != parent[node])
            {
                node = parent[node];
            }

            return node;
        }
    }
}