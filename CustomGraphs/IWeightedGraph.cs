using System;
using System.Collections.Generic;
using System.Text;
using CustomGraphs.Components;

namespace CustomGraphs
{
    public interface IWeightedGraph<T>
    {
        public int Count { get; }

        public void AddNode(WeightedNode<T> node);
        public IEnumerable<WeightedEdge<T>> GetEdges();
        public IEnumerable<WeightedNode<T>> GetNodes();
    }
}
