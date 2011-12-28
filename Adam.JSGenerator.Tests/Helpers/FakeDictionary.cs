using System.Collections;
using System.Collections.Generic;

namespace Adam.JSGenerator.Tests.Helpers
{
    public class FakeDictionary<TK, TV> : IDictionary<TK, TV>
    {
        private readonly IDictionary<TK, TV> _internal = new Dictionary<TK, TV>();

        public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator()
        {
            return _internal.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<TK, TV> item)
        {
            _internal.Add(item);
        }

        public void Clear()
        {
            _internal.Clear();
        }

        public bool Contains(KeyValuePair<TK, TV> item)
        {
            return _internal.Contains(item);
        }

        public void CopyTo(KeyValuePair<TK, TV>[] array, int arrayIndex)
        {
            _internal.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TK, TV> item)
        {
            return _internal.Remove(item);
        }

        public int Count
        {
            get
            {
                return _internal.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return _internal.IsReadOnly;
            }
        }

        public bool ContainsKey(TK key)
        {
            return _internal.ContainsKey(key);
        }

        public void Add(TK key, TV value)
        {
            _internal.Add(key, value);
        }

        public bool Remove(TK key)
        {
            return _internal.Remove(key);
        }

        public bool TryGetValue(TK key, out TV value)
        {
            return _internal.TryGetValue(key, out value);
        }

        public TV this[TK key]
        {
            get
            {
                return _internal[key];
            }
            set
            {
                _internal[key] = value;
            }
        }

        public ICollection<TK> Keys
        {
            get
            {
                return _internal.Keys;
            }
        }

        public ICollection<TV> Values
        {
            get
            {
                return _internal.Values;
            }
        }
    }
}
