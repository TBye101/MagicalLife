using DijkstraAlgorithm.Pathing;
using System.Collections.Generic;

namespace MagicalLifeAPI.Util
{
    public static class Extensions
    {
        public static void EnqueueCollection(System.Collections.Generic.Queue<PathSegment> queue, IReadOnlyList<PathSegment> segments)
        {
            foreach (PathSegment item in segments)
            {
                queue.Enqueue(item);
            }
        }
    }
}