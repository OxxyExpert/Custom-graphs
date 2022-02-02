using System;
using System.Collections.Generic;
using System.Text;

namespace CustomGraphs
{
    namespace Components
    {
        interface IUnweightedEdge<T>
        {
            public UnweightedNode<T> From { get; }
            public UnweightedNode<T> To { get; }

            public bool IsIncident(UnweightedNode<T> node);
            public UnweightedNode<T> GetOtherNode(UnweightedNode<T> currentNode);
        }
    }
}
