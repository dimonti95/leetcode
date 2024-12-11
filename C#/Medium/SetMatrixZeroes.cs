public class Solution {
    public void SetZeroes(int[][] matrix)
    {
        int nRows = matrix.Length;
        int nCols = matrix[0].Length;
        bool rowZero = false;

        // Find all rows/cols that need to be zeroed out
        for (int r = 0; r < nRows; r++)
        {
            for (int c = 0; c < nCols; c++)
            {
                int cell = matrix[r][c];
                if (cell == 0)
                {
                    if (r == 0) rowZero = true;
                    else matrix[r][0] = 0;
                    
                    matrix[0][c] = 0;
                }
            }
        }

        // Zero out all non-zero index rows/cols
        for (int r = 1; r < nRows; r++)
        {
            for (int c = 1; c < nCols; c++)
            {
                if (matrix[r][0] == 0 || matrix[0][c] == 0)
                {
                    matrix[r][c] = 0;
                }
            }
        }

        // Check if the first col needs to be set to 0
        if (matrix[0][0] == 0)
        {
            for (int r = 0; r < nRows; r++)
            {
                matrix[r][0] = 0; 
            }
        }
    
        // Check if the first row needs to be set to 0
        if (rowZero)
        {
            for (int c = 0; c < nCols; c++)
            {
                matrix[0][c] = 0;
            }
        }
    }
}

/*

    Use the matrix itself to mark rows/cols that need to be zeroed out

    Time: O(m*n)
    Space: O(1)

*/
