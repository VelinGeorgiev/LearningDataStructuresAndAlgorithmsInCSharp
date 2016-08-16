using System;

namespace Learning.SortingAlgorithmsTest
{
    /// <summary>
    /// Test object.
    /// </summary>
    public class SortObject : IComparable
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public int CompareTo(object obj)
        {
            var sortObject = (SortObject) obj;
            if (Value == sortObject.Value) return 0;
            if (Value < sortObject.Value) return -1;
            return 1;
        }
    }
}
