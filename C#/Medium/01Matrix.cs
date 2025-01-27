public class Solution
{
    public int[][] UpdateMatrix(int[][] mat)
    {
        int nRows = mat.Length;
        int nCols = mat[0].Length;

        var result = new int[nRows][];
        var queue = new Queue<Cell>();
        var seen = new bool[nRows][];
        for (int i = 0; i < nRows; i++)
        {
            result[i] = new int[nCols];
            seen[i] = new bool[nCols];
        }

        for (int r = 0; r < nRows; r++)
        {
            for (int c = 0; c < nCols; c++)
            {
                if (mat[r][c] == 0)
                {
                    queue.Enqueue(new Cell(r, c, 0));
                    seen[r][c] = true;
                }
            }
        }

        var directions = new int[][] { [1,0], [-1,0], [0,-1], [0,1] };
        while (queue.Count > 0)
        {
            Cell cell = queue.Dequeue();
            result[cell.Row][cell.Col] = cell.Level;

            foreach (int[] direction in directions)
            {
                int nextRow = cell.Row + direction[0];
                int nextCol = cell.Col + direction[1];

                if (IsValidCell(nextRow, nextCol, nRows, nCols) && seen[nextRow][nextCol] == false)
                {
                    queue.Enqueue(new Cell(nextRow, nextCol, cell.Level + 1));
                    seen[nextRow][nextCol] = true;
                }
            }
        }

        return result;
    }  

    private bool IsValidCell(int row, int col, int nRows, int nCols)
    {
        if (row >= 0 && col >= 0 && row < nRows && col < nCols)
        {
            return true;
        }

        return false;
    }
}

public struct Cell
{
    public int Row;
    public int Col;
    public int Level;
    
    public Cell(int row, int col, int level)
    {
        Row = row;
        Col = col;
        Level = level;
    }
}

/*

    Brute force solution:
    * Iterate over every cell in the matrix
    * Run BFS from each cell to find the distance to the nearest zero
    Time: O((m*n)^2)
    Space: O(m*n)

    --------------------------------------------------------------------------------

    Optimization
    * Iterate over every cell in the matrix
    * Run BFS starting from every 0 cell only, queuing up neighboring nodes
    Time: O(m*n)
    Space: O(m*n)

    Where m is the number of row and n is the number of cells

    --------------------------------------------------------------------------------

    Key insights:
    1. Starting from 1 will only find the shortest distance for that one, but starting from zero can find the shortest distance for many 1's
    2. Starting from all 0's at the same time, this way we only need to vist each cell once

*/



public class Solution2
{
    public int[][] UpdateMatrix(int[][] mat)
    {
        int nRows = mat.Length;
        int nCols = mat[0].Length;
        var dp = new int[nRows][];
        for (int i = 0; i < nRows; i++) dp[i] = new int[nCols];

        for (int r = 0; r < nRows; r++)
        {
            for (int c = 0; c < nCols; c++)
            {
                dp[r][c] = mat[r][c];
            }
        }

        for (int r = 0; r < nRows; r++)
        {
            for (int c = 0; c < nCols; c++)
            {
                if (dp[r][c] == 0) continue;

                int min = nRows + nCols;
                if (r > 0) min = Math.Min(min, dp[r - 1][c]);
                if (c > 0) min = Math.Min(min, dp[r][c - 1]);
                
                dp[r][c] = min + 1;
            }
        }

        for (int r = nRows - 1; r >= 0; r--)
        {
            for (int c = nCols - 1; c >= 0; c--)
            {
                if (dp[r][c] == 0) continue;

                int min = nRows + nCols;
                if (r < nRows - 1) min = Math.Min(min, dp[r + 1][c]);
                if (c < nCols - 1) min = Math.Min(min, dp[r][c + 1]);
                
                dp[r][c] = Math.Min(dp[r][c], min + 1);
            }
        }
        
        return dp;
    }  
}

/*

    Bottom-up DP

    Time: O(m * n)
    Space: O(m * n)

    ------------------------------------------------------

    Explanation

    At any given cell at some row r and some column c, the minimum distance to the nearest zero is 
    min(dp[r + 1][c], dp[r - 1][c], dp[r][c + 1], dp[r][c - 1]).

    The issue is that those neighboring cells may not have been calculated yet. For this reason, there needs to be two passes:
    1. One to calculate the min distance from moving right & down in the matrix: min(dp[r - 1][c], dp[r][c - 1]) + 1
    2. One to calculate the min distance from moving left & up in the matrix: min(dp[r + 1][c], dp[r][c + 1]) + 1

    The proof...

    Assume a 2x2 matrix:  [a,b]
                          [c,d]

    Starting from cell a, there are two possibilties when calculating the min distance when moving right & down:
    1. a is 0
    1. a is 1

    If a is 0, then the value for the min distance for the entire matrix can be calculated on the first pass.

    If a is 1, then it must be the case that b, c, or d are 0, because the problem description says that there must be at least one zero. This means
    that we know the min distance for d, and using the min-distance for d, we can calculate the min distance for b and c, (and then eventually a) on the second pass.

*/
