using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    class Arrays
    {
        //1.1 Implement an algorithm to determine if a string has all unique characters. What if
        //you can not use additional data structures?

        public static bool AreAllUnique(string s)
        {
            bool[] chars = new bool[256];
            for (int i = 0; i < s.Length; i++)
            {
                int pos = s[i];
                if (chars[pos]) return false;

                chars[pos] = true;
            }
            return true;
        }

        // When 'a' to 'z' and no uppercases
        public static bool AreAllUnique2(string s)
        {
            int checker = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                int val = s[i] - 'a';
                if ((checker & (1 << val)) > 0) return false;
                checker |= (1 << val);
            }
            return true;
        }

        //TODO: buble algoritm O(n log n)
        //TODO: sorting algoritm O(n log n)

        public string Reverse(string s)
        {
            char[] chars = s.ToCharArray();
            int i = 0;
            int j = chars.Length - 1;
            char temp;

            while(i < j)
            {
                temp = chars[i];
                chars[i] = chars[j];
                chars[j] = temp;
                i++;
                j--;
            }
            return new string(chars);
        }

        //TODO:null-terminated strings (C Style strings) 
        //Write code to reverse a C-Style String. (C-String means that “abcd” is represented as
        //!ve characters, including the null character.)
        //void reverse(char* str)
        //{
        //    char* end = str;
        //    char tmp;
        //    if (str)
        //    {
        //        while (*end)
        //        {
        //            ++end;
        //            }
        //        ‐‐end;
        //        while (str < end)
        //        {
        //            tmp = *str;
        //            * str++ = *end;
        //            * end‐‐ = tmp;
        //            }
        //        }
        //    }


        //TODO: Review , Review
        public void RemoveDublicates(char[] chars)
        {
            if (chars == null) return;
            int len = chars.Length;
            if (len < 2) return;

            int tail = 0;
            for(int i = 1; i < len; ++i)
            {
                int j;
                for (j = 0; j < tail; ++j)
                {
                    if (chars[i] == chars[j]) break;
                }
                if(j == tail)
                {
                    chars[tail] = chars[i];
                    ++tail;
                }
            }
            chars[tail] = Char.MinValue;
        }

        public void RemoveDublicates2(char[] chars)
        {
            if (chars == null) return;
            int len = chars.Length;
            if (len < 2) return;
            bool[] hit = new bool[256];
            for (int i = 0; i < 256; ++i)
            {
                hit[i] = false;
            }

            hit[chars[0]] = true;
            int tail = 1;

            for (int i = 1; i < len; ++i)
            {
                if (!hit[chars[i]])
                {
                    chars[tail] = chars[i];
                    ++tail;
                    hit[chars[i]] = true;
                }
            }
            chars[tail] = Char.MinValue;
        }

    }
}
