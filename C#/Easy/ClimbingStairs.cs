public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n == 0 || n == 1) return 1;

        return ClimbStairs(n - 1) + ClimbStairs(n - 2);
    }
}

/*

    Brute force recursion
    * Try all possible combinations

    Time: O(2^n)
    Space: O(n) because of the depth of the call stack (recursion tree)

*/



public class Solution {
    public int ClimbStairs(int n)
    {
        var memo = new int[n + 1];

        int Recurse(int n)
        {
            if (n == 0 || n == 1) return 1;
            if (memo[n] > 0) return memo[n];
            
            memo[n] = Recurse(n - 1) + Recurse(n - 2);
            return memo[n];
        }

        return Recurse(n);
    }
}

/*

    Top-down DP

    Time: O(n)
    Space: O(n)

*/



public class Solution 
{
    public int ClimbStairs(int n)
    {
        int step1 = 0;
        int step2 = 1;
        int count = 0;

        while (count < n)
        {
            int sum = step1 + step2;
            step1 = step2;
            step2 = sum;
            count++;
        }

        return step2;
    }
}

/*

    Bottom-up DP
    Time: O(n)
    Space: O(1)

*/
