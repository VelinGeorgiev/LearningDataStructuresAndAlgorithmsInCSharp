using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            int digit = num%10;
            if (digit == 0) digit = 5;

            // Convert remaining digits and append the last digit
            return Convert0To5Rec(num/10)*10 + digit;
        }

        // It handles 0 and calls convert0To5Rec() for other numbers
        public int Convert0To5(int num)
        {
            if (num == 0) return 5;
            return Convert0To5Rec(num);
        }

        // Find next greater number with same set of digits
        // http://www.geeksforgeeks.org/find-next-greater-number-set-digits/
        // TODO:

        // Given a binary string, count number of substrings that start and end with 1.
        // http://www.geeksforgeeks.org/given-binary-string-count-number-substrings-start-end-1/
        public int CountSubStr(char[] str, int n)
        {
            int m = 0; // Count of 1's in input string

            // Travers input string and count of 1's in it
            for (int i = 0; i < n; i++)
            {
                if (str[i] == '1') m++;
            }

            // Return count of possible pairs among m 1's
            return m*(m - 1)/2;
        }

        // http://www.geeksforgeeks.org/given-a-string-find-its-first-non-repeating-character/
        // program to print the first non-repeating character
        public char FirstNonRepeatedCharacter(string str)
        {
            IDictionary<char, int> dict = new Dictionary<char, int>();
            int i, length = str.Length;
            char c;
            // Scan string and build hash table
            for (i = 0; i < length; i++)
            {
                c = str[i];
                if (dict.ContainsKey(c))
                {
                    dict[c] += 1; // increment count corresponding to c
                }
                else
                {
                    dict.Add(c, 1);
                }
            }
            // Search characterhashtable in in order of string str
            for (i = 0; i < length; i++)
            {
                c = str[i];
                if (dict[c] == 1)
                    return c;
            }
            return ' ';
        }


        // http://www.geeksforgeeks.org/given-a-string-find-its-first-non-repeating-character/
        // program to print the first non-repeating character
        public char KthNonRepeatedCharacter(string str, int k)
        {
            IDictionary<char, int> dict = new Dictionary<char, int>();
            int i, length = str.Length;
            char c;
            // Scan string and build hash table
            for (i = 0; i < length; i++)
            {
                c = str[i];
                if (dict.ContainsKey(c))
                {
                    dict[c] += 1; // increment count corresponding to c
                }
                else
                {
                    dict.Add(c, 1);
                }
            }
            // Search characterhashtable in in order of string str
            int kth = 0;
            for (i = 0; i < length; i++)
            {
                c = str[i];
                if (dict[c] == 1)
                {
                    kth++;
                    if (k == kth) return c;
                }
            }
            return ' ';
        }

        // http://ideone.com/7Hyp9r
        // 
        public int PatternSearch(string pattern, string text)
        {
            var textLength = text.Length;
            var patternLength = pattern.Length;

            for (int i = 0; i <= textLength - patternLength; i++)
            {
                var counter = pattern.Length;
                for (int j = 0; j < patternLength; j++)
                {
                    if (text[i + j] == pattern[j])
                    {
                        --counter;
                    }
                    else
                        break;

                    if (counter == 0)
                    {
                        Console.WriteLine("Pattern - {0}, in Text: {1} found at index: {2}", pattern, text, i);
                        return i;
                    }
                }
            }
            return -1;
        }

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            var s1 = s.ToCharArray();
            var t1 = t.ToCharArray();

            Array.Sort(s1);
            Array.Sort(t1);

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != t1[i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsAnagramHash(string s, string t)
        {
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]] += 1;
                }
                else
                {
                    dict.Add(s[i], 1);
                }
            }
            for (int i = 0; i < t.Length; i++)
            {
                if (dict.ContainsKey(t[i]))
                {
                    dict[t[i]] -= 1;
                }
                else
                {
                    dict.Add(t[i], 1);
                }
            }

            foreach (var item in dict)
            {
                if (item.Value != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsIsomorphic(string s, string t)
        {

            if (s.Length != t.Length)
            {
                return false;
            }

            var sHash = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (sHash.ContainsKey(s[i]))
                {
                    if (sHash[s[i]] != t[i])
                    {
                        return false;
                    }
                }
                else
                {
                    sHash.Add(s[i], t[i]);
                }
            }

            var sHash2 = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (sHash2.ContainsKey(t[i]))
                {
                    if (sHash2[t[i]] != s[i])
                    {
                        return false;
                    }
                }
                else
                {

                    sHash2.Add(t[i], s[i]);
                }
            }

            return true;
        }

        public bool WordPattern(string pattern, string str)
        {

            var patternDict = new Hashtable();
            string[] words = str.Split(' ');

            if (words.Count() != pattern.Length)
            {
                return false;
            }

            for (int j = 0; j < pattern.Length; j++)
            {
                if ((!patternDict.ContainsKey(pattern[j]) && patternDict.ContainsKey(words[j])) ||
                (patternDict.ContainsKey(pattern[j]) && !patternDict.ContainsKey(words[j])))
                {
                    return false;
                }
                if (!patternDict.ContainsKey(pattern[j]) && !patternDict.ContainsKey(words[j]))
                {
                    patternDict[pattern[j]] = j;
                    patternDict[words[j]] = j;
                }
                else
                {
                    if ((int)patternDict[pattern[j]] != (int)patternDict[words[j]])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
