using CustomGraphs.Components.Interfaces;

namespace CustomGraphs
{
    namespace Components
    {
        public interface IWeightedEdge<T>
        {
            public INode<T> From { get; }
            public INode<T> To { get; }
            public double Weight { get; }

            public bool IsIncident(INode<T> node);
            public INode<T> GetOtherNode(INode<T> currentNode);
        }
    }
}
