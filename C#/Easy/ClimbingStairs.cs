public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n == 0 || n == 1) return 1;

        return ClimbStairs(n - 1) + ClimbStairs(n - 2);
    }
}

/*

    Brute force
    * Try all possible combinations

    Time: O(2^n)
    Space: O(n) because of the depth of the call stack (recursion tree)

*/