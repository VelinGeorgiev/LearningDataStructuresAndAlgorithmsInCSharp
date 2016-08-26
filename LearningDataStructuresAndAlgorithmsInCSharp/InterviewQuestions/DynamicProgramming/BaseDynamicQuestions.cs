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
                    result.Add(mat[k, i]);
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
                        result.Add(mat[i, l]);
                        Console.Write(mat[i, l]);
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
            if (mat[cel, b] == 1)
                cel = b;

            if (mat[cel, a] == 1)
                cel = a;

            // Check if C is actually a celebrity or not
            for (int i = 0; i < n; i++)
            {
                // If any person doesn't know 'a' or 'a'
                // doesn't know any person, return -1
                if ((i != cel) && (mat[cel, i] == 1 || mat[i, cel] != 1))
                    return -1;
            }

            return cel;
        }

        // http://www.geeksforgeeks.org/find-the-row-with-maximum-number-1s/
        // The main function that returns index of row with maximum number of 1s. 
        //public int RowWithMax1S(int[,] mat)
        //{
        // Initialize first row as row with max 1s
        //int maxRowIndex = 0;
        //int r = mat.GetLength(0);
        //int c = mat.GetLength(1);

        //// The function first() returns index of first 1 in row 0.
        //// Use this index to initialize the index of leftmost 1 seen so far
        //int j = first(mat[0], 0, c - 1);
        //if (j == -1) // if 1 is not present in first row
        //    j = c - 1;

        //for (int i = 1; i < r; i++)
        //{
        //    // Move left until a 0 is found
        //    while (j >= 0 && mat[i,j] == 1)
        //    {
        //        j = j - 1;  // Update the index of leftmost 1 seen so far
        //        maxRowIndex = i;  // Update max_row_index
        //    }
        //}
        //return maxRowIndex;
        //}

        //http://www.geeksforgeeks.org/find-a-tour-that-visits-all-stations/
        // The function returns starting point if there is a possible solution,
        // otherwise returns -1
        public int PrintTour(PetrolPump[] arr, int n)
        {
            // Consider first petrol pump as a starting point
            int start = 0;
            int end = 1;

            int currPetrol = arr[start].petrol - arr[start].distance;

            /* Run a loop while all petrol pumps are not visited.
              And we have reached first petrol pump again with 0 or more petrol */
            while (end != start || currPetrol < 0)
            {
                // If curremt amount of petrol in truck becomes less than 0, then
                // remove the starting petrol pump from tour
                while (currPetrol < 0 && start != end)
                {
                    // Remove starting petrol pump. Change start
                    currPetrol -= arr[start].petrol - arr[start].distance;
                    start = (start + 1) % n;

                    // If 0 is being considered as start again, then there is no
                    // possible solution
                    if (start == 0)
                        return -1;
                }
                // Add a petrol pump to current tour
                currPetrol += arr[end].petrol - arr[end].distance;

                end = (end + 1) % n;
            }

            // Return starting point
            return start;
        }

        // Returns optimal value possible that a player can collect from
        // an array of coins of size n. Note than n must be even
        // http://www.geeksforgeeks.org/dynamic-programming-set-31-optimal-strategy-for-a-game/
        // Dynamic Programming | Set 31 (Optimal Strategy for a Game)
        public int OptimalStrategyOfGame(int[] arr, int n)
        {
            // Create a table to store solutions of subproblems
            int[,] table = new int[n, n];
            int gap, i, j, x, y, z;

            // Fill table using above recursive formula. Note that the table
            // is filled in diagonal fashion (similar to http://goo.gl/PQqoS),
            // from diagonal elements to table[0][n-1] which is the result.
            for (gap = 0; gap < n; ++gap)
            {
                for (i = 0, j = gap; j < n; ++i, ++j)
                {
                    // Here x is value of F(i+2, j), y is F(i+1, j-1) and
                    // z is F(i, j-2) in above recursive formula
                    x = ((i + 2) <= j) ? table[i + 2, j] : 0;
                    y = ((i + 1) <= (j - 1)) ? table[i + 1, j - 1] : 0;
                    z = (i <= (j - 2)) ? table[i, j - 2] : 0;

                    table[i, j] = Math.Max(arr[i] + Math.Min(x, y), arr[j] + Math.Min(y, z));
                }
            }
            return table[0, n - 1];
        }


    }

    // A petrol pump has petrol and distance to next petrol pump
    public struct PetrolPump
    {
        public int petrol;
        public int distance;
    };
}
