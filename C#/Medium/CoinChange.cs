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



public class Solution2
{
    public int CoinChange(int[] coins, int amount)
    {
        var table = new int[amount + 1];
        Array.Fill(table, amount + 1);

        table[0] = 0;
        for (int i = 1; i <= amount; i++)
        {
            foreach (int coin in coins)
            {
                if (coin <= i)
                {
                    table[i] = Math.Min(table[i], table[i - coin] + 1);
                }
            }
        }

        return table[amount] > amount ? -1 : table[amount];
    }
}

/*

    Top-down DP (memoization)

    Time: O(a * c)
    Space: O(a)

    Where a is the amount and c is the denomination count (the size of coins)

    Example
    coins = [2,5,6]
    amount = 10
    result = (5 + 5 = 10) = 2

    table[i]  =  r   =  Math.Min(table[i], table[i - coin[j]] + 1)
    table[0]  =  0
    table[1]  =  11
    table[2]  =  1   =  Math.Min(11, table[2 - 2] + 1)
    table[3]  =  11  =  Math.Min(11, table[3 - 2] + 1)
    table[4]  =  2   =  Math.Min(11, table[4 - 2] + 1)
    table[5]  =  1   =  Math.Min(11, table[5 - 5] + 1)
    table[6]  =  1   =  Math.Min(11, table[6 - 6] + 1)
    table[7]  =  2   =  Math.Min(11, table[7 - 2] + 1)
    table[8]  =  2   =  Math.Min(11, table[8 - 2] + 1)
    table[9]  =  3   =  Math.Min(11, table[9 - 2] + 1)
    table[10] =  2   =  Math.Min(11, table[10 - 5] + 1)
    table[11] =  2   =  Math.Min(11, table[11 - 5] + 1)

*/
