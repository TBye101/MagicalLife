using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.DataTypes.R_Tree
{
    /// <summary>
    /// Used to wrap R-Tree implementations, so they are easier to change.
    /// </summary>
    public interface IRTree<T>
    {
        int Count { get; }

        void BulkLoad(IEnumerable<T> items);
        void Clear();
        void Delete(T item);
        void Insert(T item);
        IReadOnlyList<T> Search();
        IReadOnlyList<T> Search(int minX, int minY, int maxX, int maxY);
    }
}
