using System;
using System.Collections.Generic;
using System.Text;

namespace CustomGraphs.Components.Interfaces
{
    interface IUnweightedNode<T>
    {
        public T Value { get; }

        public void Connect(UnweightedNode<T> anotherNode);
        public void Disconnect(UnweightedEdge<T> edge);

        public IEnumerable<UnweightedNode<T>> IncidentNodes();
        public IEnumerable<UnweightedEdge<T>> IncidentEdges();
    }
}
