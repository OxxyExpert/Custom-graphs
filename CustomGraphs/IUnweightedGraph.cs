using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CustomGraphs.Components;

namespace CustomGraphs
{
    public interface IUnweightedGraph<T>
    {
        public int Count { get; }

        public void AddNode(UnweightedNode<T> node);
        public IEnumerable<UnweightedEdge<T>> GetEdges();
        public IEnumerable<UnweightedNode<T>> GetNodes();
    }
}
