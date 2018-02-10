using DijkstraAlgorithm.Pathing;
using System.Collections.Generic;

namespace MagicalLifeAPI.Util
{
    public static class Extensions
    {
        public static void EnqueueCollection<T>(Queue<T> queue, IReadOnlyList<T> segments)
        {
            foreach (T item in segments)
            {
                queue.Enqueue(item);
            }
        }
    }
}