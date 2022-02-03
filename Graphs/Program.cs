using System;
using System.Collections;
using System.Collections.Generic;
using CustomGraphs;
using CustomGraphs.Alghorithms;
using CustomGraphs.Components;

namespace Graphs
{
    class Program
    { 
        static void Main(string[] args)
        {
            var graph = new Graph<int>();
            var nodes = new List<DirectionalNode<int>>(10);

            for (int i = 0; i < 8; ++i)
                nodes.Add(new DirectionalNode<int>(i));

            nodes[0].Connect(nodes[1], 5);

            nodes[1].Connect(nodes[2], 4);
            nodes[3].Connect(nodes[1], 3);
            nodes[1].Connect(nodes[6], 3);
            nodes[6].Connect(nodes[5], 1);

            nodes[3].Connect(nodes[2], 6);
            nodes[5].Connect(nodes[3], 6);

            nodes[2].Connect(nodes[4], 2);
            nodes[4].Connect(nodes[1], 3);

            nodes[7].Connect(nodes[5], 9);
            nodes[3].Connect(nodes[7], 19);

            for (int i = 0; i < 8; ++i)
                graph.AddNode(nodes[i]);

            var alghorithms = new AlghoritmsGraph<int>();

            var list = alghorithms.Dijkstra(graph, nodes[0], nodes[7]);

            foreach (var node in list)
            {
                Console.WriteLine(node);
            }
        }
    }
}