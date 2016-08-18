using System;

namespace Learning.Recursion
{
    public class Permutations
    {
        private void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        private void Swap(ref int a, ref int b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        public void GetPermutation(char[] list)
        {
            int x = list.Length - 1;
            GetPermutation(list, 0, x);
        }

        public void GetPermutation(int[] list)
        {
            int x = list.Length - 1;
            GetPermutation(list, 0, x);
        }

        private void GetPermutation(char[] list, int k, int m)
        {
            if (k == m)
            {
                Console.Write(list);
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPermutation(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
        }

        private void GetPermutation(int[] list, int k, int m)
        {
            if (k == m)
            {
                Console.Write(list);
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPermutation(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
        }
    }
}
