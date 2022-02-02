using System;
using System.Collections.Generic;
using System.Text;

namespace CustomGraphs.Components
{
    public class UnweightedEdge<T> : IUnweightedEdge<T>
    {
        public UnweightedNode<T> From { get; }
        public UnweightedNode<T> To { get; }
        public UnweightedEdge(UnweightedNode<T> from, UnweightedNode<T> to)
        {
            From = from;
            To = to;
        }

        public bool IsIncident(UnweightedNode<T> node)
        {
            return node == From || node == To;
        }
        public UnweightedNode<T> GetOtherNode(UnweightedNode<T> currentNode)
        {
            if (currentNode == From)
                return To;
            else if (currentNode == To)
                return From;

            throw new ArgumentException($"Current node: {currentNode.ToString()}; isn't at edge!");
        }

        public override string ToString()
        {
            return $"{From.ToString()} -> {To.ToString()}";
        }
    }
}
