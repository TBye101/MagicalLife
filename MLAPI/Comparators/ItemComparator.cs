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
                return 0;
            }
        }
    }
}