﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PriorityQueue
{
    public class PriorityQueue<TKey> : IPriorityQueue<TKey>
    {
        private Dictionary<TKey, double> _dictionary;

        public PriorityQueue()
        {
            _dictionary = new Dictionary<TKey, double>();
        }

        public Tuple<TKey, double> Dequeue()
        {
            #region Old One
            //if (_dictionary.Count == 0)
            //    throw new InvalidOperationException("Queue is clear. Can't return a value");

            //double minPriority = double.MaxValue;
            //TKey element = _dictionary.First().Key;

            //foreach (var pair in _dictionary)
            //{
            //    if (pair.Value < minPriority)
            //    {
            //        element = pair.Key;

            //        minPriority = pair.Value;
            //    }
            //}

            //_dictionary.Remove(element);
            //return Tuple.Create<TKey, double>(element, minPriority);
            #endregion

            if (_dictionary.Count == 0)
                return null;

            var min = _dictionary.Min(z => z.Value);
            var key = _dictionary.FirstOrDefault(z => z.Value == min).Key;

            _dictionary.Remove(key);

            return Tuple.Create(key, min);
        }

        public void Enqueue(TKey key, double priority)
        {
            _dictionary.Add(key, priority);
        }
        public void Remove(TKey key)
        {
            _dictionary.Remove(key);
        }
        public bool TryGetValue(TKey key, out double priority)
        {
            return _dictionary.TryGetValue(key, out priority);
        }
        public void UpdatePriority(TKey key, double newPriority)
        {
            _dictionary[key] = newPriority;
        }
    }

    public static class PriorityQueueExtension
    {
        public static bool UpdateOrAdd<TKey>(this IPriorityQueue<TKey> queue, TKey node, double newPriority)
        {
            double oldPrice;

            bool nodeInQueue = queue.TryGetValue(node, out oldPrice);

            if (nodeInQueue == false || oldPrice > newPriority)
            {
                queue.UpdatePriority(node, newPriority);
                return true;
            }
            return false;
        }
    }
}
