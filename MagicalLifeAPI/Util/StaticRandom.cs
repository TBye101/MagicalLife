using System;
using System.Threading;

namespace MagicalLifeAPI.Util
{
    public static class StaticRandom
    {
        private static int seed = Environment.TickCount;

        private static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        public static int Rand(int min, int max)
        {
            return random.Value.Next(min, max);
        }
    }
}