using System.Threading;

namespace DataStructures
{
    // DoublyLinkedList
    public class DoublyLinkedList<T> where T : IEquatable<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; } = null!;
            public Node Prev { get; set; } = null!;

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
            var newNode = new Node(value);

            if (_head == null)
            {
                _head = _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
            }

            _count++;
        }

        public void AddLast(T value)
        {
            var newNode = new Node(value);

            if (_tail == null)
            {
                _head = _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                newNode.Prev = _tail;
                _tail = newNode;
            }

            _count++;
        }

        public bool TryRemove(T value)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (current.Prev != null)
                    {
                        current.Prev.Next = current.Next;
                    }
                    else
                    {
                        _head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev!;
                    }
                    else
                    {
                        _tail = current.Prev;
                    }

                    _count--;

                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        // IMPLEMENTED: Modify using _tail
        public bool Contains(T value)
        {
            var left = _head;
            var right = _tail;

            while (left != null && right != null)
            {
                if (left.Value.Equals(value) || right.Value.Equals(value))
                {
                    return true;
                }

                if (left == right || left.Next == right)
                {
                    break;
                }

                left = left.Next;
                right = right.Prev;
            }

            return false;
        }

        // IMPLEMENTED: Modify using _tail
        public T Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (index < _count / 2)
            {
                var current = _head;
                for (int i = 0; i < index; i++)
                {
                    current = current!.Next;
                }

                return current!.Value;
            }

            var node = _tail!;
            for (int i = _count - 1; i > index; i--)
            {
                node = node.Prev;
            }

            return node.Value;
        }

        // IMPLEMENTED: Complete the to array method using head
        public T[] ToArray()
        {
            var result = new T[_count];
            var current = _head;
            int i = 0;
            while (current != null)
            {
                result[i++] = current.Value;
                current = current.Next;
            }

            return result;
        }

        // IMPLEMENTED: Complete the to reversed array using tail
        public T[] ToReversedArray()
        {
            var result = new T[_count];
            var current = _tail;
            int i = 0;
            while (current != null)
            {
                result[i++] = current.Value;
                current = current.Prev;
            }

            return result;
        }
    }
}
