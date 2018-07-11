using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MagicalLifeAPI.Util
{
    /// <summary>
    /// Holds some commonly used algorithms for use throughout the project.
    /// </summary>
    public static class Algorithms
    {
        /// <summary>
        /// Returns the index of the closest point to the target.
        /// Returns -1 if the list was empty.
        /// </summary>
        /// <param name="points"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int GetClosestPoint(List<Point> points, Point target)//TODO: Improve performance
        {
            int index = -1;
            int closestDistance = -1;

            int length = points.Count;

            for (int i = 0; i < length; i++)
            {
                if (index == -1)
                {
                    index = i;
                    closestDistance = MathUtil.GetDistanceFast(points[i], target);
                }
                else
                {
                    int newDistance = MathUtil.GetDistanceFast(points[i], target);

                    if (newDistance < closestDistance)
                    {
                        closestDistance = newDistance;
                        index = i;
                    }
                }
            }

            return index;
        }
    }
}