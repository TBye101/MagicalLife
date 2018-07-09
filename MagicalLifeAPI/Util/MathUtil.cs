using MagicalLifeAPI.DataTypes;
using Microsoft.Xna.Framework;
using System;

namespace MagicalLifeAPI.Util
{
    /// <summary>
    /// Holds various math utilities.
    /// </summary>
    public static class MathUtil
    {
        /// <summary>
        /// Rounds the double value to a integer using the banker's round.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Round(double value)
        {
            return (int)Math.Round(value);
        }

        /// <summary>
        /// A faster way of calculating the distance between two points.
        /// Returns a value that can be used to compare the distance between two points.
        /// While the value returned is not actually the correct distance, it is still valid for comparing distances.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int GetDistanceFast(Point a, Point b)
        {
            return Convert.ToInt32(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }

        /// <summary>
        /// Returns the distance between point a and point b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double GetDistance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }

        public static float GetDistance(PointFloat a, Point b)
        {
            return (float)Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }
    }
}