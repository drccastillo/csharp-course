using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    // List
    public class DynamicArray<T> : IEnumerable<T>
    {
        private T[] _data;
        private int _count;

        public DynamicArray(int initialCapacity = 10)
        {
            _data = new T[initialCapacity];
            _count = 0;
        }

        public int Count => _count;

        public int Capacity => _data.Length;

        public T Get(int index)
        {
            ValidateIndex(index);
            return _data[index];
        }

        public void Set(int index, T value)
        {
            ValidateIndex(index);
            _data[index] = value;
        }

        public void Add(T item)
        {
            EnsureCapacity();
            _data[_count++] = item;
        }

        public void InsertAt(int index, T item)
        {
            if (index < 0 || index > _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            EnsureCapacity();

            for (int i = _count; i > index; i--)
            {
                _data[i] = _data[i - 1];
            }

            _data[index] = item;
            _count++;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = index; i < _count; i++)
            {
                _data[i] = _data[i + 1];
            }

            _data[_count - 1] = default!;
            _count--;
        }

        private void EnsureCapacity()
        {
            if (_count >= _data.Length)
            {
                int newCapacity = _data.Length * 2;
                T[] newData = new T[newCapacity];
                Array.Copy(_data, newData, _count);
                _data = newData;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        /// <summary>
        /// Removes all elements from the array.
        /// </summary>
        public void Clear()
        {
            _count = 0;
        }

        /// <summary>
        /// Determines whether the array contains a specific value.
        /// </summary>
        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence.
        /// </summary>
        public int IndexOf(T item)
        {
            var comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < _count; i++)
            {
                if (comparer.Equals(_data[i], item))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        public T this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
