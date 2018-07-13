using MagicalLifeAPI.DataTypes;
using System.Collections.Generic;

namespace MagicalLifeAPI.Util
{
    /// <summary>
    /// Holds some commonly used algorithms for use throughout the project.
    /// </summary>
    public static class Algorithms
    {
        /// <summary>
        /// Returns the index of the closest Point2D to the target.
        /// Returns -1 if the list was empty.
        /// </summary>
        /// <param name="Point2Ds"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int GetClosestPoint2D(List<Point2D> Point2Ds, Point2D target)//TODO: Improve performance
        {
            int index = -1;
            int closestDistance = -1;

            int length = Point2Ds.Count;

            for (int i = 0; i < length; i++)
            {
                if (index == -1)
                {
                    index = i;
                    closestDistance = MathUtil.GetDistanceFast(Point2Ds[i], target);
                }
                else
                {
                    int newDistance = MathUtil.GetDistanceFast(Point2Ds[i], target);

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