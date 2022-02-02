using System;
using System.Collections.Generic;
using System.Text;

namespace CustomGraphs.Components
{
    public class WeightedEdge<T> : IWeightedEdge<T>
    {
        public Node<T> From { get; }
        public Node<T> To { get; }
        public double Weight { get; private set; }

        public WeightedEdge(Node<T> from, Node<T> to, double weight = 1)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public bool IsIncident(Node<T> node)
        {
            return node == From || node == To;
        }
        public Node<T> GetOtherNode(Node<T> currentNode)
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
