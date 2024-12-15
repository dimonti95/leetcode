public class Solution
{
    public int Rob(int[] nums)
    {
        var memo = new int[nums.Length];
        for (int i = 0; i < memo.Length; i++) memo[i] = -1;

        int RobRecursive(int i, int[] nums)
        {   
            if (i >= nums.Length) return 0;
            if (memo[i] > -1) return memo[i];
            if (i == nums.Length - 1) return nums[i];
            if (i == nums.Length - 2) return nums[i] > nums[i + 1] ? nums[i] : nums[i + 1];

            int left = nums[i];
            int right = nums[i + 1];
            left += RobRecursive(i + 2, nums);
            right += RobRecursive(i + 3, nums);

            memo[i] = Math.Max(left, right);
            return memo[i];
        }

        return RobRecursive(0, nums);
    }
}

/*

    Top-down DP (memoization)

    Time: O(n)
    Space: O(n/2) = O(n)

*/
