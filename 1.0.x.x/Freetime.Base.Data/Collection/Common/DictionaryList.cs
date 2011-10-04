using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Freetime.Base.Data.Collection.Common
{
    public abstract class DictionaryList<TKey, TType> : IList<TType>
    {

        private Dictionary<TKey, TType> m_dictionary;
        private List<TKey> m_keyList; 

        private Dictionary<TKey, TType> Container
        {
            get 
            { 
                m_dictionary = m_dictionary ?? new Dictionary<TKey, TType>();
                return m_dictionary;
            }
        }

        private List<TKey> KeyList
        {
            get 
            { 
                m_keyList = m_keyList ?? new List<TKey>();
                return m_keyList;
            }
        }

        public virtual bool IsReadOnly
        {
            get { return false; }
        }

        public TType this[int idx]
        {
            get
            {
                if (idx < 0 || idx > KeyList.Count - 1)
                    throw new IndexOutOfRangeException();
                var key = KeyList[idx];
                return Container[key];
            }
            set
            {
                if (idx < 0 || idx > KeyList.Count - 1)
                    throw new IndexOutOfRangeException();

                var key = KeyList[idx];
                var newKey = GetKeyValue(value);

                KeyList[idx] = newKey;
                Container.Remove(key);
                Container.Add(newKey, value);
            }
        }

        public void Add(TType item)
        {
            var key = GetKeyValue(item);
            if(Equals(key, null))
                throw new NullReferenceException("Key can't be null");
            if(Container.ContainsKey(key))
                throw new Exception(string.Format("Key {0}, already exists", key));
            
            KeyList.Add(key);
            Container.Add(key, item);
        }

        public void Insert(int idx, TType item)
        {
            var key = GetKeyValue(item);
            if (Equals(key, null))
                throw new NullReferenceException("Key can't be null");
            if (Container.ContainsKey(key))
                throw new Exception(string.Format("Key {0}, already exists", key));

            KeyList.Insert(idx, key);
            Container.Add(key, item);
        }

        public bool Remove(TType item)
        {
            var key = GetKeyValue(item);
            if (Equals(key, null))
                throw new NullReferenceException("Key can't be null");

            return Container.ContainsKey(key)
                   && (Container.Remove(key) || KeyList.Remove(key));
        }

        public void RemoveAt(int idx)
        {
            if(idx < 0 || idx > KeyList.Count - 1)
                throw new IndexOutOfRangeException();

            var key = KeyList[idx];
            KeyList.RemoveAt(idx);
            Container.Remove(key);
        }

        public int IndexOf(TType item)
        {
            var key = GetKeyValue(item);
            return KeyList.IndexOf(key);
        }

        public bool Contains(TType item)
        {
            var key = GetKeyValue(item);
            return KeyList.Contains(key);
        }

        private IEnumerable<TType> Enumerate()
        {
           return from x in Container select x.Value;
        }

        IEnumerator<TType> IEnumerable<TType>.GetEnumerator()
        {
            return Enumerate().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Enumerate().GetEnumerator();
        }


        public void CopyTo(TType[] container, int count)
        {

        }

        public int Count
        {
            get { return KeyList.Count; }
        }

        public void Clear()
        {
            KeyList.Clear();
            Container.Clear();
        }

        protected abstract TKey GetKeyValue(TType item);
    }
}
