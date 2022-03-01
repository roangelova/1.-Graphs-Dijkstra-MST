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

        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            var graph = new List<Edge>();

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                graph.Add(new Edge
                {
                    From = edgeData[0],
                    To = edgeData[1],
                    Weight = edgeData[2]
                });

            }

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distance = new double[nodes + 1];
            Array.Fill(distance, double.PositiveInfinity);

            distance[source] = 0;

            var previous = new int[nodes + 1];
            Array.Fill(previous, -1);

            for (int i = 0; i < nodes - 1; i++)
            {
                var updated = false;

                foreach (var edge in graph)
                {
                    if (double.IsPositiveInfinity(distance[edge.From]))
                    {
                        //node has not yet been visited
                        continue;
                    }

                    var newDistance = distance[edge.From] + edge.Weight;
                    if (newDistance < distance[edge.To])
                    {
                        distance[edge.To] = newDistance;
                        updated = true;
                        previous[edge.To] = edge.From;
                    }
                }

                if (!updated)
                {
                    break;
                }

            }

            foreach (var edge in graph)
            {
                var newDistance = distance[edge.From] + edge.Weight;
                if (newDistance < distance[edge.To])
                {
                    //we have a cycle
                    Console.WriteLine("Negative cycle detected");
                    return;
                }
            }

            //Path reconstruction 
            var path = new Stack<int>();
            var node = destination;
            while (node != -1)
            {
                path.Push(node);
                node = previous[node];
            }

            Console.WriteLine($"Path: {string.Join(" ", path)}");
            Console.WriteLine($"The distance to the destination is {distance[destination]}");

        }
    }
}