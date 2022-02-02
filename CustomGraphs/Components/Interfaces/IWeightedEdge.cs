using System;
using System.Collections.Generic;
using System.Text;

namespace CustomGraphs
{
    namespace Components
    {
        public interface IWeightedEdge<T>
        {
            public WeightedNode<T> From { get; }
            public WeightedNode<T> To { get; }
            public double Weight { get; }

            public bool IsIncident(WeightedNode<T> node);
            public WeightedNode<T> GetOtherNode(WeightedNode<T> currentNode);
        }
    }
}
