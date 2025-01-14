public class Solution
{
    public int MinDistance(string word1, string word2)
    {
        var memo = new int?[word1.Length + 1][];
        for (int i = 0; i <= word1.Length; i++) memo[i] = new int?[word2.Length + 1];

        int dp(string word1, string word2, int len1, int len2)
        {
            if (memo[len1][len2] != null) return memo[len1][len2].Value;

            if (len1 == 0)
            {
                return len2;
            }
            else if (len2 == 0)
            {
                return len1;
            }
            else if (word1[len1 - 1] == word2[len2 - 1])
            {
                memo[len1][len2] = dp(word1, word2, len1 - 1, len2 - 1);
            }
            else
            {
                int del = 1 + dp(word1, word2, len1 - 1, len2 - 1); // delete
                int rep = 1 + dp(word1, word2, len1 - 1, len2); // replace
                int ins = 1 + dp(word1, word2, len1, len2 - 1); // insert
                memo[len1][len2] = Math.Min(Math.Min(del, rep), ins);
            }

            return memo[len1][len2].Value;
        }

        return dp(word1, word2, word1.Length, word2.Length);
    }
}

/*

    Top-down DP

    Time: O(n * m)
    Space: O(n * m)

    Where n is the length of word1 and m is the length of word2
    
*/
