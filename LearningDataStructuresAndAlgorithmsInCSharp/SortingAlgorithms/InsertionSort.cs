using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning
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
    }
}
