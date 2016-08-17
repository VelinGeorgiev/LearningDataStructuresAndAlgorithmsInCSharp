using System;

namespace Learning.DataStructures
{
    class ArrayStructure
    {
        private int[] theArray = new int[50]; // Creates an array with 50 inde
        private int arraySize = 10; // Elements in theArray

        public int[] GetTheArray()
        {
            return theArray;
        }
        public int GetArraySize()
        {
            return arraySize;
        }

        // Gets value at provided index
        public int GetValueAtIndex(int index)
        {
            if (index < arraySize) return theArray[index];
            return 0;
        }

        public bool DoesArrayContainThisValue(int searchValue)
        {

            bool valueInArray = false;
            for (int i = 0; i < arraySize; i++)
            {
                if (theArray[i] == searchValue)
                {
                    valueInArray = true;
                }
            }
            return valueInArray;
        }

        public void DeleteIndex(int index)
        {
            if (index < arraySize)
            {
                // Overwrite the value for the supplied index
                // and then keep overwriting every index that follows
                // until you get to the last index in the array
                for (int i = index; i < (arraySize - 1); i++)
                {
                    theArray[i] = theArray[i + 1];
                }
                arraySize--;
                //theArray[arraySize] = default(int);
            }
        }
        public void InsertValue(int value)
        {
            if (arraySize < 50)
            {
                theArray[arraySize] = value;
                arraySize++;
            }
        }

        public string LinearSearchForValue(int value)
        {

            bool valueInArray = false;
            string indexsWithValue = "";
            Console.Write("The Value was Found in the Following Indexes: ");

            for (int i = 0; i < arraySize; i++)
            {
                if (theArray[i] == value)
                {
                    valueInArray = true;
                    Console.Write(i + " ");
                    indexsWithValue += i + " ";
                }
            }

            if (!valueInArray)
            {
                indexsWithValue = "None";
                Console.Write(indexsWithValue);
            }
            return indexsWithValue;
        }

        // This bubble sort will sort everything from 
        // smallest to largest
        public void BubbleSort()
        {
            // i starts at the end of the Array
            // As it is decremented all indexes greater
            // then it are sorted
            for (int i = arraySize - 1; i > 1; i--)
            {
                // The inner loop starts at the beginning of 
                // the array and compares each value next to each 
                // other. If the value is greater then they are 
                // swapped
                for (int j = 0; j < i; j++)
                {
                    if (theArray[j] > theArray[j + 1])
                    {
                        //swapValues(j, j + 1);
                        int tempJ = theArray[j];
                        theArray[j] = theArray[j + 1];
                        theArray[j + 1] = tempJ;
                    }
                }
            }
        }

        // Fills the Array with random values
        public void GenerateRandomArray()
        {
            Random random = new Random();
            for (int i = 0; i < arraySize; i++)
            {
                // Random number 10 through 19
                theArray[i] = random.Next(10, 19);
            }
        }
    }
}
