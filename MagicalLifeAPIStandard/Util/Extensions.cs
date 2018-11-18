using MagicalLifeAPI.DataTypes;
using System.Collections.Generic;

namespace MagicalLifeAPI.Util
{
    public static class Extensions
    {
        public static void EnqueueCollection<T>(ProtoQueue<T> queue, IReadOnlyList<T> segments)
        {
            foreach (T item in segments)
            {
                queue.Enqueue(item);
            }
        }

        public static Point2D ParseString(this Point2D pt, string Point2D)
        {
            string[] split = Point2D.Split('Y');
            string xString = split[0];
            string yString = split[1];

            string x = xString.Substring(xString.IndexOf('['), xString.LastIndexOf(']') - xString.IndexOf('['));
            string y = yString.Substring(yString.IndexOf('['), yString.LastIndexOf(']') - yString.IndexOf('['));

            return new Point2D(int.Parse(x), int.Parse(y));
        }
    }
}