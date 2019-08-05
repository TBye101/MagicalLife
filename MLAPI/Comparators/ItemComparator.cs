using System.Collections.Generic;
using MLAPI.World.Base;

namespace MLAPI.Comparators
{
    /// <summary>
    /// This comparators sorts items based upon ID, then world location.
    /// </summary>
    public class ItemComparator : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            if (x.Id != y.Id)
            {
                return x.Id.CompareTo(y);
            }
            else
            {
                return 0;
            }
        }
    }
}