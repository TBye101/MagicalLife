using System;
using System.Collections;
using System.Collections.Generic;
using ProtoBuf;

namespace MLAPI.DataTypes.Collection
{
    /// <summary>
    /// A protobuf-net compatible FIFO (first in first out) Queue class
    /// </summary>
    [ProtoContract]
    public class ProtoQueue<T> : ICollection<T>
    {
        [ProtoMember(1)]
        internal List<T> Data = new List<T>();

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public int Count
        {
            get
            {
                return this.Data.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            int length = this.Data.Count;

            for (int i = 0; i < length; i++)
            {
                yield return this.Data[i];
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Removes and returns the object at the beginning of this Queue.
        /// </summary>
        /// <returns>
        /// T:
        /// The object that is removed from the beginning of this Queue</returns>
        /// <exception cref="InvalidOperationException">The Queue is empty</exception>
        public T Dequeue()
        {
            if (Data.Count > 0)
            {
                T item = Data[0];
                Data.Remove(item);
                return item;
            }
            else
            {
                throw new InvalidOperationException("This collection is currently empty.");
            }
        }

        public void Enqueue(T item)
        {
            Data.Add(item);
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public void Clear()
        {
            Data.Clear();
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
            return Data.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"></see> to an <see cref="T:System.Array"></see>, starting at a particular <see cref="T:System.Array"></see> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"></see>. The <see cref="T:System.Array"></see> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Data.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns the object at the beginning of the Queue<T> without removing it.
        /// </summary>
        /// <returns>T:
        /// The object at the beginning of the Queue<T>.</returns>
        /// <exception cref="InvalidOperationException">The Queue is empty.</exception>
        public T Peek()
        {
            if (Data.Count > 0)
            {
                return Data[0];
            }
            else
            {
                throw new InvalidOperationException("This collection is currently empty.");
            }
        }

        /// <summary>
        /// To the array.
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            return this.Data.ToArray();
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        public void Add(T item)
        {
            Enqueue(item);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        /// true if <paramref name="item">item</paramref> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false. This method also returns false if <paramref name="item">item</paramref> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </returns>
        /// <exception cref="NotSupportedException"></exception>
        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }
    }
}