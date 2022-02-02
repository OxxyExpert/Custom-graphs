using System;
using System.Collections.Generic;
using CustomGraphs.Components.Interfaces;
using CustomGraphs.Components;

namespace CustomGraphs
{
    public interface IGraph<T> : IEnumerable<INode<T>>
    {
        public int Count { get; }

        public void AddNode(INode<T> node);
        public void Disconnect(INode<T> node);
        public IEnumerable<WeightedEdge<T>> GetEdges();
        public IEnumerable<INode<T>> GetNodes();
    }
}
