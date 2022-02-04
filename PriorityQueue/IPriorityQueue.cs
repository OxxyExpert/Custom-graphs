using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueue
{
    public interface IPriorityQueue<TKey>
    {
        bool TryGetValue(TKey key, out double priority);
        void Enqueue(TKey key, double priority);
        Tuple<TKey, double> Dequeue();
        void Remove(TKey key);
        void UpdatePriority(TKey key, double newPriority);
    }
}
