public class Solution {
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
