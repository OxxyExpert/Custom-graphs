using System;
using System.Collections.Generic;
using CustomGraphs.Components;
using System.Linq;

namespace CustomGraphs.Alghorithms
{
    internal class DijkstraDataWeighted<T>
    {
        public double price;
        public WeightedNode<T> previous;
    }
    public class AlghoritmsWeitedGraph<T>
    {
        public IEnumerable<WeightedNode<T>> Dijkstra(WeightedGraph<T> graph, WeightedNode<T> startNode, WeightedNode<T> target)
        {
            var notVisited = graph.ToList();
            var track = new Dictionary<WeightedNode<T>, DijkstraDataWeighted<T>>();
            track.Add(startNode, new DijkstraDataWeighted<T> { previous = null, price = 0 });

            while (true)
            {
                WeightedNode<T> toOpen = null;
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

                    WeightedNode<T> nextNode = edge.GetOtherNode(toOpen);

                    if (track.ContainsKey(nextNode) == false || track[nextNode].price > currentPrice)
                        track[nextNode] = new DijkstraDataWeighted<T> { price = currentPrice, previous = toOpen };
                }

                notVisited.Remove(toOpen);
            }

            var result = new List<WeightedNode<T>>();

            while (target != null)
            {
                result.Add(target);
                target = track[target].previous;
            }
            result.Reverse();

            return result;
        }
        public IEnumerable<WeightedNode<T>> FindShortestPath(WeightedGraph<T> graph, WeightedNode<T> startNode, WeightedNode<T> target)
        {
            var track = new Dictionary<WeightedNode<T>, WeightedNode<T>>(graph.Count);
            track.Add(startNode, null);

            var queue = new Queue<WeightedNode<T>>();
            queue.Enqueue(startNode);


            while (queue.Count != 0)
            {
                WeightedNode<T> currentNode = queue.Dequeue();

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

            var list = new List<WeightedNode<T>>();

            while (target != null)
            {
                list.Add(target);
                target = track[target];
            }

            list.Reverse();
            return list;
        }
        public IEnumerable<IEnumerable<WeightedNode<T>>> FindConnectedComponents(WeightedGraph<T> graph)
        {
            var visited = new HashSet<WeightedNode<T>>(graph.Count);

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
        public IEnumerable<WeightedNode<T>> BreadFirstSearch(WeightedGraph<T> graph, WeightedNode<T> startNode)
        {
            var queue = new Queue<WeightedNode<T>>();
            queue.Enqueue(startNode);

            var visited = new HashSet<WeightedNode<T>>(graph.Count);
            visited.Add(startNode);

            while (queue.Count != 0)
            {
                WeightedNode<T> currentNode = queue.Dequeue();

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
        public IEnumerable<WeightedNode<T>> DepthFirstSearch(WeightedGraph<T> graph, WeightedNode<T> startNode)
        {
            var stack = new Stack<WeightedNode<T>>();
            stack.Push(startNode);

            var visited = new HashSet<WeightedNode<T>>(graph.Count);

            while (stack.Count != 0)
            {
                WeightedNode<T> currentNode = stack.Pop();

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
