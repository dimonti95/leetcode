public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        return MaxSubArrayRecursive(0, nums.Length - 1, nums);
    }

    private int MaxSubArrayRecursive(int left, int right, int[] nums)
    {
        if (left > right) return int.MinValue;

        int mid = (left + right) / 2;

        // left sum
        int count = 0;
        int leftSum = 0;
        for (int i = mid - 1; i >= left; i--)
        {
            count += nums[i];
            leftSum = Math.Max(leftSum, count);
        }

        // right sum
        count = 0;
        int rightSum = 0;
        for (int i = mid + 1; i <= right; i++)
        {
            count += nums[i];
            rightSum = Math.Max(rightSum, count);
        }

        int leftMax = MaxSubArrayRecursive(left, mid - 1, nums);
        int rightMax = MaxSubArrayRecursive(mid + 1, right, nums);

        int combinedMax = nums[mid] + leftSum + rightSum;
        return Math.Max(combinedMax, Math.Max(leftMax, rightMax));
    }
}

/*

    Divide and Conquer

    Time: O(nlogn)
    Space: O(logn)

    Solution for the follow-up question: Follow up: If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.

*/



public class Solution2
{
    public int MaxSubArray(int[] nums)
    {
        int max = nums[0];
        int currentSum = 0;

        for (int i = 0; i < nums.Length; i++) 
        {
            currentSum = Math.Max(nums[i], currentSum + nums[i]);
            max = Math.Max(max, currentSum);
        }

        return max;
    }
}

/* 

  Bottom-up DP (memory optimized)

  Loop over the array keeping a current sum to be either the current value or the current sum up to that point
  + the current value, whichever is larger. Then check for a new max.

  (Kadane's Algorithm)

  Time Complexity: O(n)
  Space Complexity: O(1)

*/
