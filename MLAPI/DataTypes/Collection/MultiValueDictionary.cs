using System.Collections;
using System.Collections.Generic;
using ProtoBuf;

namespace MLAPI.DataTypes.Collection
{
    /// <summary>
    /// A wrapper around dictionaries that allows for the simplification of having multiple values per key.
    /// </summary>
    [ProtoContract]
    public class MultiValueDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, List<TValue>>>
    {
        [ProtoMember(1)]
        private readonly Dictionary<TKey, List<TValue>> Data = new Dictionary<TKey, List<TValue>>();

        public List<TValue> this[TKey key]
        {
            get
            {
                return this.Data[key];
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                return this.Data.Keys;
            }
        }

        public Dictionary<TKey, List<TValue>>.ValueCollection Values
        {
            get
            {
                return this.Data.Values;
            }
        }

        public int Count
        {
            get
            {
                return this.Data.Count;
            }
        }

        public void Add(TKey key, TValue value)
        {
            this.Data.TryGetValue(key, out List<TValue> values);

            if (values == null)
            {
                List<TValue> temp = new List<TValue> { value };
                this.Data.Add(key, temp);
            }
            else
            {
                values.Add(value);
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            this.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this.Data.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            this.Data.TryGetValue(item.Key, out List<TValue> values);
            return values != null && values.Contains(item.Value);
        }

        public bool ContainsKey(TKey key)
        {
            return this.Data.ContainsKey(key);
        }

        public IEnumerator<KeyValuePair<TKey, List<TValue>>> GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }

        /// <summary>
        /// Removes all values which share the same key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(TKey key)
        {
            return this.Data.Remove(key);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            this.Data.TryGetValue(item.Key, out List<TValue> values);
            if (values != null)
            {
                return values.Remove(item.Value);
            }
            else
            {
                return false;
            }
        }

        public bool TryGetValue(TKey key, out List<TValue> value)
        {
            return this.Data.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }
    }
}