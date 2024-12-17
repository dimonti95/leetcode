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
