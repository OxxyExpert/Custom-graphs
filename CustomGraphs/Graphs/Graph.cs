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
        public void DisconnectNode(INode<T> node)
        {
            foreach (var disconnectNode in node.IncidentNodes())
            {
                disconnectNode.Disconnect(node);
            }

            _nodes.Remove(node);
        }

        public WeightedEdge<T> GetEdge(INode<T> first, INode<T> second)
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
