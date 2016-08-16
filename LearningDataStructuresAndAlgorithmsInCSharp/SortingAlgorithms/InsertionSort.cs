using System;

namespace Learning.SortingAlgorithms
{
    class InsertionSort
    {
        
        public static void Init()
        {
            int[] array = new int[] { 1, 4, 3, 5, 6, 2 };
            int length = array.Length;

            for (int i = 1; i < length; i++)
            {
                int j = i;

                while (j > 0 && array[j - 1] > array[j])
                {
                    int k = j - 1;
                    int temp = array[k];
                    array[k] = array[j];
                    array[j] = temp;

                    j--;
                }
                //Print the output as string
                string text = string.Empty;
                for (int x = 0; x < array.Length; x++)
                {
                    text += array[x] + " ";
                }
                Console.WriteLine(text);
            }
        }

        //private void InsertionSort2(int lo, int hi)
        //{
        //    int i, j;
        //    Object t, ti;
        //    for (i = lo; i < hi; i++)
        //    {
        //        j = i;
        //        t = keys[i + 1];
        //        ti = (items != null) ? items[i + 1] : null;
        //        while (j >= lo && comparer.Compare(t, keys[j]) < 0)
        //        {
        //            keys[j + 1] = keys[j];
        //            if (items != null)
        //                items[j + 1] = items[j];
        //            j--;
        //        }
        //        keys[j + 1] = t;
        //        if (items != null)
        //            items[j + 1] = ti;
        //    }
        //}
    }
}
