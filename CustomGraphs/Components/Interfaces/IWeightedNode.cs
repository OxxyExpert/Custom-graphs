using System.Collections.Generic;

namespace CustomGraphs.Components.Interfaces
{
    interface IWeightedNode<T>
    {
        public T Value { get; }
        public void Connect(WeightedNode<T> anotherNode, double weight);
        public void Disconnect(WeightedEdge<T> edge);

        public IEnumerable<WeightedNode<T>> IncidentNodes();
        public IEnumerable<WeightedEdge<T>> IncidentEdges();
    }
}
