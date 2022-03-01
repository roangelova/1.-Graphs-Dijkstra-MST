using System;

namespace GraphsBellmanFord_LongestPathInDAG
{
    public class Edge
    {

        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }


    internal class Program
    {
        private static Dictionary<int, List<Edge>> edgesByNode
            = new Dictionary<int, List<Edge>>();

        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var from = edgeData[0];
                var to = edgeData[1];
                if (!edgesByNode.ContainsKey(from))
                {
                    edgesByNode.Add(from, new List<Edge>());
                }

                if (!edgesByNode.ContainsKey(to))
                {
                    edgesByNode.Add(to, new List<Edge>());
                }

                edgesByNode[from].Add(new Edge { From = from, To = to, Weight = edgeData[2] });

            }

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distance = new double[nodes + 1];
            Array.Fill(distance, double.NegativeInfinity);
            distance[source] = 0;

            //create topological order of all vertices using DFS

            var previous = new int[nodes + 1];
            Array.Fill(previous, -1);

            var sortedNode = TopologicalSorting();

            while (sortedNode.Count > 0)
            {
                var node = sortedNode.Pop();

                foreach (var edge in edgesByNode[node])
                {
                    var newDistance = distance[edge.From] + edge.Weight;
                    if (newDistance > distance[edge.To])
                    {
                        distance[edge.To] = newDistance;
                        previous[edge.To] = edge.From;
                    }
                }
            }

            Console.WriteLine(distance[destination]);

            //reconstructing the path

            var path = new Stack<int>();
            var currentNode = destination;

            while (currentNode != -1)
            { 
                path.Push(currentNode);
                currentNode = previous[currentNode];
            }


            Console.WriteLine(String.Join(' ', path));

        }

        private static Stack<int> TopologicalSorting()
        {
            var result = new Stack<int>();
            var visited = new HashSet<int>();

            foreach (var node in edgesByNode.Keys)
            {
                DFS(node, result, visited);
            }

            return result;
        }

        private static void DFS(int node, Stack<int> result, HashSet<int> visited)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var edge in edgesByNode[node])
            {
                DFS(edge.To, result, visited);
            }

            result.Push(node);
        }
    }
}