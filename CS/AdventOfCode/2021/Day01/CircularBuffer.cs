using System;
using System.Collections;
using System.Linq;
using System.Net.Sockets;

namespace Day01
{
    public class CircularBuffer : ICollection
    {
        private int[] _buff;
        private int _nextIndex = 0;
        public int Sum => _buff.Sum();

        public CircularBuffer(int buffSize, bool isSynchronized = false)
        {
            Count = buffSize;
            IsSynchronized = isSynchronized;
            _buff = new int[buffSize];
            SyncRoot = null!;
        }
        #region ICollection
        public IEnumerator GetEnumerator()
        {
            foreach (var val in _buff)
            {
                yield return val;
            }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count { get; }
        public bool IsSynchronized { get; }
        public object SyncRoot { get; }
        #endregion

        public void Add(int item)
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
    }
}