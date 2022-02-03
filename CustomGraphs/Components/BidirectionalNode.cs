using System;
using System.Collections.Generic;
using System.Text;
using CustomGraphs.Components.Interfaces;

namespace CustomGraphs.Components
{
    public class BidirectionalNode<T> : INode<T>
    {
        private List<WeightedEdge<T>> _edges;

        private readonly T _value;

        public T Value
        {
            get => _value;
        }
        public BidirectionalNode(T value)
        {
            _edges = new List<WeightedEdge<T>>();
            _value = value;
        }

        public void Connect(INode<T> anotherNode, double weight = 0)
        {
            anotherNode.AddEdge(new WeightedEdge<T>(anotherNode, this, weight));
            _edges.Add(new WeightedEdge<T>(this, anotherNode, weight));
        }
        public void Disconnect(INode<T> anotherNode)
        {
            foreach (var edge in _edges)
            {
                if (edge.To == anotherNode)
                {
                    _edges.Remove(edge);
                    break;
                }
            }
        }

        public void AddEdge(WeightedEdge<T> edge)
        {
            _edges.Add(edge);
        }


        public override string ToString()
        {
            return _value.ToString();
        }

        public IEnumerable<INode<T>> IncidentNodes()
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
