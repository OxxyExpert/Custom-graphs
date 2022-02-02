using System;
using System.Collections.Generic;
using System.Text;
using CustomGraphs.Components.Interfaces;

namespace CustomGraphs.Components
{
    public class UnweightedNode<T> : IUnweightedNode<T>
    {
        private List<UnweightedEdge<T>> _edges;
        private readonly T _value;

        public T Value
        {
            get => _value;
        }

        public UnweightedNode(T value)
        {
            _edges = new List<UnweightedEdge<T>>();
            _value = value;
        }

        public void Connect(UnweightedNode<T> anotherNode)
        {
            anotherNode._edges.Add(new UnweightedEdge<T>(anotherNode, this));
            _edges.Add(new UnweightedEdge<T>(this, anotherNode));
        }
        public void Disconnect(UnweightedEdge<T> edge)
        {
            edge.From._edges.Remove(edge);
            edge.To._edges.Remove(edge);
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public IEnumerable<UnweightedNode<T>> IncidentNodes()
        {
            foreach (var edge in _edges)
            {
                yield return edge.GetOtherNode(this);
            }
        }
        public IEnumerable<UnweightedEdge<T>> IncidentEdges()
        {
            foreach (var edge in _edges)
            {
                yield return edge;
            }
        }
    }
}
