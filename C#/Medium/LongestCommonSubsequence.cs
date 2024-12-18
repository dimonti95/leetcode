public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        var memo = new int[text1.Length][];
        for (int i = 0; i < memo.Length; i++)
        {
            memo[i] = new int[text2.Length];
            Array.Fill(memo[i], -1);
        }

        int LongestCommonSubsequenceRecursive(int i1, int i2, string t1, string t2)
        {
            if (i1 >= t1.Length || i2 >= t2.Length) return 0;
            if (memo[i1][i2] > -1) return memo[i1][i2];

            int max1 = 0;
            for (int i = i2; i < t2.Length; i++)
            {
                if (t1[i1] == t2[i])
                {
                    max1 = 1 + LongestCommonSubsequenceRecursive(i1 + 1, i + 1, t1, t2);
                    break;
                }
            }

            int max2 = LongestCommonSubsequenceRecursive(i1 + 1, i2, t1, t2);
            memo[i1][i2] = Math.Max(max1, max2);
            return memo[i1][i2];
        }

        return LongestCommonSubsequenceRecursive(0, 0, text1, text2);
    }
}

/*

    Brute force solution
    * Recursively generate every possible subsequence of text1
    * This would take O(2^L) time where L is the length of the string

    ---------------------------------------------------------------------

    Top-down DP (memoization)

    Time: O(m*n^2)
    * The recursion tree accounts for O(m*n)
    * The additional n is included since we're looping text2 array on each recursive call (worst case)

    Space: O(m*n)
    * The memo accounts for O(m*n) space

    Where n is the length of text1, and m is the length of text2.

*/



public class Solution2
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        var memo = new int[text1.Length][];
        for (int i = 0; i < memo.Length; i++)
        {
            memo[i] = new int[text2.Length];
            Array.Fill(memo[i], -1);
        }

        int LongestCommonSubsequenceRecursive(int i1, int i2)
        {
            if (i1 >= text1.Length || i2 >= text2.Length) return 0;
            if (memo[i1][i2] > -1) return memo[i1][i2];

            int max1 = 0;
            if (text1[i1] == text2[i2]) max1 = 1 + LongestCommonSubsequenceRecursive(i1 + 1, i2 + 1);

            int max2 = Math.Max(LongestCommonSubsequenceRecursive(i1 + 1, i2), LongestCommonSubsequenceRecursive(i1, i2 + 1));
            memo[i1][i2] = Math.Max(max1, max2);
            return memo[i1][i2];
        }

        return LongestCommonSubsequenceRecursive(0, 0);
    }
}

/*

    Optimized Top-down DP (memoization)

    Time: O(m*n)
    Space: O(m*n)

    Where n is the length of text1, and m is the length of text2.

*/



public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        var table = new int[text1.Length + 1][];
        for (int i = 0; i < table.Length; i++)
        {
            table[i] = new int[text2.Length + 1];
        }

        for (int r = 1; r < table.Length; r++)
        {
            for (int c = 1; c < table[r].Length; c++)
            {
                if (text1[r - 1] == text2[c - 1])
                {
                    table[r][c] = table[r - 1][c - 1] + 1;
                }
                else
                {
                    table[r][c] = Math.Max(table[r][c - 1], table[r - 1][c]);
                }
            }
        }

        return table[table.Length - 1][table[0].Length - 1];
    }
}


/*

    Bottom-up DP (tabulation)

    Time: O(m*n)
    Space: O(m*n)

    ---------------------------------------------------------

    Example
    Input: text1="ccrx", text2="cctx"
    Output: 3 ("ccx")

           c c r x
         0 1 2 3 4
      0 [0,0,0,0,0]
    c 1 [0,1,1,1,1]
    c 2 [0,1,2,2,2]
    t 3 [0,1,2,2,2]
    x 4 [0,1,2,2,3]

    * Iterate the matrix, comparing every character of each string
    * If a character match is found, add one to the value in the previous row: table[r - 1][c - 1] + 1
    * Otherwise, take the max of previous row and previous column:  Math.Max(table[r - 1][c], table[r][c - 1])

    It could also be done in reverse order:

         c c r x
         0 1 2 3 4
    c 0 [3,2,1,1,0]
    c 1 [2,2,1,1,0]
    t 2 [1,1,1,1,0]
    x 3 [1,1,1,1,0]
      4 [0,0,0,0,0]

*/
