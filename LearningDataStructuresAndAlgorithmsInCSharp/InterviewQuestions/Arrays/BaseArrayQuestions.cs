using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
