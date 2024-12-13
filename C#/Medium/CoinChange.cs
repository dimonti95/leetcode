public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        var memo = new Dictionary<int, int>();

        int CoinChangeRecursive(int[] coins, int amount)
        {
            if (amount < 0) return -1;
            if (amount == 0) return 0;
            if (memo.ContainsKey(amount)) return memo[amount];

            int min = Int32.MaxValue;
            foreach (int coin in coins)
            {
                int result = CoinChangeRecursive(coins, amount - coin);
                if (result != -1)
                {
                    min = Math.Min(min, result);
                }
            }

            memo[amount] = min == Int32.MaxValue ? -1 : min + 1;
            return memo[amount];
        }

        return CoinChangeRecursive(coins, amount);
    }
}

/*

    Top-down DP (memoization)

    Time: O(a * c)
    Space: O(a)

    Where a is the amount and c is the denomination count (the size of coins)

*/
