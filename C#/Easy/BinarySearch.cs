public class Solution
{
    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        while (left <= right)
        {
            int middle = (left + right) >>> 1;
            if (nums[middle] == target)
            {
                return middle;
            }
            else if (nums[middle] < target)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return -1;
    }
}

/*

    Binary Search

    Time: O(logn)
    Space: O(1)

*/



public class Solution2
{
    public int Search(int[] nums, int target)
    {
        int i = Array.BinarySearch(nums, target);
        return i < 0 ? -1 : i;
    }
}

/*
    
    Solution 2: Use a built in function.

    Time: O(logn)
    Space: O(1)

*/
