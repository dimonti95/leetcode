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



public class Solution2
{
    public int Fib(int n)
    {
        if (n == 0) return 0;

        int fib1 = 0;
        int fib2 = 1;
        int count = 1;

        while (count < n)
        {
            int temp = fib1 + fib2;
            fib1 = fib2;
            fib2 = temp;
            count++;
        }

        return fib2;
    }
}

/*

    Bottom-up DP (tabulation)
    Time: O(n)
    Space: O(1)

*/
