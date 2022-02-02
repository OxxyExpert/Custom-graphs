using System;
using System.Collections.Generic;
using System.Text;

namespace CustomGraphs.Components
{
    public class WeightedEdge<T> : IWeightedEdge<T>
    {
        public WeightedNode<T> From { get; }
        public WeightedNode<T> To { get; }
        public double Weight { get; private set; }

        public WeightedEdge(WeightedNode<T> from, WeightedNode<T> to, double weight = 1)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public bool IsIncident(WeightedNode<T> node)
        {
            return node == From || node == To;
        }
        public WeightedNode<T> GetOtherNode(WeightedNode<T> currentNode)
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
