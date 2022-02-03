using System.Collections.Generic;

namespace CustomGraphs.Components.Interfaces
{
    public interface INode<T>
    {
        public T Value { get; }
        public void Connect(INode<T> anotherNode, double weight);
        public void Disconnect(INode<T> anotherNode);

        public void AddEdge(WeightedEdge<T> edge);
        public IEnumerable<INode<T>> IncidentNodes();
        public IEnumerable<WeightedEdge<T>> IncidentEdges();
    }
}
