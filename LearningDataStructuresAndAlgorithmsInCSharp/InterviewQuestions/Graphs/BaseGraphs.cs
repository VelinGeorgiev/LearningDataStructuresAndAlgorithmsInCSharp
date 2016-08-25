using System.Collections.Generic;

namespace Learning.InterviewQuestions.Graphs
{
    public class BaseGraphs
    {
        private readonly int _noVertices;   // No. of vertices
        //No of rows and columns
        private const int Row = 5;
        private const int Col = 5;

        // The main function that returns count of islands in a given bool 2D matrix
        public int CountIslands(int[,] mat)
        {
            // Make a bool array to mark visited cells.
            // Initially all cells are unvisited
            bool[,] visited = new bool[Row, Col];

            // Initialize count as 0 and travese through the all cells of given matrix
            int count = 0;
            for (int i = 0; i < Row; ++i)
                for (int j = 0; j < Col; ++j)
                    if (mat[i, j] == 1 && !visited[i, j]) // If a cell with
                    {
                        // value 1 is not
                        // visited yet, then new island found, Visit all
                        // cells in this island and increment island count
                        Dfs(mat, i, j, visited);
                        ++count;
                    }

            return count;
        }

        // A function to check if a given cell(row, col) can be included in DFS
        private bool IsSafe(int[,] mat, int row, int col, bool[,] visited)
        {
            // row number is in range, column number is in range
            // and value is 1 and not yet visited
            return (row >= 0) && (row < Row) &&
                   (col >= 0) && (col < Col) &&
                   (mat[row,col] == 1 && !visited[row,col]);
        }

        public void Dfs(int[,] mat, int row, int col, bool[,] visited)
        {
            // These arrays are used to get row and column numbers of 8 neighbors of a given cell
            int[] rowNbr = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] colNbr = { -1, 0, 1, -1, 1, -1, 0, 1 };

            // Mark this cell as visited
            visited[row,col] = true;

            // Recur for all connected neighbours
            for (int k = 0; k < 8; ++k)
                if (IsSafe(mat, row + rowNbr[k], col + colNbr[k], visited))
                    Dfs(mat, row + rowNbr[k], col + colNbr[k], visited);
        }
    }
}
