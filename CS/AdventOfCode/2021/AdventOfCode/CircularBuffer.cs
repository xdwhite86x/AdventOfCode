using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class CircularBuffer<T> : ICollection<T>
    {
        private T[] _buff;
        private int _nextIndex = 0;
        
        
        public CircularBuffer(int buffSize, bool isSynchronized = false)
        {
            Count = buffSize;
            _buff = new T[buffSize];
        }
        #region ICollection
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T val in _buff)
            {
                yield return val;
            }
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; }
        public bool IsReadOnly { get; }
        
        #endregion

        public void Add(T item)
        {
            if (!(_buff is null) && _buff.Length == Count) 
            {
                if (_nextIndex < Count)
                {
                    _buff[_nextIndex] = item;
                }
                else
                {
                    _buff[0] = item;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(Count),
                    "Count and buffer length differ Object has been corrupted Abort");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}