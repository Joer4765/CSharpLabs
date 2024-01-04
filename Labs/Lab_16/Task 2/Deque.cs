namespace WpfApplication1
{
    internal class Node
    {
        public string Data { get; }
        public Node Prev { get; set; }
        public Node Next { get; set; }

        public Node(string data)
        {
            Data = data;
            Prev = null;
            Next = null;
        }
    }

    internal class Deque
    {
        private Node _head;
        private Node _tail;

        // public Deque()
        // {
        //     _head = null;
        //     _tail = null;
        //     Count = 0;
        // }

        // Display elements of the list
        public override string ToString()
        {
            var result = "";
            var current = _head;
            while (current != null)
            {
                result += current.Data + " <-> ";
                current = current.Next;
            }
            return result;
        }

        // Get the number of elements in the list
        public int Count { get; private set; }

        // Check if the list is empty
        public bool IsEmpty()
        {
            return _head == null;
        }

        // Insert elements into the list
        public void PushFront(string data)
        {
            var newNode = new Node(data);
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
            Count++;
        }

        public void PushBack(string data)
        {
            var newNode = new Node(data);
            if (_tail == null)
            {
                _head = _tail = newNode;
            }
            else
            {
                newNode.Prev = _tail;
                _tail.Next = newNode;
                _tail = newNode;
            }
            Count++;
        }

        public string PopFront()
        {
            if (IsEmpty())
            {
                return null; // or throw an exception
            }

            var node = _head;
            var nextNode = node.Next;
            if (nextNode != null)
            {
                nextNode.Prev = null;
            }
            _head = nextNode;
            Count--;
            return node.Data;
        }

        public string PopBack()
        {
            if (IsEmpty())
            {
                return null; // or throw an exception
            }

            var node = _tail;
            var prevNode = node.Prev;
            if (prevNode != null)
            {
                prevNode.Next = null;
            }
            _tail = prevNode;
            Count--;
            return node.Data;
        }

        public string Front()
        {
            return _head?.Data;
        }

        public string Back()
        {
            return _tail?.Data;
        }

        public void Clear()
        {
            _head = _tail = null;
            Count = 0;
        }
    }

}