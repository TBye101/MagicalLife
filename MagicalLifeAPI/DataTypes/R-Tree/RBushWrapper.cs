using ProtoBuf;
using RBush;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.DataTypes.R_Tree
{
    [ProtoContract]
    public class RBushWrapper<T> : IRTree<T>
        where T : ISpatialData
    {
        [ProtoMember(1)]
        internal RBush.RBush<T> RTree;

        public RBushWrapper()
        {
            this.RTree = new RBush.RBush<T>();
        }

        public int Count
        {
            get
            {
                return this.RTree.Count;
            }
        }

        public void BulkLoad(IEnumerable<T> items)
        {
            this.RTree.BulkLoad(items);
        }

        public void Clear()
        {
            this.RTree.Clear();
        }

        public void Delete(T item)
        {
            this.RTree.Delete(item);
        }

        public void Insert(T item)
        {
            this.RTree.Insert(item);
        }

        IReadOnlyList<T> IRTree<T>.Search()
        {
            return this.RTree.Search();
        }

        IReadOnlyList<T> IRTree<T>.Search(int minX, int minY, int maxX, int maxY)
        {
            return this.RTree.Search(new RBush.Envelope(minX, minY, maxX, maxY));
        }
    }
}
