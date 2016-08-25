using System;

namespace Learning.DataStructures
{
    // http://quiz.geeksforgeeks.org/binary-heap/
    public class MinHeap
    {
        readonly int[] _harr; // pointer to array of elements in heap
        readonly int _capacity; // maximum possible size of min heap
        int _heapSize; // Current number of elements in min heap

        public MinHeap(int cap)
        {
            _heapSize = 0;
            _capacity = cap;
            _harr = new int[cap];
        }

        // Inserts a new key 'k'
        public void InsertKey(int k)
        {
            if (_heapSize == _capacity) throw new OverflowException("Overflow: Could not insertKey");

            // First insert the new key at the end
            _heapSize++;
            int i = _heapSize - 1;
            _harr[i] = k;

            // Fix the min heap property if it is violated
            while (i != 0 && _harr[parent(i)] > _harr[i])
            {
                Swap(_harr, i, parent(i));
                i = parent(i);
            }
        }

        // Decreases value of key at index 'i' to new_val.  It is assumed that
        // new_val is smaller than harr[i].
        public void DecreaseKey(int i, int newVal)
        {
            _harr[i] = newVal;
            while (i != 0 && _harr[parent(i)] > _harr[i])
            {
                Swap(_harr, i, parent(i));
                i = parent(i);
            }
        }

        // Method to remove minimum element (or root) from min heap
        public int ExtractMin()
        {
            if (_heapSize <= 0)
                return int.MaxValue;
            if (_heapSize == 1)
            {
                _heapSize--;
                return _harr[0];
            }

            // Store the minimum vakue, and remove it from heap
            int root = _harr[0];
            _harr[0] = _harr[_heapSize - 1];
            _heapSize--;
            MinHeapify(0);

            return root;
        }

        // This function deletes key at index i. It first reduced value to minus
        // infinite, then calls extractMin()
        public void DeleteKey(int i)
        {
            DecreaseKey(i, int.MinValue);
            ExtractMin();
        }

        // A recursive method to heapify a subtree with root at given index
        // This method assumes that the subtrees are already heapified
        public void MinHeapify(int i)
        {
            int l = left(i);
            int r = right(i);
            int smallest = i;
            if (l < _heapSize && _harr[l] < _harr[i])
                smallest = l;
            if (r < _heapSize && _harr[r] < _harr[smallest])
                smallest = r;
            if (smallest != i)
            {
                Swap(_harr, i, smallest);
                MinHeapify(smallest);
            }
        }

        public int GetMin() { return _harr[0]; }

        private int parent(int i) { return (i - 1) / 2; }

        // to get index of left child of node at index i
        private int left(int i) { return (2 * i + 1); }

        // to get index of right child of node at index i
        private int right(int i) { return (2 * i + 2); }

        // A utility function to swap two elements
        private void Swap(int[] arr, int i, int smallest)
        {
            int temp = arr[i];
            arr[i] = arr[smallest];
            arr[smallest] = temp;
        }
    }

    // A min heap node
    struct MinHeapNode
    {
        public int element; // The element to be stored
        public int i; // index of the array from which the element is taken
        public int j; // index of the next element to be picked from array
    };
}
