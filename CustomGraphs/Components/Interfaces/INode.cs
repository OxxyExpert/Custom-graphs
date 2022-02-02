using System.Collections.Generic;

namespace CustomGraphs.Components.Interfaces
{
    public interface INode<T>
    {
        public List<WeightedEdge<T>> Edges { get; }
        public T Value { get; }
        public void Connect(BidirectionalNode<T> anotherNode, double weight);

        public IEnumerable<INode<T>> IncidentNodes();
        public IEnumerable<WeightedEdge<T>> IncidentEdges();
    }
}
