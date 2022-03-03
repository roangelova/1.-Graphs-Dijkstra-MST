using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace Exercise_BellmanFord_LongestPathInDAG
{

    public class Edge
    {

        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //we make the decision that we need MST 
            //then we decide if we need Kruskal or Prim[x]

            var budget = int.Parse(Console.ReadLine());
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            var spanningTree = new HashSet<int>();

            var graph = new List<Edge>[nodes];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split();

                var edge = new Edge
                {
                    First = int.Parse(edgeData[0]),
                    Second = int.Parse(edgeData[1]),
                    Weight = int.Parse(edgeData[2])
                };

                //nodes thatare currently part of the network
                graph[edge.First].Add(edge);
                graph[edge.Second].Add(edge);

                if (edgeData.Length == 4)
                {
                    spanningTree.Add(edge.First);
                    spanningTree.Add(edge.Second);  
                }
            }

            var usedBudget = Prim(graph, spanningTree, budget);
            Console.WriteLine($"Budget used: {usedBudget}");

        }

        private static int Prim(List<Edge>[] graph, HashSet<int> spanningTree, int budget)
        {
            var usedBudget = 0;
            var bag = new OrderedBag<Edge>(
                Comparer<Edge>.Create((f, s) => f.Weight.CompareTo(s.Weight)));

            foreach (var node in spanningTree)
            {
                bag.AddMany(graph[node]);
            }

            while (bag.Count > 0)
            {
                var minEdge = bag.RemoveFirst();

                var nonTreeNode = -1;

                if (spanningTree.Contains(minEdge.First)
                    && ! spanningTree.Contains(minEdge.Second))
                {
                    nonTreeNode = minEdge.Second;
                }

                if (spanningTree.Contains(minEdge.Second)
                  && !spanningTree.Contains(minEdge.First))
                {
                    nonTreeNode = minEdge.First;
                }

                if (nonTreeNode == -1)
                {
                    //both are part of the tree
                    continue;
                }

                spanningTree.Add(nonTreeNode);

                if (usedBudget + minEdge.Weight > budget)
                {
                    break;
                }
                usedBudget += minEdge.Weight;

                bag.AddMany(graph[nonTreeNode]);

            }

            return usedBudget;
        }
    }
}

//Example input and output
//7
//4
//5
//0 1 9
//0 3 4 connected
//3 1 6
//3 2 11 connected
//1 2 5       
//    Budget used: 5