public class Solution
{
    public bool CanJump(int[] nums)
    {
        var memo = new bool?[nums.Length + 1];
        bool dp(int[] nums, int index)
        {
            if (index == nums.Length - 1) return true;
            if (memo[index] != null) return memo[index].Value;

            // Optimization: It's unecessary to jump past the last index
            int maxJump = Math.Min(nums[index] + 1, nums.Length - index);

            for (int jump = 1; jump < maxJump; jump++)
            {
                if (dp(nums, index + jump))
                {
                    memo[index] = true;
                    return memo[index].Value;
                }
            }

            memo[index] = false;
            return memo[index].Value;
        }

        return dp(nums, 0);
    }
}

/*

    Brute force solution (non-memoized)

    Time: O(2^n) because 2^n-2 = 2^n
    Space: O(n) because this is the max height of the tree (recursion depth)

    Note: Not implemented here

    ----------------------------------------------------------------------------------------

    Top-down DP (memoization)

    Time: O(n^2)
    Space: O(n)

    Where n is the length of the input array

*/



public class Solution2
{
    public bool CanJump(int[] nums)
    {
        int last = nums.Length - 1;

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            if (i + nums[i] >= last) last = i;
        }

        return last == 0;
    }
}

/*
    
    Bottom-up DP (tabulation)
    * Create a new array of bools where each value represents whether or not the last index can be reached
    * The last index will always be true, this is the base case (smallest sub-problem)
    * Iterate, starting from the back of nums/table 
    * If n - 1 index can reach the next closest "true index" then it is also true, otherwise false

    Time: O(n)
    Space: O(n)

    Example
    Input: nums=[2,3,4,0,0,1,2]
    Output: true

    Bottom-up DP starting from the back of the array

    i = -  nums  = [2,3,4,0,0,1,2]
           table = [F,F,F,F,F,F,T]
                                ^

    i = 5  nums  = [2,3,4,0,0,1,2]
           table = [F,F,F,F,F,T,T]  1 >= (6-5) = T
                              ^ ^

    i = 4  nums  = [2,3,4,0,0,1,2]
           table = [F,F,F,F,F,T,T]  0 >= (5-4) = F
                            ^ ^

    i = 3  nums  = [2,3,4,0,0,1,2]
           table = [F,F,F,F,F,T,T]  0 >= (5-3) = F
                          ^   ^

    i = 2  nums  = [2,3,4,0,0,1,2]
           table = [F,F,T,F,F,T,T]  4 >= (5-2) = T
                        ^     ^
    
    i = 1  nums  = [2,3,4,0,0,1,2]
           table = [F,T,T,F,F,T,T]  3 >= (2-1) = T
                      ^ ^    

    i = 0  nums  = [2,3,4,0,0,1,2]
           table = [T,T,T,F,F,T,T]  2 >= (1-0) = T
                    ^ ^ 

    But it's not necessary to use the table to track the true/false value for each index in nums.

    Optimized Bottom-up DP
    * Iterate, starting from the back of nums, keeping tracking of the last index that can reach the back of the nums array
    * If n - 1 index can reach the next closest "true index" then updat that index to be the new last index

    Time: O(n)
    Space: O(1)

    Example
    Input: nums=[2,3,4,0,0,1,2]
    Output: true

    i = -  nums  = [2,3,4,0,0,1,2]
                                ^

    i = 5  nums  = [2,3,4,0,0,1,2]  1 >= (6-5) = T
                              ^ ^

    i = 4  nums  = [2,3,4,0,0,1,2]  0 >= (5-4) = F
                            ^ ^

    i = 3  nums  = [2,3,4,0,0,1,2]  0 >= (5-3) = F 
                          ^   ^

    i = 2  nums  = [2,3,4,0,0,1,2]  4 >= (5-2) = T 
                        ^     ^
    
    i = 1  nums  = [2,3,4,0,0,1,2]  3 >= (2-1) = T 
                      ^ ^    

    i = 0  nums  = [2,3,4,0,0,1,2]  2 >= (1-0) = T 
                    ^ ^        

*/
