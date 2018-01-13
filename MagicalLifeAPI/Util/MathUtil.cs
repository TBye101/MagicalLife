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
    }
}