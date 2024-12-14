public class Solution
{
    public bool CanJump(int[] nums)
    {
        var memo = new Dictionary<int, bool>();

        bool CanJump(int num)
        {
            if (num == nums.Length - 1) return true;
            if (num >= nums.Length) return false;
            if (memo.ContainsKey(num)) return memo[num];

            for (int jump = 1; jump <= nums[num]; jump++)
            {
                if(CanJump(num + jump))
                {
                    memo[num] = true;
                    return memo[num];
                }
            }

            memo[num] = false;
            return memo[num];
        }

        return CanJump(0);
    }
}
/*

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
            int distance = last - i;
            if (nums[i] >= distance) last = i;
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
