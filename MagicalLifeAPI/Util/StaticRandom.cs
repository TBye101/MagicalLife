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
    }
}