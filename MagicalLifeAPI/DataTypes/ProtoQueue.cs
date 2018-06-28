using ProtoBuf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.DataTypes
{
    /// <summary>
    /// A protobuf-net compatible Queue class.
    /// </summary>
    [ProtoContract]
    public class ProtoQueue<T> : IEnumerable<T>
    {
        [ProtoMember(1)]
        internal List<T> Data = new List<T>();

        public int Count
        {
            get
            {
                return this.Data.Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int length = this.Data.Count;

            for (int i = length; i > 0; i--)
            {
                yield return this.Data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T Dequeue()
        {
            if (this.Data.Count > 0)
            {
                T item = this.Data[this.Data.Count - 1];
                this.Data.Remove(item);
                return item;
            }
            else
            {
                throw new Exception("Queue empty!");
            }
        }

        public void Enqueue(T item)
        {
            this.Data.Add(item);
        }

        public void Clear()
        {
            this.Data.Clear();
        }

        public bool Contains(T item)
        {
            return this.Data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.Data.CopyTo(array, arrayIndex);
        }

        public T Peek()
        {
            if (this.Data.Count > 0)
            {
                return this.Data[this.Data.Count - 1];
            }
            else
            {
                throw new Exception("Queue empty!");
            }
        }

        public T[] ToArray()
        {
            return this.Data.ToArray();
        }
    }
}
