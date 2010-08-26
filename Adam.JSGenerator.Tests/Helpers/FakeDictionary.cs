using System.Collections;
using System.Collections.Generic;

namespace Adam.JSGenerator.Tests.Helpers
{
    public class FakeDictionary<TK, TV> : IDictionary<TK, TV>
    {
        private readonly IDictionary<TK, TV> _Internal = new Dictionary<TK, TV>();

        public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator()
        {
            return _Internal.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<TK, TV> item)
        {
            _Internal.Add(item);
        }

        public void Clear()
        {
            _Internal.Clear();
        }

        public bool Contains(KeyValuePair<TK, TV> item)
        {
            return _Internal.Contains(item);
        }

        public void CopyTo(KeyValuePair<TK, TV>[] array, int arrayIndex)
        {
            _Internal.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TK, TV> item)
        {
            return _Internal.Remove(item);
        }

        public int Count
        {
            get
            {
                return _Internal.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return _Internal.IsReadOnly;
            }
        }

        public bool ContainsKey(TK key)
        {
            return _Internal.ContainsKey(key);
        }

        public void Add(TK key, TV value)
        {
            _Internal.Add(key, value);
        }

        public bool Remove(TK key)
        {
            return _Internal.Remove(key);
        }

        public bool TryGetValue(TK key, out TV value)
        {
            return _Internal.TryGetValue(key, out value);
        }

        public TV this[TK key]
        {
            get
            {
                return _Internal[key];
            }
            set
            {
                _Internal[key] = value;
            }
        }

        public ICollection<TK> Keys
        {
            get
            {
                return _Internal.Keys;
            }
        }

        public ICollection<TV> Values
        {
            get
            {
                return _Internal.Values;
            }
        }
    }
}
