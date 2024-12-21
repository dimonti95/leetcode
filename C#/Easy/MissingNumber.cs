public class Solution
{
    public int MissingNumber(int[] nums)
    {
        Array.Sort(nums);

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1] + 1) return nums[i - 1] + 1;
        }

        int n = nums.Length;
        return nums[n - 1] != n ? n : 0;
    }
}

/*

    Solution 1

    Sorting

    Time: O(nlogn)
    Space: O(1) (depending on sorting algorithm)

    Given an array nums containing n distinct numbers in the range [0, n], return the only number in the range that is missing from the array.

*/
