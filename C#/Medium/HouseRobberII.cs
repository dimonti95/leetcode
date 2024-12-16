public class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        int RobRecursive(int startIndex, int endIndex, int[] nums)
        {
            int max1 = 0;
            int max2 = 0;

            for (int i = startIndex; i <= endIndex; i++)
            {
                int temp = max1;
                max1 = Math.Max(max1, max2 + nums[i]);
                max2 = temp;
            }

            return max1;
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
