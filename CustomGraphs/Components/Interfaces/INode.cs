using System.Collections.Generic;

namespace CustomGraphs.Components.Interfaces
{
    interface INode<T>
    {
        public T Value { get; }
        public void Connect(Node<T> anotherNode, double weight);
        public void Disconnect(WeightedEdge<T> edge);

        public IEnumerable<Node<T>> IncidentNodes();
        public IEnumerable<WeightedEdge<T>> IncidentEdges();
    }
}
