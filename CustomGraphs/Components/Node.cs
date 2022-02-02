using System;
using System.Collections.Generic;
using System.Text;
using CustomGraphs.Components.Interfaces;

namespace CustomGraphs.Components
{
    public class Node<T> : INode<T>
    {
        private List<WeightedEdge<T>> _edges;
        private readonly T _value;

        public T Value
        {
            get => _value;
        }

        public Node(T value)
        {
            _edges = new List<WeightedEdge<T>>();
            _value = value;
        }

        public void Connect(Node<T> anotherNode, double weight = 0)
        {
            anotherNode._edges.Add(new WeightedEdge<T>(anotherNode, this, weight));
            _edges.Add(new WeightedEdge<T>(this, anotherNode, weight));
        }
        public void Disconnect(WeightedEdge<T> edge)
        {
            edge.From._edges.Remove(edge);
            edge.To._edges.Remove(edge);
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public IEnumerable<Node<T>> IncidentNodes()
        {
            foreach (var edge in _edges)
            {
                yield return edge.GetOtherNode(this);
            }
        }
        public IEnumerable<WeightedEdge<T>> IncidentEdges()
        {
            foreach (var edge in _edges)
            {
                yield return edge;
            }
        }
    }
}
