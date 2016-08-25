using System;
using System.Collections.Generic;
using System.Globalization;

namespace Learning.InterviewQuestions.Arrays
{
    public class BaseArrayQuestions
    {
        // Returns floor of square root of x
        // Time Complexity: O(Log x)
        // http://www.geeksforgeeks.org/square-root-of-an-integer/
        public int FloorSqrt(int x)
        {
            if (x == 0 || x == 1) return x;

            // Do Binary Search for floor(sqrt(x))
            // 'start' = 0 and 'end' = x/2. Floor of square root of x cannot be more than x/2 when x > 1.
            int start = 0, end = x / 2, ans = 0;
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
            int hourAngle = (int)(0.5 * (h * 60 + m));
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

        // Maximum sum such that no two elements are adjacent
        // Time Complexity: O(n)
        // http://www.geeksforgeeks.org/maximum-sum-such-that-no-two-elements-are-adjacent/
        // Function to return max sum such that no two elements are adjacent
        // TODO: review again.
        public int FindMaxSum(int[] arr)
        {
            int incl = arr[0];
            int excl = 0;
            int exclNew;
            for (int i = 1; i < arr.Length; i++)
            {
                exclNew = (incl > excl) ? incl : excl; //current max excluding i
                incl = excl + arr[i]; // current max including i
                excl = exclNew;
            }

            // return max of incl and excl
            return ((incl > excl) ? incl : excl);
        }

        // http://www.geeksforgeeks.org/count-positive-integers-0-digit/
        // Utility function to calculate the count of natural numbers
        // upto a given number of digits that contain atleast one zero
        // Time Complexity : O(1), Auxiliary Space : O(1)
        // Count positive integers with 0 as a digit and maximum ‘d’ digits
        public double FindCountUpto(int d)
        {
            // Sum of two GP series
            double gp1Sum = 9 * ((Math.Pow(10, d) - 1) / 9);
            double gp2Sum = 9 * ((Math.Pow(9, d) - 1) / 8);

            return gp1Sum - gp2Sum;
        }

        // Reverse subarray a[0..k-1]
        // Time complexity: O(k)
        // http://quiz.geeksforgeeks.org/reverse-an-array-upto-a-given-position/
        public void ReverseArray(int[] arr, int n, int start, int k)
        {
            if (k > n) return;

            // One by one reverse first and last elements of a[0..k-1]
            var halfK = k / 2;
            for (int i = start; i <= halfK; i++)
            {
                var toSwapWith = k - i - 1; //excluding
                var temp = arr[i];
                arr[i] = arr[toSwapWith];
                arr[toSwapWith] = temp;
            }
        }

        // Count number of bits to be flipped to convert A to B
        // http://www.geeksforgeeks.org/count-number-of-bits-to-be-flipped-to-convert-a-to-b/
        public int FlipBits(int a, int b)
        {
            var n = a ^ b;
            int count = 0;
            while (n != 0)
            {
                count += n & 1;
                n >>= 1;
            }
            return count;
        }

        public int GetMissingNo(int[] a, int n)
        {
            int i;
            int x1 = a[0]; /* For xor of all the elements in array */
            int x2 = 1; /* For xor of all the elements from 1 to n+1 */
            for (i = 1; i < n; i++) x1 = x1 ^ a[i];
            for (i = 2; i <= n + 1; i++) x2 = x2 ^ i;
            return x1 ^ x2;
        }

        // Function to left rotate arr[] of siz n by d
        // http://www.geeksforgeeks.org/array-rotation/
        // Time complexity: O(n), Auxiliary Space: O(1)
        public void LeftRotate(int[] arr, int d, int n)
        {
            int i, j, k, temp;
            for (i = 0; i < GreatestCommonDivisor(d, n); i++)
            {
                /* move i-th values of blocks */
                temp = arr[i];
                j = i;
                while (true)
                {
                    k = j + d;
                    if (k >= n) k = k - n;
                    if (k == i) break;
                    arr[j] = arr[k];
                    j = k;
                }
                arr[j] = temp;
            }
        }
        private int GreatestCommonDivisor(int a, int b)
        {
            if (b == 0) return a;
            return GreatestCommonDivisor(b, a % b);
        }

        // Function to left rotate arr[] of siz n by d
        // http://www.geeksforgeeks.org/array-rotation/
        // Time complexity O(n), Auxiliary Space: O(d)
        public void LeftRotate2(int[] arr, int d)
        {
            int[] temp = new int[d];
            for (int i = 0; i < d; i++) temp[i] = arr[i];
            for (int i = 0; i < arr.Length - d; i++) arr[i] = arr[i + d];
            for (int i = 0; i < temp.Length; i++) arr[arr.Length - (d - i)] = temp[i];
        }


        // Function to left rotate arr[] of size n by d with Reverse array
        public void LeftRotate3(int[] arr, int d)
        {
            int n = arr.Length;
            RvereseArray(arr, 0, d - 1);
            RvereseArray(arr, d, n - 1);
            RvereseArray(arr, 0, n - 1);
        }
        // Function to reverse arr[] from index start to end
        // Reverse array
        public void RvereseArray(int[] arr, int start, int end)
        {
            int temp;
            while (start < end)
            {
                temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }

        // Maximum sum of i*arr[i] among all rotations of a given array
        // http://www.geeksforgeeks.org/maximum-sum-iarri-among-rotations-given-array/
        public int RotationsMaximumSum(int[] arr, int n)
        {
            // Compute sum of all array elements
            int cumSum = 0;
            for (int i = 0; i < n; i++)
                cumSum += arr[i];

            // Compute sum of i*arr[i] for initial
            // configuration.
            int currVal = 0;
            for (int i = 0; i < n; i++)
                currVal += i * arr[i];

            // Initialize result
            int res = currVal;

            // Compute values for other iterations
            for (int i = 1; i < n; i++)
            {
                // Compute next value using previous value in
                // O(1) time
                int nextVal = currVal - (cumSum - arr[i - 1]) + arr[i - 1] * (n - 1);

                // Update current value
                currVal = nextVal;

                // Update result if required
                res = Math.Max(res, nextVal);
            }

            return res;
        }

        // http://www.geeksforgeeks.org/find-the-largest-subarray-with-0-sum/
        // Returns length of the maximum length subarray with 0 sum
        // Time Complexity of this solution can be considered as O(n) under the 
        // assumption that we have good hashing function that allows insertion 
        // and retrieval operations in O(1) time.
        public int ArrayMaxLenTo0(int[] arr)
        {
            // Creates an empty hashMap hM
            Dictionary<int, int> hash = new Dictionary<int, int>();
            int sum = 0;      // Initialize sum of elements
            int maxLen = 0;  // Initialize result

            // Traverse through the given array
            for (int i = 0; i < arr.Length; i++)
            {
                // Add current element to sum
                sum += arr[i];
                if (arr[i] == 0 && maxLen == 0)
                    maxLen = 1;
                if (sum == 0)
                    maxLen = i + 1;

                // If this sum is seen before, then update max_len
                // if required
                if (hash.ContainsKey(sum)) // O(1) 
                    maxLen = Math.Max(maxLen, i - hash[sum]);
                else  // Else put this sum in hash table
                    hash.Add(sum, i);

            }

            return maxLen;
        }

        // This function returns the sum of elements on maximum path
        // from beginning to end
        // http://www.geeksforgeeks.org/maximum-sum-path-across-two-arrays/
        // Time complexity: In every iteration of while loops, we process an element from either of the two arrays.
        // There are total m + n elements. Therefore, time complexity is O(m+n).
        public int MaxPathSum(int[] ar1, int[] ar2, int m, int n)
        {
            // initialize indexes for ar1[] and ar2[]
            int i = 0, j = 0;

            // Initialize result and current sum through ar1[] and ar2[].
            int result = 0, sum1 = 0, sum2 = 0;

            // Below 3 loops are similar to merge in merge sort
            while (i < m && j < n)
            {
                // Add elements of ar1[] to sum1
                if (ar1[i] < ar2[j])
                    sum1 += ar1[i++];

                // Add elements of ar2[] to sum2
                else if (ar1[i] > ar2[j])
                    sum2 += ar2[j++];

                // we reached a common point
                else
                {
                    // Take the maximum of two sums and add to result
                    result += Math.Max(sum1, sum2);

                    // Update sum1 and sum2 for elements after this
                    // intersection point
                    sum1 = 0;
                    sum2 = 0;

                    // Keep updating result while there are more common
                    // elements
                    while (i < m && j < n && ar1[i] == ar2[j])
                    {
                        result = result + ar1[i++];
                        j++;
                    }
                }
            }

            // Add remaining elements of ar1[]
            while (i < m)
                sum1 += ar1[i++];

            // Add remaining elements of ar2[]
            while (j < n)
                sum2 += ar2[j++];

            // Add maximum of two sums of remaining elements
            result += Math.Max(sum1, sum2);

            return result;
        }

        // http://www.practice.geeksforgeeks.org/problem-page.php?pid=700194
        // On
        public int TransitionPoint(int[] arr, int n)
        {
            int low = 0, high = n - 1;
            int mid = 0;
            while (low <= high)
            {
                mid = low + (high - low) / 2;
                if (arr[mid] == 0)
                {
                    low = mid + 1;
                }
                if (arr[mid] == 1)
                {
                    high = mid - 1;
                }
            }

            if (arr[mid] == 1)
                return mid;
            return mid + 1;
        }

        // Prints element and NGE pair for all elements of arr[] of size n
        // http://www.geeksforgeeks.org/next-greater-element/
        // Time Complexity: O(n). 
        public void NextGreaterElement(int[] arr, int n, Dictionary<int, int> result)
        {
            int i = 0;
            Stack<int> s = new Stack<int>();
            //s.top = -1;
            int element, next;

            /* push the first element to stack */
            s.Push(arr[0]);

            // iterate for rest of the elements
            for (i = 1; i < n; i++)
            {
                next = arr[i];

                if (s.Count > 0)
                {
                    // if stack is not empty, then pop an element from stack
                    element = s.Pop();

                    /* If the popped element is smaller than next, then
                        a) print the pair
                        b) keep popping while elements are smaller and
                        stack is not empty */
                    while (element < next)
                    {
                        Console.Write(element + " --> " + next);
                        result.Add(element, next);
                        if (s.Count == 0)
                            break;
                        element = s.Pop();
                    }

                    /* If element is greater than next, then push
                       the element back */
                    if (element > next)
                        s.Push(element);
                }

                /* push next to stack so that we can find
                   next greater for it */
                s.Push(next);
            }

            /* After iterating over the loop, the remaining
               elements in stack do not have the next greater
               element, so print -1 for them */
            while (s.Count > 0)
            {
                element = s.Pop();
                next = -1;
                Console.Write(element + " --> " + next);
                result.Add(element, next);
            }
        }

        // http://www.geeksforgeeks.org/find-minimum-element-in-a-sorted-and-rotated-array/
        // Find the minimum element in a sorted and rotated array
        // Following solution assumes that all elements are distinct.
        // O(Logn)
        // Fails if dublicates see the url.
        public int FindMinElInSortedRotArray(int[] arr, int low, int high)
        {
            // This condition is needed to handle the case when array
            // is not rotated at all
            if (high < low) return arr[0];

            // If there is only one element left
            if (high == low) return arr[low];

            // Find mid
            int mid = low + (high - low) / 2; /*(low + high)/2;*/

            // Check if element (mid+1) is minimum element. Consider
            // the cases like {3, 4, 5, 1, 2}
            if (mid < high && arr[mid + 1] < arr[mid])
                return arr[mid + 1];

            // Check if mid itself is minimum element
            if (mid > low && arr[mid] < arr[mid - 1])
                return arr[mid];

            // Decide whether we need to go to left half or right half
            if (arr[high] > arr[mid])
                return FindMinElInSortedRotArray(arr, low, mid - 1);
            return FindMinElInSortedRotArray(arr, mid + 1, high);
        }


        /* Returns true if the there is a subarray of arr[] with sum equal to
       'sum' otherwise returns false.  Also, prints the result */
        // http://www.geeksforgeeks.org/find-subarray-with-given-sum/
        // Time Complexity: O(n) 
        public bool SubArraySum(int[] arr, int n, int sum)
        {
            int currSum = arr[0], start = 0, i;

            // Pick a starting point
            for (i = 1; i <= n; i++)
            {
                // If currSum exceeds the sum, then remove the starting elements
                while (currSum > sum && start < i - 1)
                {
                    currSum = currSum - arr[start];
                    start++;
                }

                // If currSum becomes equal to sum, then return true
                if (currSum == sum)
                {
                    int p = i - 1;
                    Console.Write("Sum found between indexes " + i + " and " + p);
                    return true;
                }

                // Add this element to currSum
                if (i < n)
                    currSum = currSum + arr[i];
            }
            return false;
        }

        // Count Inversions in an array using Merge Sort
        // http://www.geeksforgeeks.org/counting-inversions/
        // Time Complexity: O(n^2)
        public int GetInvCount(int[] arr, int n)
        {
            int invCount = 0;
            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (arr[i] > arr[j])
                        invCount++;

            return invCount;
        }

        // http://www.geeksforgeeks.org/write-a-c-program-that-given-a-set-a-of-n-numbers-and-another-number-x-determines-whether-or-not-there-exist-two-elements-in-s-whose-sum-is-exactly-x/
        public bool HasArrayTwoCandidates(int[] a, int arrSize, int sum)
        {
            int l, r;

            /* Sort the elements */
            Array.Sort(a);

            /* Now look for the two candidates in the sorted 
               array*/
            l = 0;
            r = arrSize - 1;
            while (l < r)
            {
                if (a[l] + a[r] == sum) return true;

                if (a[l] + a[r] < sum)
                    l++;
                else
                    r--;
            }
            return false;
        }


        // Convert array into Zig-Zag fashion
        // http://www.geeksforgeeks.org/convert-array-into-zig-zag-fashion/
        // Time complexity: O(n), Auxiliary Space: O(1)
        public void ZigZagArray(int[] arr, int n)
        {
            // Flag true indicates relation "<" is expected,
            // else ">" is expected.  The first expected relation
            // is "<"
            bool flag = true;

            for (int i = 0; i <= n - 2; i++)
            {
                if (flag)  /* "<" relation expected */
                {
                    /* If we have a situation like A > B > C,
                       we get A > B < C by swapping B and C */
                    if (arr[i] > arr[i + 1])
                        Swap(arr, i, i + 1);
                }
                else /* ">" relation expected */
                {
                    /* If we have a situation like A < B < C,
                       we get A < C > B by swapping B and C */
                    if (arr[i] < arr[i + 1])
                        Swap(arr,i,i + 1);
                }
                flag = !flag; /* flip flag */
            }
        }

        private void Swap(int[] arr, int i, int j)
        {
            int t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }

        //http://www.geeksforgeeks.org/leaders-in-an-array/
        // function to print leaders in an array
        // Time Complexity: O(n)
        public void PrintLeaders(int[] arr, int size, IList<int> result)
        {
            int maxFromRight = arr[size - 1];

            /* Rightmost element is always leader */
            Console.Write(maxFromRight);
            result.Add(maxFromRight);

            for (int i = size - 2; i >= 0; i--)
            {
                if (maxFromRight < arr[i])
                {
                    maxFromRight = arr[i];
                    Console.Write(maxFromRight);
                    result.Add(maxFromRight);
                }
            }
        }

        // Replace every element with the greatest element on right side
        // http://www.geeksforgeeks.org/replace-every-element-with-the-greatest-on-right-side/
        // Function to replace every element with the next greatest element
        public void NextGreatest(int[] arr)
        {
            int size = arr.Length;

            // Initialize the next greatest element
            int maxFromRight = arr[size - 1];

            // The next greatest element for the rightmost
            // element is always -1
            arr[size - 1] = -1;

            // Replace all other elements with the next greatest
            for (int i = size - 2; i >= 0; i--)
            {
                // Store the current element (needed later for
                // updating the next greatest element)
                int temp = arr[i];

                // Replace current element with the next greatest
                arr[i] = maxFromRight;

                // Update the greatest element, if needed
                if (maxFromRight < temp)
                    maxFromRight = temp;
            }
        }

        // Find the two numbers with odd occurrences in an unsorted array
        // http://www.geeksforgeeks.org/find-the-two-numbers-with-odd-occurences-in-an-unsorted-array/
        // Input: {12, 23, 34, 12, 12, 23, 12, 45}
        // Output: 34 and 45
        // Time On, Space On
        public void FindTwoOddNumbers(int[] arr, IList<int> result)
        {
            int n = arr.Length;
            Dictionary<int, int> hash = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                var key = arr[i];
                int value = 1;

                if (hash.ContainsKey(key))
                {
                    value = hash[key] + 1;
                    hash.Remove(key);
                }
                hash.Add(key, value);
            }

            foreach (var item in hash)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write(item.Key);
                    result.Add(item.Key);
                }
            }
        }

        // Find the two numbers with odd occurrences in an unsorted array
        // http://www.geeksforgeeks.org/find-the-two-numbers-with-odd-occurences-in-an-unsorted-array/
        // Input: {12, 23, 34, 12, 12, 23, 12, 45}
        // Output: 34 and 45
        // Time(nlogn), Space O(1)
        // TODO: fix
        public void FindTwoOddNumbersWithSort(int[] arr, IList<int> result)
        {
            int n = arr.Length;
            Array.Sort(arr);

            for (int i = 0; i < n-1; i++)
            {
                int count = 0;
                int j = i + 1;
                if (i != n - 1)
                {
                    while (arr[i] == arr[j])
                    {
                        count++;
                        i++;
                    }
                }
                else
                {
                   while (arr[i] == arr[j])
                    {
                        count++;
                        i++;
                    } 
                }
                
                if (count % 2 != 0)
                {
                    Console.Write(arr[i]);
                    result.Add(arr[i]);
                }
            }
        }

        // Next Greater Element
        // http://www.geeksforgeeks.org/next-greater-element/
        // On2
        public void PrintNge(int[] arr, IDictionary<int, int> result)
        {
            int next, i, j;
            int n = arr.Length;
            for (i = 0; i < n; i++)
            {
                next = -1;
                for (j = i + 1; j < n; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        next = arr[j];
                        break;
                    }
                }
                Console.Write(arr[i] + " -> " + next);
                result.Add(arr[i], next);
            }
        }

        // Sort the input array, the array is assumed to
        // have values in {0, 1, 2}
        // http://www.geeksforgeeks.org/sort-an-array-of-0s-1s-and-2s/
        // Dutch flag problem
        public void Sort012(int[] a, int arrSize)
        {
            int lo = 0;
            int hi = arrSize - 1;
            int mid = 0, temp = 0;
            while (mid <= hi)
            {
                switch (a[mid])
                {
                    case 0:
                        {
                            temp = a[lo];
                            a[lo] = a[mid];
                            a[mid] = temp;
                            lo++;
                            mid++;
                            break;
                        }
                    case 1:
                        mid++;
                        break;
                    case 2:
                        {
                            temp = a[mid];
                            a[mid] = a[hi];
                            a[hi] = temp;
                            hi--;
                            break;
                        }
                }
            }
        }

        // On, On
        // http://www.geeksforgeeks.org/majority-element/s
        public int MajorityElementHash(int[] arr)
        {
            int len = arr.Length;
            IDictionary<int, int> hash = new Dictionary<int, int>();

            for (int i = 0; i < len; i++)
            {
                var key = arr[i];
                int value = 1;

                if (hash.ContainsKey(key))
                {
                    value = hash[key] + 1;
                    hash.Remove(key);
                }
                hash.Add(key, value);
            }

            var result = 0;
            foreach (var item in hash)
            {
                if (item.Value >= arr.Length/2)
                {
                    result = item.Key;
                    break;
                }
            }
            return result;
        }

        // Function which pushes all zeros to end of an array.
        public void PushZerosToEnd(int[] arr, int n)
        {
            int count = 0;  // Count of non-zero elements

            // Traverse the array. If element encountered is
            // non-zero, then replace the element at index 'count'
            // with this element
            for (int i = 0; i < n; i++)
                if (arr[i] != 0)
                    arr[count++] = arr[i]; // here count is
                                           // incremented

            // Now all non-zero elements have been shifted to
            // front and 'count' is set as index of first 0.
            // Make all elements 0 from count to end.
            while (count < n)
                arr[count++] = 0;
        }

        // http://www.geeksforgeeks.org/find-pythagorean-triplet-in-an-unsorted-array/
        // on2 of sort
        public bool IsTriplet(int[] arr, int n)
        {
            // Square array elements
            for (int i = 0; i < n; i++)
                arr[i] = arr[i] * arr[i];

            // Sort array elements
            Array.Sort(arr);

            // Now fix one element one by one and find the other two elements
            for (int i = n - 1; i >= 2; i--) // NOTE:
            {
                // To find the other two elements, start two index
                // variables from two corners of the array and move
                // them toward each other
                int l = 0; // index of the first element in arr[0..i-1]
                int r = i - 1; // index of the last element in arr[0..i-1]
                while (l < r)
                {
                    // A triplet found
                    if (arr[l] + arr[r] == arr[i])
                        return true;

                    // Else either move 'l' or 'r'
                    if (arr[l] + arr[r] < arr[i])
                        l++;
                    else
                        r--;
                }
            }

            // If we reach here, then no triplet found
            return false;
        }

    }
}
