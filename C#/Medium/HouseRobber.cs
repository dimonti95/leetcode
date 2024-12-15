public class Solution
{
    public int Rob(int[] nums)
    {
        var memo = new int[nums.Length];
        Array.Fill(memo, -1);

        int RobRecursive(int i, int[] nums)
        {   
            if (i >= nums.Length) return 0;
            if (memo[i] > -1) return memo[i];
            if (i == nums.Length - 1) return nums[i];

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

    Check all combinations of houses so that no paths include adjacent "houses".

    ---------------------------------------------------------------------------

    Key insight: There is no "Greedy" alogirthm that works

*/



public class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        int max1 = nums[0];
        int max2 = nums[1];

        for (int i = 2; i < nums.Length; i++)
        {
            int temp = max1;
            max1 = Math.Max(max1, max2);
            max2 = Math.Max(max2, temp + nums[i]);
        }

        return Math.Max(max1, max2);
    }
}

/*

    Bottom-up DP (memory optimized)
    Time: O(n)
    Space: O(1)


*/
