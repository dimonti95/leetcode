public class Solution
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
