using System;
using System.Collections.Generic;
using System.Text;
using CustomGraphs.Components.Interfaces;

namespace CustomGraphs.Components
{
    public class BidirectionalNode<T> : INode<T>
    {
        public List<WeightedEdge<T>> Edges { get; private set; }

        private readonly T _value;

        public T Value
        {
            get => _value;
        }
        public BidirectionalNode(T value)
        {
            Edges = new List<WeightedEdge<T>>();
            _value = value;
        }

        public void Connect(BidirectionalNode<T> anotherNode, double weight = 0)
        {
            anotherNode.Edges.Add(new WeightedEdge<T>(anotherNode, this, weight));
            Edges.Add(new WeightedEdge<T>(this, anotherNode, weight));
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public IEnumerable<INode<T>> IncidentNodes()
        {
            foreach (var edge in Edges)
            {
                yield return edge.GetOtherNode(this);
            }
        }
        public IEnumerable<WeightedEdge<T>> IncidentEdges()
        {
            foreach (var edge in Edges)
            {
                yield return edge;
            }
        }
    }
}
