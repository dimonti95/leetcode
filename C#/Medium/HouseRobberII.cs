public class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        int RobRecursive(int startIndex, int endIndex, int[] nums)
        {
            if (startIndex + 1 > endIndex) return nums[startIndex];

            int max1 = nums[startIndex];
            int max2 = nums[startIndex + 1];

            for (int i = startIndex + 2; i <= endIndex; i++)
            {
                int temp = max1;
                max1 = Math.Max(max1, max2);
                max2 = Math.Max(max2, temp + nums[i]);
            }

            return Math.Max(max1, max2);
        }

        int max1 = RobRecursive(0, nums.Length - 2, nums);
        int max2 = RobRecursive(1, nums.Length - 1, nums);
        return Math.Max(max1, max2);
    }
}

/*

    Bottom-up DP (memory optimized)
    Time: O(n)
    Space: O(1)

*/
