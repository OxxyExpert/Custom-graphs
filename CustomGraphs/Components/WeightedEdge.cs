using System;
using CustomGraphs.Components.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace CustomGraphs.Components
{
    public class WeightedEdge<T> : IWeightedEdge<T>
    {
        public INode<T> From { get; }
        public INode<T> To { get; }
        public double Weight { get; private set; }

        public WeightedEdge(INode<T> from, INode<T> to, double weight = 1)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public bool IsIncident(INode<T> node)
        {
            return node == From || node == To;
        }
        public INode<T> GetOtherNode(INode<T> currentNode)
        {
            if (currentNode == From)
                return To;
            else if (currentNode == To)
                return From;

            throw new ArgumentException($"Current node: {currentNode.ToString()}; isn't at edge!");
        }

        public override string ToString()
        {
            return $"{From} -{Weight}-> {To}";
        }
    }
}
