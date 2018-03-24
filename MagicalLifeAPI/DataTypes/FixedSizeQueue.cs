using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.DataTypes
{
    /// <summary>
    /// Shamelessly borrowed from https://stackoverflow.com/a/10299662/5294414
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FixedSizedQueue<T> : ConcurrentQueue<T>
    {
        private readonly object syncObject = new object();

        public int Size { get; private set; }

        public FixedSizedQueue(int size)
        {
            this.Size = size;
        }

        public new void Enqueue(T obj)
        {
            base.Enqueue(obj);
            lock (this.syncObject)
            {
                while (base.Count > this.Size)
                {
                    base.TryDequeue(out T outObj);
                }
            }
        }
    }
}
