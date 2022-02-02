using System;
using System.Collections.Generic;
using System.Text;

namespace CustomGraphs
{
    namespace Components
    {
        public interface IWeightedEdge<T>
        {
            public Node<T> From { get; }
            public Node<T> To { get; }
            public double Weight { get; }

            public bool IsIncident(Node<T> node);
            public Node<T> GetOtherNode(Node<T> currentNode);
        }
    }
}
