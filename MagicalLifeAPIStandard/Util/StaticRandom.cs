using System;
using System.Threading;

namespace MagicalLifeAPI.Util
{
    public static class StaticRandom
    {
        private static int seed = Environment.TickCount;

        private static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        /// <summary>
        /// Returns a random number.
        /// </summary>
        /// <param name="min">Inclusive minimum.</param>
        /// <param name="max">Exclusive maximum.</param>
        /// <returns></returns>
        public static int Rand(int min, int max)
        {
            return random.Value.Next(min, max);
        }

        public static double Rand(double min, double max)
        {
            if (min < 0 || max < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid minimum or maximum range: Values must be greater than 0.");
            }

            return random.Value.NextDouble() * (max - min) + min;
        }
    }
}