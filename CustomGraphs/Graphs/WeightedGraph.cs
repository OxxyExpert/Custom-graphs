using System;
using System.Collections;
using System.Collections.Generic;
using CustomGraphs.Components;
using CustomGraphs;

namespace CustomGraphs
{
    public class WeightedGraph<T> : IEnumerable<WeightedNode<T>>, IWeightedGraph<T>
    {
        private List<WeightedNode<T>> _nodes;
        public int Count
        {
            get => _nodes.Count;
        }

        public WeightedGraph()
        {
            _nodes = new List<WeightedNode<T>>();
        }

        public void AddNode(WeightedNode<T> node)
        {
            if (node == null)
                throw new ArgumentException("Node can not be null");

            _nodes.Add(node);
        }

        public WeightedEdge<T> this[WeightedNode<T> first, WeightedNode<T> second]
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
        public IEnumerable<WeightedNode<T>> GetNodes()
        {
            foreach (var node in _nodes)
            {
                yield return node;
            }
        }

        public IEnumerator<WeightedNode<T>> GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }
    }
}
