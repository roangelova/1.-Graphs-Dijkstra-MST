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
            var nodes = int.Parse(Console.ReadLine()) + 1;
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

            var source =int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distance = new double[nodes];
            var prev = new int[nodes + 1];

            //set default values
            for (int node = 0; node < nodes; node++)
            {
                distance[node] = double.PositiveInfinity;
                prev[node] = -1;
            }

            distance[source] = 0;


            for (int i = 0; i < nodes - 2; i++)
            {
                var updated = false;
                foreach (var edge in graph)
                {
                    if (double.IsPositiveInfinity(distance[edge.From]))
                    {
                        continue;
                    }

                    var newDistance = distance[edge.From] + edge.Weight;

                    if (newDistance < distance[edge.To])
                    {
                        distance[edge.To] = newDistance;
                        prev[edge.To] = edge.From;
                        updated = true;
                    }

                }

                if (!updated)
                {
                    break;
                }
            }

            //Detecting a negative cycle
            foreach (var edge in graph)
            {
                var newDistance = distance[edge.From] + edge.Weight;

                if (newDistance < distance[edge.To])
                {
                    Console.WriteLine("Undefined");
                    return;
                }

            }

            //reconstructing the path
            var path = new Stack<int>();
            var currentNode = destination;
            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = prev[currentNode];
            }

            Console.WriteLine(String.Join(" ", path));
            Console.WriteLine(distance[destination]);

        }
    }
}

//Example input and output
//5
//8
//1 2 - 1
//1 3 4
//2 3 3
//2 4 2
//2 5 2
//4 2 - 1
//4 3 5
//5 4 - 3
//1
//4  
//
// Output:  Undefined
