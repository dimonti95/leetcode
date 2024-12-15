public class Solution
{
    public int NumDecodings(string s)
    {
        var memo = new Dictionary<int, int>();

        int NumDecodingsRecurse(int i, string s)
        {
            if (memo.ContainsKey(i)) return memo[i];
            if (i == s.Length) return 1;
            if (s[i] == '0') return 0;
            if (i == s.Length - 1) return 1;

            int result = NumDecodingsRecurse(i + 1, s);

            string pair = s.Substring(i, 2);
            if (int.Parse(pair) <= 26)
            {
                result += NumDecodingsRecurse(i + 2, s);
            }

            memo[i] = result;
            return memo[i];
        }

        return NumDecodingsRecurse(0, s);
    }
}

/*

    Top-down DP (memoization)

    Time: O()
    Space: O()

*/
