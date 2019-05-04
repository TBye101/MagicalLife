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

        /// <summary>
        /// Returns the neighbors of the target in a 2D array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<T> GetNeighbors<T>(T[,] collection, Point2D target)
        {
            List<T> neighbors = new List<T>();

            int arrayWidth = collection.GetLength(0);
            int arrayHeight = collection.GetLength(1);
            if (IsInBounds(arrayWidth, arrayHeight, target.X, target.Y))
            {
                if (IsInBounds(arrayWidth, arrayHeight, target.X + 1, target.Y))
                {
                    neighbors.Add(collection[target.X + 1, target.Y]);
                }
                if (IsInBounds(arrayWidth, arrayHeight, target.X - 1, target.Y))
                {
                    neighbors.Add(collection[target.X - 1, target.Y]);
                }
                if (IsInBounds(arrayWidth, arrayHeight, target.X, target.Y + 1))
                {
                    neighbors.Add(collection[target.X, target.Y + 1]);
                }
                if (IsInBounds(arrayWidth, arrayHeight, target.X, target.Y - 1))
                {
                    neighbors.Add(collection[target.X, target.Y - 1]);
                }
                if (IsInBounds(arrayWidth, arrayHeight, target.X, target.Y))
                {
                    neighbors.Add(collection[target.X, target.Y]);
                }
                if (IsInBounds(arrayWidth, arrayHeight, target.X + 1, target.Y + 1))
                {
                    neighbors.Add(collection[target.X + 1, target.Y + 1]);
                }
                if (IsInBounds(arrayWidth, arrayHeight, target.X + 1, target.Y - 1))
                {
                    neighbors.Add(collection[target.X + 1, target.Y - 1]);
                }
                if (IsInBounds(arrayWidth, arrayHeight, target.X - 1, target.Y + 1))
                {
                    neighbors.Add(collection[target.X - 1, target.Y + 1]);
                }
                if (IsInBounds(arrayWidth, arrayHeight, target.X - 1, target.Y - 1))
                {
                    neighbors.Add(collection[target.X - 1, target.Y - 1]);
                }

                return neighbors;
            }
            else
            {
                throw new System.InvalidOperationException("The starting point must be within the bounds of the 2D array");
            }
        }

        /// <summary>
        /// Determines if a location is contained within a 2D array.
        /// </summary>
        private static bool IsInBounds(int arrayWidth, int arrayHeight, int x, int y)
        {
            return x < arrayWidth && y < arrayHeight;
        }
    }
}