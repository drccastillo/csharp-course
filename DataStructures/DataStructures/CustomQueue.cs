namespace DataStructures
{
    // FIFO
    public class CustomQueue<T>
    {
        // TODO: Implement queue (you can modify the implementation, not the names of the methods)
        private T[] _array = new T[4];
        private int _head;
        private int _tail;
        private int _count;

        public int Count => _count;

        public void Enqueue(T item)
        {
            if (_count == _array.Length)
            {
                var newArray = new T[_array.Length * 2];
                for (int i = 0; i < _count; i++)
                {
                    newArray[i] = _array[(_head + i) % _array.Length];
                }
                _array = newArray;
                _head = 0;
                _tail = _count;
            }

            _array[_tail] = item;
            _tail = (_tail + 1) % _array.Length;
            _count++;
        }

        public T Dequeue()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var result = _array[_head];
            _array[_head] = default!;
            _head = (_head + 1) % _array.Length;
            _count--;
            return result;
        }

        public T Peek()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return _array[_head];
        }

        public bool IsEmpty() => _count == 0;

        public T[] ToArray()
        {
            var result = new T[_count];
            for (int i = 0; i < _count; i++)
            {
                result[i] = _array[(_head + i) % _array.Length];
            }

            return result;
        }
    }
}
