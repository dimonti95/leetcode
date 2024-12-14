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

    Top-down memoization

    Time: O(m*n)
    Space: O(m+n) because on each recursive call, either m, or n, gets decremented

    Where m is the number of rows and n is the number of columns

*/
