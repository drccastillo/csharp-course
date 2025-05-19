namespace DataStructures
{
    // LinkedList
    public class CustomLinkedList<T> where T : IEquatable<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node? Next { get; set; } = null!;

            public Node(T value)
            {
                Value = value;
            }
        }

        private Node? _head;
        private Node? _tail;
        private int _count;

        public int Count => _count;

        public void AddFirst(T value)
        {
            var newNode = new Node(value) { Next = _head };
            _head = newNode;
            _tail ??= newNode;
            _count++;
        }

        public void AddLast(T value)
        {
            var newNode = new Node(value);

            if (_head == null)
            {
                _head = _tail = newNode;
            }
            else
            {
                _tail!.Next = newNode;
                _tail = newNode;
            }
            
            _count++;
        }

        // OPTIONAL: Enhance
        public bool TryRemove(T value)
        {
            if (_head == null)
            {
                return false;
            }

            if (_head.Value.Equals(value))
            {
                _head = _head.Next;

                if (_head == null)
                {
                    _tail = null;
                }

                _count--;

                return true;
            }

            Node? previous = _head;
            Node? current = _head.Next;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    previous.Next = current.Next;

                    if (current == _tail)
                    {
                        _tail = previous;
                    }

                    _count--;

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public bool Contains(T value)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var current = _head;

            for (int i = 0; i < index; i++)
            {
                current = current!.Next;
            }

            return current!.Value;
        }

        public T[] ToArray()
        {
            var result = new T[_count];
            // IMPLEMENTED: Turn to array the linked list

            int index = 0;
            var current = _head;
            while (current != null)
            {
                result[index++] = current.Value;
                current = current.Next;
            }

            return result;
        }
    }
}
