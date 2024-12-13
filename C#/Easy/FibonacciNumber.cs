public class Solution
{
    public int Fib(int n)
    {
        var memo = new Dictionary<int, int>();

        int Recurse(int n)
        {
            if (n == 0) return 0;
            if (n == 1 || n == 2) return 1;
            if (memo.ContainsKey(n)) return memo[n];

            memo[n] = Recurse(n - 1) + Recurse(n - 2);
            return memo[n];
        }

        return Recurse(n);
    }
}

/*

    Top-down DP (memoization)
    Time: O(n)
    Space: O(n)

*/
