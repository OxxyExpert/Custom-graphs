using System;
using System.Collections.Generic;
using System.Text;
using CustomGraphs.Components.Interfaces;

namespace CustomGraphs.Components
{
    public class DirectionalNode<T> : BidirectionalNode<T>, INode<T>
    {
        public DirectionalNode(T value) : base(value)
        {
            _edges = new List<WeightedEdge<T>>();
        }

        public new void Connect(INode<T> anotherNode, double weight)
        {
            _edges.Add(new WeightedEdge<T>(this, anotherNode, weight));
        }
    }
}
