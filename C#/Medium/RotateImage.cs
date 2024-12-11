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
