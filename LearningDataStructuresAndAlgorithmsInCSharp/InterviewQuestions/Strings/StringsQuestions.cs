using System.Collections.Generic;
using System.Text;

namespace Learning.InterviewQuestions.Strings
{
    public class StringsQuestions
    {
        // Function to print permutations of string
        // This function takes three parameters:
        // 1. String
        // 2. Starting index of the string
        // 3. Ending index of the string.
        // http://code.geeksforgeeks.org/H6Bs1h
        // http://www.geeksforgeeks.org/write-a-c-program-to-print-all-permutations-of-a-given-string/
        // http://www.geeksforgeeks.org/print-all-permutations-of-a-string-with-duplicates-allowed-in-input-string/
        // Algorithm Paradigm: Backtracking
        // Time Complexity: O(n* n!) Note that there are n! permutations and it requires O(n) time to print a a permutation.
        public void Permute(char[] c, int start, int len, IList<char[]> list)
        {
            int i;
            if (start == len)
            {
                list.Add(c);
            }
            else
            {
                for (i = start; i <= len; i++)
                {
                    Swap(c, start, i);
                    Permute(c, start + 1, len, list);
                    Swap(c, start, i); //backtrack
                }
            }
        }
        public void Swap(char[] str, int i, int j)
        {
            char tmp = str[i];
            str[i] = str[j];
            str[j] = tmp;
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

        // Given an input string, write a function that returns the Run Length Encoded string for the input string.
        // For example, if the input string is “wwwwaaadexxxxxx”, then the function should return “w4a3d1e1x6″
        // Time Complexity: O(n)
        // http://www.geeksforgeeks.org/run-length-encoding/
        public string RunLengthEncoding(string s)
        {
            string result = string.Empty;
            int i = 0;

            while (i < s.Length)
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
    }
}
