using System;
using System.Collections.Generic;
using System.Text;
using CustomGraphs.Components.Interfaces;

namespace CustomGraphs.Components
{
    public class WeightedNode<T> : IWeightedNode<T>
    {
        private List<WeightedEdge<T>> _edges;
        private readonly T _value;

        public T Value
        {
            get => _value;
        }

        public WeightedNode(T value)
        {
            _edges = new List<WeightedEdge<T>>();
            _value = value;
        }

        public void Connect(WeightedNode<T> anotherNode, double weight)
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

        public IEnumerable<WeightedNode<T>> IncidentNodes()
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
