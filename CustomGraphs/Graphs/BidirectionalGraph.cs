using System;
using System.Collections;
using System.Collections.Generic;
using CustomGraphs.Components;
using CustomGraphs;

namespace CustomGraphs
{
    public class BidirectionalGraph<T> : IEnumerable<Node<T>>, IGraph<T>
    {
        private List<Node<T>> _nodes;
        public int Count
        {
            get => _nodes.Count;
        }

        public BidirectionalGraph()
        {
            _nodes = new List<Node<T>>();
        }

        public void AddNode(Node<T> node)
        {
            if (node == null)
                throw new ArgumentException("Node can not be null");

            _nodes.Add(node);
        }

        public WeightedEdge<T> this[Node<T> first, Node<T> second]
        {
            get
            {
                foreach (var node in _nodes)
                {
                    foreach (var edge in node.IncidentEdges())
                    {
                        if (edge.From == first && edge.To == second)
                            return edge;
                    }
                }

                return null;
            }
        }

        public IEnumerable<WeightedEdge<T>> GetEdges()
        {
            foreach (var node in _nodes)
            {
                foreach (var edge in node.IncidentEdges())
                {
                    yield return edge;
                }
            }
        }
        public IEnumerable<Node<T>> GetNodes()
        {
            foreach (var node in _nodes)
            {
                yield return node;
            }
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }
    }
}
