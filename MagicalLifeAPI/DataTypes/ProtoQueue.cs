using MagicalLifeAPI.Error.InternalExceptions;
using ProtoBuf;
using System.Collections;
using System.Collections.Generic;

namespace MagicalLifeAPI.DataTypes
{
    /// <summary>
    /// A protobuf-net compatible FIFO (first in first out) Queue class
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

            for (int i = 0; i < length; i++)
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
                T item = this.Data[0];
                this.Data.Remove(item);
                return item;
            }
            else
            {
                throw new CollectionEmptyException();
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
                return this.Data[0];
            }
            else
            {
                throw new CollectionEmptyException();
            }
        }

        public T[] ToArray()
        {
            return this.Data.ToArray();
        }
    }
}