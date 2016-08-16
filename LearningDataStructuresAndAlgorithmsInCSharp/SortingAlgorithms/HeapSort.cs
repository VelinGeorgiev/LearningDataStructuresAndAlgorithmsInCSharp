using System;

namespace Learning.SortingAlgorithms
{
    public class HeapSort<T> where T : IComparable
    {
        public void Sort(T[] array)
        {
            int heapSize = array.Length;
            BuildHeap(array, heapSize);
            while (heapSize > 1)
            {
                Swap(array, 0, heapSize - 1);
                heapSize--;
                Heapify(array, heapSize, 0);
            }
        }

        private void BuildHeap(T[] array, int heapSize)
        {
            for (int i = array.Length / 2; i >= 0; i--)
            {
                Heapify(array, heapSize, i);
            }
        }

        private void Heapify(T[] array, int heapSize, int i)
        {
            int left = i * 2 + 1;
            int right = i * 2 + 2;
            int largest;
            if (left < heapSize && array[left].CompareTo(array[i]) > 0)
                largest = left;
            else
                largest = i;
            if (right < heapSize && array[right].CompareTo(array[largest]) > 0)
                largest = right;
            if (largest != i)
            {
                Swap(array, i, largest);
                Heapify(array, heapSize, largest);
            }
        }

        private void Swap(T[] array, int a, int b)
        {
            T temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
