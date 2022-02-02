using System;
using System.Collections;
using System.Collections.Generic;
using CustomGraphs.Components;
using CustomGraphs.Components.Interfaces;

namespace CustomGraphs
{
    public class Graph<T> : IEnumerable<INode<T>>, IGraph<T>
    {
        private List<INode<T>> _nodes;
        public int Count
        {
            get => _nodes.Count;
        }

        public Graph()
        {
            _nodes = new List<INode<T>>();
        }

        public void AddNode(INode<T> node)
        {
            if (node == null)
                throw new ArgumentException("Node can not be null");

            _nodes.Add(node);
        }
        public void Disconnect(INode<T> node)
        {
            foreach (var edge in node.IncidentEdges())
            {
                node.Edges.Remove(edge);
            }

            foreach (var localNode in _nodes)
            {
                foreach (var edge in localNode.IncidentEdges())
                {
                    if(edge.To == node)
                    {
                        localNode.Edges.Remove(edge);
                    }
                }
            }
        }

        public WeightedEdge<T> this[BidirectionalNode<T> first, BidirectionalNode<T> second]
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
        public IEnumerable<INode<T>> GetNodes()
        {
            foreach (var node in _nodes)
            {
                yield return node;
            }
        }

        public IEnumerator<INode<T>> GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }
    }
}
