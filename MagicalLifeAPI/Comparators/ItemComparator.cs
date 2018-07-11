using MagicalLifeAPI.World.Base;
using System.Collections.Generic;

namespace MagicalLifeAPI.Comparators
{
    /// <summary>
    /// This comparators sorts items based upon ID, then world location.
    /// </summary>
    public class ItemComparator : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            if (x.ID != y.ID)
            {
                return x.ID.CompareTo(y);
            }
            else
            {
                if (x.Location.X != y.Location.X)
                {
                    return x.Location.X.CompareTo(y.Location.X);
                }
                if (x.Location.Y != y.Location.Y)
                {
                    return x.Location.Y.CompareTo(y.Location.Y);
                }

                return 0;
            }
        }
    }
}