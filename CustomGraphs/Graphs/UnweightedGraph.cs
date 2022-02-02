using System;
using System.Collections;
using System.Collections.Generic;
using CustomGraphs.Components;

namespace CustomGraphs
{
    public class UnweightedGraph<T> : IUnweightedGraph<T>, IEnumerable<UnweightedNode<T>>
    {
        private List<UnweightedNode<T>> _nodes;
        public int Count
        {
            get => _nodes.Count;
        }

        public UnweightedGraph()
        {
            _nodes = new List<UnweightedNode<T>>();
        }

        public void AddNode(UnweightedNode<T> node)
        {
            if (node == null)
                throw new ArgumentException("Node can not be null");

            _nodes.Add(node);
        }

        public UnweightedEdge<T> this[UnweightedNode<T> first, UnweightedNode<T> second]
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

        public IEnumerable<UnweightedEdge<T>> GetEdges()
        {
            foreach (var node in _nodes)
            {
                foreach (var edge in node.IncidentEdges())
                {
                    yield return edge;
                }
            }
        }
        public IEnumerable<UnweightedNode<T>> GetNodes()
        {
            foreach (var node in _nodes)
            {
                yield return node;
            }
        }

        public IEnumerator<UnweightedNode<T>> GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }
    }
}
