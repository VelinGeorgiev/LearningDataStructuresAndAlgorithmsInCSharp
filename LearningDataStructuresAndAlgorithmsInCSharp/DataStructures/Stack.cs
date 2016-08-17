using System;
using System.Collections;

namespace Learning.DataStructures
{
    /// <summary>
    /// Poor (Shorten) implementation based on the .NET http://referencesource.microsoft.com/#mscorlib/system/collections/stack.cs,6acda10c5f8b128e
    /// for testing purposes. For production, please use the .NET one.
    /// </summary>
    public class Stack
    {
        private Object[] _array; // Storage for stack elements
        private int _size; // Number of items in the stack.
        private int _version; // Used to keep enumerator in sync w/ collection.
        private const int _defaultCapacity = 10;

        public Stack()
        {
            _array = new Object[_defaultCapacity];
            _size = 0;
            _version = 0;
        }

        // Create a stack with a specific initial capacity.  The initial capacity
        // must be a non-negative number.
        public Stack(int initialCapacity)
        {
            if (initialCapacity < 0)
                throw new ArgumentOutOfRangeException(nameof(initialCapacity), "ArgumentOutOfRange_NeedNonNegNum");
            if (initialCapacity < _defaultCapacity)
                initialCapacity = _defaultCapacity; // Simplify doubling logic in Push.
            _array = new Object[initialCapacity];
            _size = 0;
            _version = 0;
        }

        // Fills a Stack with the contents of a particular collection.  The items are
        // pushed onto the stack in the same order they are read by the enumerator.
        //
        public Stack(ICollection col) : this((col == null ? 32 : col.Count))
        {
            if (col == null)
                throw new ArgumentNullException(nameof(col));
            
            IEnumerator en = col.GetEnumerator();
            while (en.MoveNext())
                Push(en.Current);
        }

        public virtual int Count => _size;

        // Removes all Objects from the Stack.
        public virtual void Clear()
        {
            Array.Clear(_array, 0, _size);
            // Don't need to doc this but we clear the elements so that the gc can reclaim the references.
            _size = 0;
            _version++;
        }

        public virtual Object Clone()
        {
            Stack s = new Stack(_size);
            s._size = _size;
            Array.Copy(_array, 0, s._array, 0, _size);
            s._version = _version;
            return s;
        }

        public virtual bool Contains(Object obj)
        {
            int count = _size;

            while (count-- > 0)
            {
                if (obj == null)
                {
                    if (_array[count] == null)
                        return true;
                }
                else if (_array[count] != null && _array[count].Equals(obj))
                {
                    return true;
                }
            }
            return false;
        }

        // Copies the stack into an array.
        public virtual void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1)
                throw new ArgumentException("Arg_RankMultiDimNotSupported");
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "ArgumentOutOfRange_NeedNonNegNum");
            if (array.Length - index < _size)
                throw new ArgumentException("Argument_InvalidOffLen");

            int i = 0;
            if (array is Object[])
            {
                Object[] objArray = (Object[]) array;
                while (i < _size)
                {
                    objArray[i + index] = _array[_size - i - 1];
                    i++;
                }
            }
            else
            {
                while (i < _size)
                {
                    array.SetValue(_array[_size - i - 1], i + index);
                    i++;
                }
            }
        }

        // Returns the top object on the stack without removing it.  If the stack
        // is empty, Peek throws an InvalidOperationException.
        public virtual Object Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("InvalidOperation_EmptyStack");
            return _array[_size - 1];
        }

        // Pops an item from the top of the stack.  If the stack is empty, Pop
        // throws an InvalidOperationException.
        public virtual Object Pop()
        {
            if (_size == 0)
                throw new InvalidOperationException("InvalidOperation_EmptyStack");
            _version++;
            Object obj = _array[--_size];
            _array[_size] = null; // Free memory quicker.
            return obj;
        }

        // Pushes an item to the top of the stack.
        // 
        public virtual void Push(Object obj)
        {
            if (_size == _array.Length)
            {
                Object[] newArray = new Object[2*_array.Length];
                Array.Copy(_array, 0, newArray, 0, _size);
                _array = newArray;
            }
            _array[_size++] = obj;
            _version++;
        }

    }
}
