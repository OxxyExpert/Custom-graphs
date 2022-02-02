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
            #region Unweited graph

            var graph = new WeightedGraph<int>();
            var nodes = new List<WeightedNode<int>>(10);

            for (int i = 0; i < 8; ++i)
                nodes.Add(new WeightedNode<int>(i));

            nodes[0].Connect(nodes[1], 5);

            nodes[1].Connect(nodes[2], 4);
            nodes[1].Connect(nodes[3], 3);
            nodes[1].Connect(nodes[6], 3);
            nodes[6].Connect(nodes[5], 1);

            nodes[3].Connect(nodes[2], 6);
            nodes[3].Connect(nodes[5], 6);

            nodes[4].Connect(nodes[2], 2);
            nodes[4].Connect(nodes[1], 3);

            nodes[5].Connect(nodes[7], 9);
            nodes[7].Connect(nodes[3], 19);

            for (int i = 0; i < 8; ++i)
                graph.AddNode(nodes[i]);

            var alghorithms = new AlghoritmsWeitedGraph<int>();

            var list = alghorithms.DepthFirstSearch(graph, nodes[0]);

            foreach (var node in list)
            {
                Console.WriteLine(node);
            }

            #endregion
        }
    }
}