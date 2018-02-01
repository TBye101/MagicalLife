using DijkstraAlgorithm.Pathing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
