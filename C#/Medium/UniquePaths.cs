public class Solution
{
    public int UniquePaths(int m, int n)
    {
        var memo = new int[m + 1][];
        for (int i = 0; i <= m; i++)
        {
            memo[i] = new int[n + 1];
        }

        int UniquePathsRecursive(int m, int n)
        {
            if (m == 1 || n == 1) return 1;
            if (m < 1 || n < 1) return 0;
            if (memo[m][n] > 0) return memo[m][n];

            memo[m][n] = UniquePathsRecursive(m - 1, n) + UniquePathsRecursive(m, n - 1);
            return memo[m][n];
        }

        return UniquePathsRecursive(m, n);        
    }
}

/*

    Brute force solution (recursion without DP/memoization)

    Time: O(2^(m+n))
    Space: O(m+n)

    -------------------------------------------------------

    Top-down memoization

    Time: O(m*n)
    Space: O(m+n) because on each recursive call, either m, or n, gets decremented

    Where m is the number of rows and n is the number of columns

*/



public class Solution2
{
    public int UniquePaths(int m, int n)
    {
        var table = new int[m + 1][];
        for (int i = 0; i <= m; i++)
        {
            table[i] = new int[n + 1];

            // Initialize all cells to 1
            for (int j = 0; j <= n; j++)
            {
                table[i][j] = 1;
            }
        }

        for (int r = 1; r <= m; r++)
        {
            for (int c = 1; c <= n; c++)
            {
                table[r][c] = table[r][c - 1] + table[r - 1][c];
            }
        } 

        return table[m - 1][n - 1];
    }
}

/*

    Bottom-up tabulation

    Example:
    [1,1,1]
    [1,2,3]
    [1,3,6]

    The sum of the top and left cells will give the sum for each cell.

    Time: O(m*n)
    Space: O(m*n)

*/
