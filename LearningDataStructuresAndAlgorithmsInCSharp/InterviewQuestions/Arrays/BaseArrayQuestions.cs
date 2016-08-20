using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.InterviewQuestions.Arrays
{
    public class BaseArrayQuestions
    {
        // A recursive function to replace all 0s with 5s in an input number
        // It doesn't work if input number itself is 0.
        private int Convert0To5Rec(int num)
        {
            if (num == 0) return 0;

            // Extraxt the last digit and change it if needed
            int digit = num % 10;
            if (digit == 0) digit = 5;

            // Convert remaining digits and append the last digit
            return Convert0To5Rec(num / 10) * 10 + digit;
        }

        // It handles 0 and calls convert0To5Rec() for other numbers
        public int Convert0To5(int num)
        {
            if (num == 0) return 5;
            return Convert0To5Rec(num);
        }

        // Given an input string, write a function that returns the Run Length Encoded string for the input string.
        // For example, if the input string is “wwwwaaadexxxxxx”, then the function should return “w4a3d1e1x6″
        // Time Complexity: O(n)
        // http://www.geeksforgeeks.org/run-length-encoding/
        public string RunLengthEncoding(string s)
        {
            string result = string.Empty;
            int i = 0;

            while(i < s.Length)
            {
                char letter = s[i];
                int count = 0;

                do
                {
                    count++;
                    i++;
                } while (i < s.Length && s[i] == letter);

                result += letter;
                result += count;
            }

            return result;
        }

        // Returns floor of square root of x
        // Time Complexity: O(Log x)
        // http://www.geeksforgeeks.org/square-root-of-an-integer/
        public int FloorSqrt(int x)
        {
            if (x == 0 || x == 1) return x;

            // Do Binary Search for floor(sqrt(x))
            // 'start' = 0 and 'end' = x/2. Floor of square root of x cannot be more than x/2 when x > 1.
            int start = 0, end = x/2, ans = 0;
            while (start <= end)
            {
                int mid = (start + end) / 2;

                // If x is a perfect square
                if (mid * mid == x) return mid;

                // Since we need floor, we update answer when mid*mid is
                // smaller than x, and move closer to sqrt(x)
                if (mid * mid < x)
                {
                    start = mid + 1;
                    ans = mid;
                }
                else   // If mid*mid is greater than x
                    end = mid - 1;
            }
            return ans;
        }

        public void MinimizeStringValue()
        {
            
        }

        // Time Complexity: O(n)
        // Auxiliary Space: O(1)
        // TODO: review later . too many rules.
        // Returns count of all possible groups that can be formed from elements
        // of a[].

        public int Findgroups(int[] arr, int n)
        {
            // Create an array C[3] to store counts of elements with remainder
            // 0, 1 and 2.  c[i] would store count of elements with remainder i
            int[] c = new int[] { 0, 0, 0 };
            int i;

            int res = 0; // To store the result

            // Count elements with remainder 0, 1 and 2
            for (i = 0; i < n; i++)
                c[arr[i] % 3]++;

            // Case 3.a: Count groups of size 2 from 0 remainder elements
            res += ((c[0] * (c[0] - 1)) >> 1);

            // Case 3.b: Count groups of size 2 with one element with 1
            // remainder and other with 2 remainder
            res += c[1] * c[2];

            // Case 4.a: Count groups of size 3 with all 0 remainder elements
            res += (c[0] * (c[0] - 1) * (c[0] - 2)) / 6;

            // Case 4.b: Count groups of size 3 with all 1 remainder elements
            res += (c[1] * (c[1] - 1) * (c[1] - 2)) / 6;

            // Case 4.c: Count groups of size 3 with all 2 remainder elements
            res += ((c[2] * (c[2] - 1) * (c[2] - 2)) / 6);

            // Case 4.c: Count groups of size 3 with different remainders
            res += c[0] * c[1] * c[2];

            // Return total count stored in res
            return res;
        }

        // This function uses queue data structure to print binary numbers
        public void GeneratePrintBinary(int n, IList<string> result)
        {
            // Create an empty queue of strings
            Queue<string> q = new Queue<string>();

            // Enqueue the first binary number
            q.Enqueue("1");

            // This loops is like BFS of a tree with 1 as root
            // 0 as left child and 1 as right child and so on
            while (n-- > 0)
            {
                string qItem = q.Dequeue();

                Console.Write(qItem);
                result.Add(qItem);

                string temp = qItem;  // Store qItem before changing it

                // Append "0" to qItem and enqueue it
                q.Enqueue(qItem += "0");

                // Append "1" to temp and enqueue it. Note that temp contains the previous front
                q.Enqueue(temp += "1");
            }
        }

        // Time Complexity: O(n)
        public int NumberOccurringOddNumberTimes(int[] ar)
        {
            int i;
            int res = 0;
            for (i = 0; i < ar.Length; i++)
                res = res ^ ar[i];

            return res;
        }

        // Time Complexity: O(n)
        public int NumberOccurringOddNumberTimesHashing(int[] ar)
        {
            int i;
            int res = 0;
            for (i = 0; i < ar.Length; i++)
                res = res ^ ar[i];

            return res;
        }


        // http://www.geeksforgeeks.org/calculate-angle-hour-hand-minute-hand/
        public int CalculateHourMinuteAngle(int h, int m)
        {
            // validate the input
            if (h < 0 || m < 0 || h > 12 || m > 60) throw new ArgumentException("Wrong input");

            if (h == 12) h = 0;
            if (m == 60) m = 0;

            // Calculate the angles moved by hour and minute hands
            // with reference to 12:00.
            int hourAngle = (int) (0.5 * (h * 60 + m));
            int minuteAngle = 6 * m;

            // Find the difference between two angles.
            int angle = Math.Abs(hourAngle - minuteAngle);

            // Return the smaller angle of two possible angles.
            return Math.Min(360 - angle, angle); ;
        }

        // Returns minimum difference between any pair
        public int FindMinDiff(int[] arr)
        {
            Array.Sort(arr);
            int diff = int.MaxValue;

            // Find the min diff by comparing adjacent pairs in sorted array
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int temp = arr[i + 1] - arr[i];
                if (temp < diff) diff = temp;
            }
            return diff;
        }

        // Function to return k'th smallest element in a given array
        public int KthSmallest(int[] arr, int k)
        {
            Array.Sort(arr); // O (n logn)
            return arr[k - 1];
        }

        // Function to return k'th largest element in a given array
        public int KthLargest(int[] arr, int k)
        {
            var comp = new Comparison<int>((i1, i2) => i2.CompareTo(i1));
            Array.Sort(arr, comp); // O (n logn)
            return arr[k - 1];
        }

        // Remove characters from the first string which are present in the second string
        // Time Complexity: O(m+n) 
        // http://www.geeksforgeeks.org/remove-characters-from-the-first-string-which-are-present-in-the-second-string/
        // Like counting search, but for ASCI
        public string RemoveDirtyCharacters(string firstString, string stringToMask)
        {
            var array = InitCharArray(stringToMask);
            var firstStringLength = firstString.Length;

            var stringBuilder = new StringBuilder();
            for (int i = 0; i < firstStringLength; i++)
            {
                var charac = firstString[i];
                if (array[charac] == 0)
                    stringBuilder.Append(firstString[i]);
            }
            var stringToReturn = stringBuilder.ToString();

            if (stringToReturn.Trim().Length > 0)
                return stringToReturn;

            return "Nothing to return";
        }

        private int[] InitCharArray(string maskString)
        {
            const int maxSize = 256;
            int charArrayLength = maskString.Length;
            var charArray = new int[maxSize];
            for (int i = 0; i < charArrayLength; i++)
            {
                charArray[maskString[i]] = charArray[maskString[i]] + 1;
            }
            return charArray;
        }
    }
}
