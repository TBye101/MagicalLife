using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MagicalLifeAPI.Util
{
    public static class Extensions
    {
        public static void EnqueueCollection<T>(Queue<T> queue, IReadOnlyList<T> segments)
        {
            foreach (T item in segments)
            {
                queue.Enqueue(item);
            }
        }

        public static Microsoft.Xna.Framework.Point ParseString(this Point pt, string point)
        {
            //{ X:[Microsoft.Xna.Framework.Point.X] Y:[Microsoft.Xna.Framework.Point.Y]}
            string[] split = point.Split('Y');
            //{ X:[Microsoft.Xna.Framework.Point.X]
            //:[Microsoft.Xna.Framework.Point.Y]}
            string xString = split[0];
            string yString = split[1];

            string x = xString.Substring(xString.IndexOf('['), xString.LastIndexOf(']') - xString.IndexOf('['));
            string y = yString.Substring(yString.IndexOf('['), yString.LastIndexOf(']') - yString.IndexOf('['));

            return new Microsoft.Xna.Framework.Point(int.Parse(x), int.Parse(y));
        }
    }
}