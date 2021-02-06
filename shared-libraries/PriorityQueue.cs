using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibraries
{
    // Shamelessly lifted from https://visualstudiomagazine.com/articles/2012/11/01/priority-queues-with-c.aspx
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private readonly List<T> _data;

        public PriorityQueue()
        {
            _data = new List<T>();
        }

        public void Enqueue(T item)
        {
            _data.Add(item);
            int childIndex = _data.Count - 1;
            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;

                if (_data[childIndex].CompareTo(_data[parentIndex]) >= 0) break;

                T tmp = _data[childIndex];
                _data[childIndex] = _data[parentIndex];
                _data[parentIndex] = tmp;
                childIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            int lastIndex = _data.Count - 1;
            T frontItem = _data[0];
            _data[0] = _data[lastIndex];
            _data.RemoveAt(lastIndex);

            --lastIndex;
            int parentIndex = 0;
            while (true)
            {
                int leftChildIndex = parentIndex * 2 + 1;
                if (leftChildIndex > lastIndex) break;

                int rightChildIndex = leftChildIndex + 1;
                if (rightChildIndex <= lastIndex && _data[rightChildIndex].CompareTo(_data[leftChildIndex]) < 0)
                {
                    leftChildIndex = rightChildIndex;
                }

                if (_data[parentIndex].CompareTo(_data[leftChildIndex]) <= 0) break;

                T tmp = _data[parentIndex];
                _data[parentIndex] = _data[leftChildIndex];
                _data[leftChildIndex] = tmp;
                parentIndex = leftChildIndex;
            }
            return frontItem;
        }

        public T Peek()
        {
            return _data[0];
        }

        public int Count()
        {
            return _data.Count;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            for (int i = 0; i < _data.Count; ++i)
            {
                builder.Append(_data[i].ToString() + " ");
            }

            builder.Append("count = " + _data.Count);

            return builder.ToString();
        }

        public bool IsConsistent()
        {
            if (_data.Count == 0) return true;
            int lastIndex = _data.Count - 1;
            for (int parentIndex = 0; parentIndex < _data.Count; ++parentIndex)
            {
                int leftChildIndex = 2 * parentIndex + 1;
                int rightChildIndex = 2 * parentIndex + 2;

                if (leftChildIndex <= lastIndex && _data[parentIndex].CompareTo(_data[leftChildIndex]) > 0)
                {
                    return false;
                }

                if (rightChildIndex <= lastIndex && _data[parentIndex].CompareTo(_data[rightChildIndex]) > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}