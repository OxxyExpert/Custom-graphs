using System;
using System.Collections.Generic;
using CustomGraphs.Components;
using CustomGraphs.Components.Interfaces;
using System.Linq;

namespace CustomGraphs.Alghorithms
{
    internal class DijkstraData<T>
    {
        public double price;
        public INode<T> previous;
    }
    public class AlghoritmsGraph<T>
    {
        public IEnumerable<INode<T>> Dijkstra(IGraph<T> graph, INode<T> startNode, INode<T> target)
        {
            var notVisited = graph.ToList();

            var track = new Dictionary<INode<T>, DijkstraData<T>>();
            track.Add(startNode, new DijkstraData<T> { previous = null, price = 0 });

            while (true)
            {
                INode<T> toOpen = null;
                double bestPrice = double.PositiveInfinity;

                foreach (var node in notVisited)
                {
                    if (track.ContainsKey(node) == true && track[node].price < bestPrice)
                    {
                        toOpen = node;
                        bestPrice = track[node].price;
                    }
                }

                if (toOpen == null)
                    return null;
                if (toOpen == target)
                    break;

                foreach (var edge in toOpen.IncidentEdges().Where(e => e.From == toOpen))
                {
                    double currentPrice = track[toOpen].price + edge.Weight;

                    INode<T> nextNode = edge.GetOtherNode(toOpen);

                    if (track.ContainsKey(nextNode) == false || track[nextNode].price > currentPrice)
                        track[nextNode] = new DijkstraData<T> { price = currentPrice, previous = toOpen };
                }

                notVisited.Remove(toOpen);
            }

            var result = new List<INode<T>>();

            while (target != null)
            {
                result.Add(target);
                target = track[target].previous;
            }
            result.Reverse();

            return result;
        }
        public IEnumerable<INode<T>> FindShortestPath(IGraph<T> graph, INode<T> startNode, INode<T> target)
        {
            var track = new Dictionary<INode<T>, INode<T>>(graph.Count);
            track.Add(startNode, null);

            var queue = new Queue<INode<T>>();
            queue.Enqueue(startNode);


            while (queue.Count != 0)
            {
                INode<T> currentNode = queue.Dequeue();

                bool endIsFound = false;
                foreach (var nextNode in currentNode.IncidentNodes())
                {
                    if (track.ContainsKey(nextNode) == true)
                        continue;

                    track.Add(nextNode, currentNode);
                    queue.Enqueue(nextNode);

                    if (nextNode == target)
                        endIsFound = true;
                }

                if (endIsFound == true)
                    break;
            }

            if (track.ContainsKey(target) == false)
                return null;

            var list = new List<INode<T>>();

            while (target != null)
            {
                list.Add(target);
                target = track[target];
            }

            list.Reverse();
            return list;
        }
        public IEnumerable<IEnumerable<INode<T>>> FindConnectedComponents(IGraph<T> graph)
        {
            var visited = new HashSet<INode<T>>(graph.Count);

            while (true)
            {
                var node = graph.Where(z => visited.Contains(z) == false).FirstOrDefault();

                if (node == null)
                    break;

                var breadthSearch = BreadFirstSearch(graph, node);

                foreach (var visitedNode in breadthSearch)
                {
                    visited.Add(visitedNode);
                }

                yield return breadthSearch;
            }
        }
        public IEnumerable<INode<T>> BreadFirstSearch(IGraph<T> graph, INode<T> startNode)
        {
            var queue = new Queue<INode<T>>();
            queue.Enqueue(startNode);

            var visited = new HashSet<INode<T>>(graph.Count);
            visited.Add(startNode);

            while (queue.Count != 0)
            {
                INode<T> currentNode = queue.Dequeue();

                yield return currentNode;

                foreach (var nextNode in currentNode.IncidentNodes())
                {
                    if (visited.Contains(nextNode) == true)
                        continue;

                    queue.Enqueue(nextNode);
                    visited.Add(nextNode);
                }
            }
        }
        public IEnumerable<INode<T>> DepthFirstSearch(IGraph<T> graph, INode<T> startNode)
        {
            var stack = new Stack<INode<T>>();
            stack.Push(startNode);

            var visited = new HashSet<INode<T>>(graph.Count);

            while (stack.Count != 0)
            {
                INode<T> currentNode = stack.Pop();

                if (visited.Contains(currentNode) == true)
                    continue;

                visited.Add(currentNode);

                yield return currentNode;

                foreach (var nextNode in currentNode.IncidentNodes().Where(n => !visited.Contains(n)))
                {
                    stack.Push(nextNode);
                }
            }
        }
    }
}
