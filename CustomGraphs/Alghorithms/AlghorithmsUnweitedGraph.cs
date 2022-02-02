using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CustomGraphs.Components;

namespace CustomGraphs
{
    namespace Alghorithms
    {
        internal class DijkstraData<T>
        {
            public double price;
            public UnweightedNode<T> previous;
        }

        public class AlghoritmsUnweitedGraph<T>
        {
            public IEnumerable<UnweightedNode<T>> FindShortestPath(UnweightedGraph<T> graph, UnweightedNode<T> startNode, UnweightedNode<T> target)
            {
                var track = new Dictionary<UnweightedNode<T>, UnweightedNode<T>>(graph.Count);
                track.Add(startNode, null);

                var queue = new Queue<UnweightedNode<T>>();
                queue.Enqueue(startNode);


                while (queue.Count != 0)
                {
                    UnweightedNode<T> currentNode = queue.Dequeue();

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

                var list = new List<UnweightedNode<T>>();

                while (target != null)
                {
                    list.Add(target);
                    target = track[target];
                }

                list.Reverse();
                return list;
            }
            public IEnumerable<IEnumerable<UnweightedNode<T>>> FindConnectedComponents(UnweightedGraph<T> graph)
            {
                var visited = new HashSet<UnweightedNode<T>>(graph.Count);

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
            public IEnumerable<UnweightedNode<T>> BreadFirstSearch(UnweightedGraph<T> graph, UnweightedNode<T> startNode)
            {
                var queue = new Queue<UnweightedNode<T>>();
                queue.Enqueue(startNode);

                var visited = new HashSet<UnweightedNode<T>>(graph.Count);
                visited.Add(startNode);

                while (queue.Count != 0)
                {
                    UnweightedNode<T> currentNode = queue.Dequeue();

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
            public IEnumerable<UnweightedNode<T>> DepthFirstSearch(UnweightedGraph<T> graph, UnweightedNode<T> startNode)
            {
                var stack = new Stack<UnweightedNode<T>>();
                stack.Push(startNode);

                var visited = new HashSet<UnweightedNode<T>>(graph.Count);

                while (stack.Count != 0)
                {
                    UnweightedNode<T> currentNode = stack.Pop();

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
}
