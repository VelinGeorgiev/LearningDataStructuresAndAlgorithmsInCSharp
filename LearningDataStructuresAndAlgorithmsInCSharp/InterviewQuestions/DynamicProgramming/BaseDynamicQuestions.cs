using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Learning.InterviewQuestions.DynamicProgramming
{
    public class BaseDynamicQuestions
    {
        // Returns count of possible paths to reach cell at row number m and column
        // number n from the Peekmost leftmost cell (cell at 1, 1)
        // Time complexity of the above dynamic programming solution is O(mn).
        // http://www.geeksforgeeks.org/count-possible-paths-Peek-left-bottom-right-nxm-matrix/
        public int NumberOfPaths(int m, int n)
        {
            // Create a 2D table to store results of subproblems
            int[,] count = new int[m, n];

            // Count of paths to reach any cell in first column is 1
            for (int i = 0; i < m; i++) count[i, 0] = 1;

            // Count of paths to reach any cell in first column is 1
            for (int j = 0; j < n; j++) count[0, j] = 1;

            // Calculate count of paths for other cells in bottom-up manner using
            // the recursive solution
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)

                    // By uncommenting the last part the code calculatest he total
                    // possible paths if the diagonal Movements are allowed
                    count[i, j] = count[i - 1, j] + count[i, j - 1]; //+ count[i-1][j-1];

            }
            return count[m - 1, n - 1];
        }


        // Dice throw
        // http://www.geeksforgeeks.org/dice-throw-problem/


        // Print unique rows in a given boolean matrix
        // http://www.geeksforgeeks.org/print-unique-rows/
        // Java implementation using set. Time complexity O(row*col). Space complexity O(row).
        // Time complexity: O(ROW x COL ), Auxiliary Space: O(ROW )
        // TODO: fix
        public void PrintUniqueMatrixRows(int[,] mat, HashSet<string> set)
        {
            int i = mat.GetLength(0);
            int j = mat.Length;
            while (j >= 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int k = 0; k < i; k++)
                {
                    sb.Append((mat[j, k]).ToString());
                }
                set.Add(sb.ToString());
                j--;
            }
            foreach (var hashVal in set)
            {
                Console.Write(hashVal);
            }
        }

        // Print a given matrix in spiral form
        // http://www.geeksforgeeks.org/print-a-given-matrix-in-spiral-form/
        // Time Complexity: Time complexity of the above solution is O(mn).
        // TODO: check also http://www.geeksforgeeks.org/print-kth-element-spiral-form-matrix/ if some time.
        public void PrintMatrixInSpiralForm(int[,] mat, IList<int> result)
        {
            int i, k = 0, l = 0;
            int m = mat.GetLength(0);
            int n = mat.GetLength(1);
            /*  k - starting row index
                m - ending row index
                l - starting column index
                n - ending column index
                i - iterator
            */

            while (k < m && l < n)
            {
                /* Print the first row from the remaining rows */
                for (i = l; i < n; ++i)
                {
                    result.Add(mat[k,i]);
                    Console.Write(mat[k, i]);
                }
                k++;

                /* Print the last column from the remaining columns */
                for (i = k; i < m; ++i)
                {
                    result.Add(mat[i, n - 1]);
                    Console.Write(mat[i, n - 1]);
                }
                n--;

                /* Print the last row from the remaining rows */
                if (k < m)
                {
                    for (i = n - 1; i >= l; --i)
                    {
                        result.Add(mat[m - 1, i]);
                        Console.Write(mat[m - 1, i]);
                    }
                    m--;
                }

                /* Print the first column from the remaining columns */
                if (l < n)
                {
                    for (i = m - 1; i >= k; --i)
                    {
                        result.Add(mat[i,l]);
                        Console.Write(mat[i,l]);
                    }
                    l++;
                }
            }
        }

        // Returns -1 if celebrity is not present.
        // If present, returns id  (value from 0 to n-1).
        // http://www.geeksforgeeks.org/the-celebrity-problem/
        public int CelebrityProblem(int n, int[,] mat)
        {
                // Handle trivial case of size = 2
                Stack<int> s = new Stack<int>();
                int cel; // Celebrity

                // Push everybody to stack
                for (int i = 0; i < n; i++)
                    s.Push(i);

                // Extract Peek 2
                int a = s.Peek();
                s.Pop();
                int b = s.Peek();
                s.Pop();

                // Find a potential celevrity
                while (s.Count > 1)
                {
                    if (mat[a, b] == 1)
                    {
                        a = s.Peek();
                        s.Pop();
                    }
                    else
                    {
                        b = s.Peek();
                        s.Pop();
                    }
                }

                // Potential candidate?
                cel = s.Peek();
                s.Pop();

                // Last candidate was not examined, it leads
                // one excess comparison (optimize)
                if (mat[cel, b]==1)
                    cel = b;

                if (mat[cel, a]==1)
                    cel = a;

                // Check if C is actually a celebrity or not
                for (int i = 0; i < n; i++)
                {
                    // If any person doesn't know 'a' or 'a'
                    // doesn't know any person, return -1
                    if ((i != cel) && (mat[cel, i] ==1 || mat[i, cel]!=1))
                        return -1;
                }

                return cel;
            }
        }
}
