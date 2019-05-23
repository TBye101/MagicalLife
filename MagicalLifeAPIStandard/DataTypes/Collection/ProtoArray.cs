using System;
using System.Collections;
using System.Collections.Generic;

namespace MagicalLifeAPI.DataTypes
{
    /// <summary>
    /// An 2D array that should have the basic functions of a normal 2D array, but must be compatible with Protobuf-net.
    /// </summary>
    [ProtoBuf.ProtoContract(IgnoreListHandling = true)]
    public class ProtoArray<T> : ICollection<T>, ICollection
    {
        /// <summary>
        /// The width of this array.
        /// </summary>
        [ProtoBuf.ProtoMember(1)]
        public int Width { get; private set; }

        /// <summary>
        /// The height of this array.
        /// </summary>
        [ProtoBuf.ProtoMember(2)]
        public int Height { get; private set; }

        /// <summary>
        /// The actual data this array holds.
        /// </summary>
        [ProtoBuf.ProtoMember(3)]
        public T[] Data { get; set; }

        public int Count => Data.Length;

        public bool IsReadOnly => Data.IsReadOnly;

        public bool IsSynchronized => Data.IsSynchronized;

        public object SyncRoot => Data.SyncRoot;

        public ProtoArray(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Data = new T[width * height];
        }

        public ProtoArray(int width, int height, T[] data) : this(width, height)
        {
            this.Data = data;
        }

        public ProtoArray()
        {
        }

        public T this[int x, int y]
        {
            get
            {
                int index = (x * this.Width) + y;
                return this.Data[index];
            }

            set
            {
                int index = (x * this.Width) + y;
                this.Data[index] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        public void Add(T item)
        {
            Data[Data.Length - 1] = item;
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public void Clear()
        {
            Data = new T[Data.Length];
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        /// true if <paramref name="item">item</paramref> is found in the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false.
        /// </returns>
        public bool Contains(T item)
        {
            foreach(T element in Data)
            {
                if(item.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Data.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        /// true if <paramref name="item">item</paramref> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false. This method also returns false if <paramref name="item">item</paramref> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </returns>
        public bool Remove(T item)
        {
            if(!Contains(item))
            {
                return false;
            }
            else
            {
                for( int i = 0; i < Data.Length; i++)
                {
                    if(Data[i].Equals(item))
                    {
                        Data[i] = default;
                        return true;
                    }
                }
                return false;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
           foreach(T item in Data)
           {
                yield return item;
           }
        }

        public void CopyTo(Array array, int index)
        {
            Data.CopyTo(array, index);
        }
    }
}