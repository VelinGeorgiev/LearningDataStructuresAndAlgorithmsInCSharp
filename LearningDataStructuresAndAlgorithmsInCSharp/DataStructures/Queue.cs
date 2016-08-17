using System;
using System.Collections;

namespace Learning.DataStructures
{
    /// <summary>
    /// Poor (Shorten) implementation based on .NET http://referencesource.microsoft.com/#mscorlib/system/collections/queue.cs,f7cdfd0f848ca249
    /// for testing purposes. For production, please use the .NET one.
    /// </summary>
    public class Queue
    {
        private Object[] _array;
        private int _head;       // First valid element in the queue
        private int _tail;       // Last valid element in the queue
        private int _size;       // Number of elements.
        private int _growFactor; // 100 == 1.0, 130 == 1.3, 200 == 2.0
        private int _version;

        private const int _MinimumGrow = 4;

        // Creates a queue with room for capacity objects. The default initial
        // capacity and grow factor are used.
        public Queue() : this(32, (float)2.0){}

        // Creates a queue with room for capacity objects. The default grow factor
        // is used.
        public Queue(int capacity) : this(capacity, (float)2.0){}

        // Creates a queue with room for capacity objects. When full, the new
        // capacity is set to the old capacity * growFactor.
        public Queue(int capacity, float growFactor)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "ArgumentOutOfRange_NeedNonNegNum");
            if (!(growFactor >= 1.0 && growFactor <= 10.0))
                throw new ArgumentOutOfRangeException(nameof(growFactor), "ArgumentOutOfRange_QueueGrowFactor");

            _array = new Object[capacity];
            _head = 0;
            _tail = 0;
            _size = 0;
            _growFactor = (int)(growFactor * 100);
        }

        // Fills a Queue with the elements of an ICollection.  Uses the enumerator
        // to get each of the elements.
        public Queue(ICollection col) : this((col == null ? 32 : col.Count))
        {
            if (col == null)
                throw new ArgumentNullException(nameof(col));
            IEnumerator en = col.GetEnumerator();
            while (en.MoveNext())
                Enqueue(en.Current);
        }

        public virtual int Count => _size;

        public virtual Object Clone()
        {
            Queue q = new Queue(_size);
            q._size = _size;

            int numToCopy = _size;
            int firstPart = (_array.Length - _head < numToCopy) ? _array.Length - _head : numToCopy;
            Array.Copy(_array, _head, q._array, 0, firstPart);
            numToCopy -= firstPart;
            if (numToCopy > 0)
                Array.Copy(_array, 0, q._array, _array.Length - _head, numToCopy);

            q._version = _version;
            return q;
        }

        // Removes all Objects from the queue.
        public virtual void Clear()
        {
            if (_head < _tail)
                Array.Clear(_array, _head, _size);
            else
            {
                Array.Clear(_array, _head, _array.Length - _head);
                Array.Clear(_array, 0, _tail);
            }

            _head = 0;
            _tail = 0;
            _size = 0;
            _version++;
        }

        // CopyTo copies a collection into an Array, starting at a particular
        // index into the array.
        public virtual void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (array.Rank != 1)
                throw new ArgumentException("Arg_RankMultiDimNotSupported");
            if (index < 0)
                throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_Index");
            int arrayLen = array.Length;
            if (arrayLen - index < _size)
                throw new ArgumentException("Argument_InvalidOffLen");

            int numToCopy = _size;
            if (numToCopy == 0)
                return;
            int firstPart = (_array.Length - _head < numToCopy) ? _array.Length - _head : numToCopy;
            Array.Copy(_array, _head, array, index, firstPart);
            numToCopy -= firstPart;
            if (numToCopy > 0)
                Array.Copy(_array, 0, array, index + _array.Length - _head, numToCopy);
        }

        // Adds obj to the tail of the queue.
        public virtual void Enqueue(Object obj)
        {
            if (_size == _array.Length)
            {
                int newcapacity = (int)((long)_array.Length * (long)_growFactor / 100);
                if (newcapacity < _array.Length + _MinimumGrow)
                {
                    newcapacity = _array.Length + _MinimumGrow;
                }
                SetCapacity(newcapacity);
            }

            _array[_tail] = obj;
            _tail = (_tail + 1) % _array.Length;
            _size++;
            _version++;
        }

        // Removes the object at the head of the queue and returns it. If the queue
        // is empty, this method simply returns null.
        public virtual Object Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("InvalidOperation_EmptyQueue");

            Object removed = _array[_head];
            _array[_head] = null;
            _head = (_head + 1) % _array.Length;
            _size--;
            _version++;
            return removed;
        }

        // Returns the object at the head of the queue. The object remains in the
        // queue. If the queue is empty, this method throws an 
        // InvalidOperationException.
        public virtual Object Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("InvalidOperation_EmptyQueue");

            return _array[_head];
        }

        // Returns true if the queue contains at least one object equal to obj.
        // Equality is determined using obj.Equals().
        // Exceptions: ArgumentNullException if obj == null.
        public virtual bool Contains(Object obj)
        {
            int index = _head;
            int count = _size;

            while (count-- > 0)
            {
                if (obj == null)
                {
                    if (_array[index] == null)
                        return true;
                }
                else if (_array[index] != null && _array[index].Equals(obj))
                {
                    return true;
                }
                index = (index + 1) % _array.Length;
            }

            return false;
        }

        internal Object GetElement(int i)
        {
            return _array[(_head + i) % _array.Length];
        }

        // Iterates over the objects in the queue, returning an array of the
        // objects in the Queue, or an empty array if the queue is empty.
        // The order of elements in the array is first in to last in, the same
        // order produced by successive calls to Dequeue.
        public virtual Object[] ToArray()
        {
            Object[] arr = new Object[_size];
            if (_size == 0)
                return arr;

            if (_head < _tail)
            {
                Array.Copy(_array, _head, arr, 0, _size);
            }
            else
            {
                Array.Copy(_array, _head, arr, 0, _array.Length - _head);
                Array.Copy(_array, 0, arr, _array.Length - _head, _tail);
            }

            return arr;
        }


        // PRIVATE Grows or shrinks the buffer to hold capacity objects. Capacity
        // must be >= _size.
        private void SetCapacity(int capacity)
        {
            Object[] newarray = new Object[capacity];
            if (_size > 0)
            {
                if (_head < _tail)
                {
                    Array.Copy(_array, _head, newarray, 0, _size);
                }
                else
                {
                    Array.Copy(_array, _head, newarray, 0, _array.Length - _head);
                    Array.Copy(_array, 0, newarray, _array.Length - _head, _tail);
                }
            }

            _array = newarray;
            _head = 0;
            _tail = (_size == capacity) ? 0 : _size;
            _version++;
        }

        public virtual void TrimToSize()
        {
            SetCapacity(_size);
        }
    }
}
