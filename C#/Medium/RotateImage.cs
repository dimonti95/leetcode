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



public class Solution2
{
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;
        Transpose(matrix, n);
        Reflect(matrix, n);
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
    /// <param name="n">The number of rows/cols.</param>
    private void Transpose(int[][] matrix, int n)
    {
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
    /// <param name="n">The number of rows/cols.</param>
    private void Reflect(int[][] matrix, int n)
    {
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

    Solution 2

    Transpose + Reflect
    
    Time: O(m)
    Space: O(1)

    Where m is the number of cells in the matrix


    ---------------------------------------------------

    A good starting point is to think through common matrix operations.

    Two of the most common/simple matrix operations are:
    * Row swap = swap two rows in the matrix
    * Col swap = swap two columns in the matrix

    After giving it some thought, it's obvious that there is no way to solve this using those two operations alone, that's where transpose comes in.

    Example transpose:

    [1,2,3]
    [4,5,6]

    =

    [1,4]
    [2,5]
    [3,6]

    Using an n * n example you get:

    [1,2,3]
    [4,5,6]
    [7,8,9]

    =

    [1,4,7]
    [2,5,8]
    [3,6,9]

    And from there it's obvious that you just need to swap the two columns. But this won't be enough for a bigger n * n matrix,
    which will have more columns that need to be swapped. And that's how you can derive the rotate operation.

*/
