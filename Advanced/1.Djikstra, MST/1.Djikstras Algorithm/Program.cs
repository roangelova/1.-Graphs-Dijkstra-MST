using System;
using System.Collections;
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
        private static Dictionary<int, List<Edge>> edgesByNode;
        private static double[] distance;
        private static int[] parent;
        static void Main(string[] args)
        {
            edgesByNode = new Dictionary<int, List<Edge>>();

            //Reading the graph:
            var edgesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgesCount; i++)
            {

                //: "{start}, {end}, {weight}".
                var edgeArgs = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                var firstNode = edgeArgs[0];
                var secondNode = edgeArgs[1];

                var edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = edgeArgs[2]
                };

                if (!edgesByNode.ContainsKey(firstNode))
                {
                    edgesByNode.Add(firstNode, new List<Edge>());
                }

                if (!edgesByNode.ContainsKey(secondNode))
                {
                    edgesByNode.Add(secondNode, new List<Edge>());
                }

                edgesByNode[firstNode].Add(edge);
                edgesByNode[secondNode].Add(edge);
            }


            var biggestNode = edgesByNode.Keys.Max();

            distance = new double[biggestNode + 1];

            for (int node = 0; node < distance.Length; node++)
            {
                distance[node] = double.PositiveInfinity;
            }

            parent = new int[biggestNode + 1];
            Array.Fill(parent, -1);

            //Read start and end note from the console:

            var startNode = int.Parse(Console.ReadLine());
            var endNode = int.Parse(Console.ReadLine());

            distance[startNode] = 0;

            //Find shortest path using a custom priority queue:

            var bag = new OrderedBag<int>(Comparer<int>.Create((f, s)
                => (int)(distance[f] - distance[s])));
            bag.Add(startNode);

            while (bag.Count > 0)
            {
                var minNode = bag.RemoveFirst();

                if (double.IsPositiveInfinity(minNode))
                {
                    break;
                }

                if (minNode == endNode)
                {
                    break;
                }

                foreach (var edge in edgesByNode[minNode])
                {
                    var otherNode = edge.First == minNode
                        ? edge.Second
                        : edge.First;

                    if (double.IsPositiveInfinity(distance[otherNode]))
                    {
                        bag.Add(otherNode);
                    }

                    var newDistance = distance[minNode] + edge.Weight;

                    if (newDistance < distance[otherNode])
                    {
                        parent[otherNode] = minNode;
                        distance[otherNode] = newDistance;

                        //force reordering
                        bag = new OrderedBag<int>(bag,
                            Comparer<int>.Create((f, s) => (int)(distance[f] - distance[s])));

                    }

                }
            }


            //Print the cost of shortest path:
            Console.WriteLine(distance[endNode]);

            //Path reconstruction:
            var currentNode = endNode;
            var path = new Stack<int>();
            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = parent[currentNode];
            }

            Console.WriteLine(String.Join(" ", path));
        }
    }
}


//Example Input & Output
//18
//0, 6, 10
//0, 8, 12
//6, 4, 17
//6, 5, 6
//8, 5, 3
//5, 4, 5
//5, 11, 33
//8, 2, 14
//2, 11, 9
//2, 7, 15
//4, 1, 20
//4, 11, 11
//11, 1, 6
//11, 7, 20
//1, 9, 5
//1, 7, 26
//7, 9, 3
//3, 10, 7
//0
//9  
//    
//42
//0 8 5 4 11 1 9




