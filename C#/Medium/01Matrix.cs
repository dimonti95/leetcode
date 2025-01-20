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
