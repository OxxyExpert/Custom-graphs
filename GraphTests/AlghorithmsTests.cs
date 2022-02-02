using NUnit.Framework;
using CustomGraphs;
using System.Collections.Generic;
using System.Linq;
using CustomGraphs.Components;
using CustomGraphs.Alghorithms;

namespace GraphTests
{
    public class GraphTests
    {
        private Graph<int> graph;
        private List<BidirectionalNode<int>> nodes;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            graph = new Graph<int>();
            nodes = new List<BidirectionalNode<int>>(10);

            for (int i = 0; i < 8; ++i)
                nodes.Add(new BidirectionalNode<int>(i));

            nodes[0].Connect(nodes[1], 5);

            nodes[1].Connect(nodes[2], 4);
            nodes[1].Connect(nodes[3], 3);
            nodes[1].Connect(nodes[6], 3);
            nodes[1].Connect(nodes[4], 3);

            nodes[4].Connect(nodes[2], 2);

            nodes[6].Connect(nodes[5], 1);

            nodes[2].Connect(nodes[3], 6);

            nodes[3].Connect(nodes[5], 6);

            nodes[5].Connect(nodes[7], 9);
            nodes[7].Connect(nodes[3], 19);

            for (int i = 0; i < 8; ++i)
                graph.AddNode(nodes[i]);
        }

        [Test]
        public void DijkstraAlghorithm()
        {
            var graphDijkstra = new Graph<int>();
            var nodesDijkstra = new List<BidirectionalNode<int>>();

            for (int i = 0; i < 4; ++i)
                nodesDijkstra.Add(new BidirectionalNode<int>(i));

            nodesDijkstra[0].Connect(nodesDijkstra[1], 1);
            nodesDijkstra[0].Connect(nodesDijkstra[2], 2);
            nodesDijkstra[0].Connect(nodesDijkstra[3], 6);

            nodesDijkstra[1].Connect(nodesDijkstra[3], 4);

            nodesDijkstra[2].Connect(nodesDijkstra[3], 2);

            for (int i = 0; i < 4; ++i)
                graphDijkstra.AddNode(nodesDijkstra[i]);

            var dijkstra = new AlghoritmsGraph<int>();

            var actual = dijkstra.Dijkstra(graphDijkstra, nodesDijkstra[0], nodesDijkstra[3]).ToList();

            int[] expected = { 0, 2, 3 };

            CollectionAssert.AreEqual(expected, actual.Select(v => v.Value));
        }
        [Test]
        public void DijkstraAlghorithm_NoPath_Null()
        {
            var graphDijkstra = new Graph<int>();
            var nodesDijkstra = new List<BidirectionalNode<int>>();

            for (int i = 0; i < 5; ++i)
                nodesDijkstra.Add(new BidirectionalNode<int>(i));

            nodesDijkstra[0].Connect(nodesDijkstra[1], 1);
            nodesDijkstra[0].Connect(nodesDijkstra[2], 2);
            nodesDijkstra[0].Connect(nodesDijkstra[3], 6);

            nodesDijkstra[1].Connect(nodesDijkstra[3], 4);

            nodesDijkstra[2].Connect(nodesDijkstra[3], 2);

            for (int i = 0; i < 5; ++i)
                graphDijkstra.AddNode(nodesDijkstra[i]);

            var dijkstra = new AlghoritmsGraph<int>();

            var actual = dijkstra.Dijkstra(graphDijkstra, nodesDijkstra[0], nodesDijkstra[4]);

            IEnumerable<BidirectionalNode<int>> expected = null;

            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void BreadFirstSearchTest()
        {
            var alghorithm = new AlghoritmsGraph<int>();

            var actual = alghorithm.BreadFirstSearch(graph, nodes[0]);

            int[] expected = { 0, 1, 2, 3, 6, 4, 5, 7 };

            CollectionAssert.AreEqual(expected, actual.Select(x => x.Value).ToArray());
        }
        [Test]
        public void DepthFirstSearchTest()
        {
            var alghorithm = new AlghoritmsGraph<int>();

            var actual = alghorithm.DepthFirstSearch(graph, nodes[0]).ToArray();

            int[] expected = { 0, 1, 4, 2, 3, 7, 5, 6 };

            CollectionAssert.AreEqual(expected, actual.Select(x => x.Value));
        }
        [Test]
        public void ConnectedComponents_IntegralGraph()
        {
            var alghorithm = new AlghoritmsGraph<int>();

            var actual = alghorithm.FindConnectedComponents(graph);

            int[] expected = { 0, 1, 2, 3, 6, 4, 5, 7 };

            foreach (var item in actual)
            {
                CollectionAssert.AreEqual(expected, item.Select(x => x.Value).ToArray());
            }
        }
        [Test]
        public void ConnectedComponents_DividedGraph()
        {
            var dividedGraph = InitializeDividedGraph();

            var alghorithm = new AlghoritmsGraph<int>();

            var actual = alghorithm.FindConnectedComponents(dividedGraph);

            int[][] expected = new int[3][];
            expected[0] = new int[] { 0 };
            expected[1] = new int[] { 1, 2 };
            expected[2] = new int[] { 3, 4, 5 };

            int counter = 0;
            foreach (var item in actual)
            {
                CollectionAssert.AreEqual(expected[counter], item.Select(x => x.Value).ToArray());

                counter += 1;
            }
        }
        [Test]
        public void FindBestPath()
        {
            var alghorithms = new AlghoritmsGraph<int>();

            var actual = alghorithms.FindShortestPath(graph, nodes[0], nodes[4]);

            int[] expected = { 0, 1, 4 };

            CollectionAssert.AreEqual(expected, actual.Select(x => x.Value).ToList());
        }

        private Graph<int> InitializeDividedGraph()
        {
            var nodeZero = new BidirectionalNode<int>(0);
            var nodeOne = new BidirectionalNode<int>(1);
            var nodeTwo = new BidirectionalNode<int>(2);
            var nodeThree = new BidirectionalNode<int>(3);
            var nodeFour = new BidirectionalNode<int>(4);
            var nodeFive = new BidirectionalNode<int>(5);

            nodeOne.Connect(nodeTwo, 1);

            nodeThree.Connect(nodeFour);
            nodeThree.Connect(nodeFive);
            nodeFour.Connect(nodeFive);

            var graphConnected = new Graph<int>();
            graphConnected.AddNode(nodeZero);
            graphConnected.AddNode(nodeOne);
            graphConnected.AddNode(nodeTwo);
            graphConnected.AddNode(nodeThree);
            graphConnected.AddNode(nodeFour);
            graphConnected.AddNode(nodeFive);

            return graphConnected;
        }
    }
}