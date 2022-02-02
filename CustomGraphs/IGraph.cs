using System;
using System.Collections.Generic;
using System.Text;
using CustomGraphs.Components;

namespace CustomGraphs
{
    public interface IGraph<T>
    {
        public int Count { get; }

        public void AddNode(Node<T> node);
        public IEnumerable<WeightedEdge<T>> GetEdges();
        public IEnumerable<Node<T>> GetNodes();
    }
}
