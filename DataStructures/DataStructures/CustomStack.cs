namespace DataStructures
{
    // LIFO
    public class CustomStack<T>
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

        private Node? _top;
        private int _count;

        public int Count => _count;

        public void Push(T item)
        {
            var newNode = new Node(item) { Next = _top };
            _top = newNode;
            _count++;
        }

        public T Pop()
        {
            if (_top == null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            T value = _top.Value;
            _top = _top.Next;
            _count--;

            return value;
        }

        public T Peek()
        {
            if (_top == null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return _top.Value;
        }

        public bool IsEmpty() => _count == 0;

        public T[] ToArray()
        {
            var result = new T[_count];
            var current = _top;
            int i = 0;
            while (current != null)
            {
                result[i++] = current.Value;
                current = current.Next;
            }

            return result;
        }
    }
}
