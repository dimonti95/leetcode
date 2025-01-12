public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        int nRows = matrix.Length;
        int nCols = matrix[0].Length;
        
        int top = 0;
        int bottom = nRows;
        int left = 0;
        int right = nCols;

        var result = new List<int>();
        while (top < bottom && left < right)
        {
            // Right
            for (int i = left; i < right; i++)
            {
                result.Add(matrix[top][i]);
            }
            top++;

            // Down
            for (int i = top; i < bottom; i++)
            {
                result.Add(matrix[i][right - 1]);
            }
            right--;

            if (top >= bottom || left >= right) 
            {
                break;
            }

            // Left
            for (int i = right - 1; i >= left; i--)
            {
                result.Add(matrix[bottom - 1][i]);
            }
            bottom--;

            // Up
            for (int i = bottom - 1; i >= top; i--)
            {
                result.Add(matrix[i][left]);
            }
            left++;
        }

        return result;
    }
}

/*

    Solution:
    * Keep pointers at the bounds of the matrix
    * Change directions once a boundary is reached
    * Move the boundaries towards the center of the matrix after each row/col is traversed

    Time: O(m*n)
    Space: O(1)

*/
