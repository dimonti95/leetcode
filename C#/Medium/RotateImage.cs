public class Solution {
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;
        int l = 0;
        int r = n - 1;
        while (l < r)
        {
            for (int i = 0; i < r - l; i++)
            {
                int temp = matrix[l][l + i];
                matrix[l][l + i] = matrix[r - i][l];
                matrix[r - i][l] = matrix[r][r - i];
                matrix[r][r - i] = matrix[l + i][r];
                matrix[l + i][r] = temp;
            }
            
            l++;
            r--;
        }
    }
}

/*

    Time: O(m)
    Space: O(1)

    Where m is the total number of cells

*/



public class Solution {
    public void Rotate(int[][] matrix)
    {
        Transpose(matrix);
        Reflect(matrix);

    }

    /// <summary>
    /// Transpose = to swap rows and columns
    ///
    ///     Transposing a 3x3 matrix:
    ///     [1,2,3]    [1,4,7]
    ///     [4,5,6] => [2,5,8]
    ///     [7,8,9]    [3,6,9]
    ///
    ///     1. [0,0] => [0,0]
    ///     2. [0,1] => [1,0]
    ///     3. [0,2] => [2,0]
    ///     4. [1,1] => [1,1]
    ///     5. [1,2] => [2,1]
    ///     6. [2,2] => [2,2]
    ///
    /// </summary>
    /// <param name="matrix">The matrix to be transposed.</param>
    private void Transpose(int[][] matrix)
    {
        int n = matrix.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                int temp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = temp;
            }
        }
    }

    /// <summary>
    /// Reflect = Swap values at each end of every row
    ///
    ///     Reflecting a 3x3 matrix:
    ///     [1,4,7]    [7,4,1]
    ///     [2,5,8] => [8,5,2]
    ///     [3,6,9]    [9,6,3]
    ///
    ///     1. [0,0] => [0,2]
    ///     2. [1,0] => [1,2]
    ///     3. [2,0] => [2,2]
    ///
    /// </summary>
    /// <param name="matrix">The matrix to be transposed.</param>
    private void Reflect(int[][] matrix)
    {
        int n = matrix.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n/2; j++)
            {
                int temp = matrix[i][j];
                matrix[i][j] = matrix[i][n - 1 - j];
                matrix[i][n - 1 - j] = temp;
            }
        }
    }
}

/*

    Transpose + Reflect
    
    Time: O(m)
    Space: O(1)

    Where m is the number of cells in the matrix

*/
