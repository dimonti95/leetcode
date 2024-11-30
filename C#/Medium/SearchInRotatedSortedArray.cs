public class Solution {
    public int Search(int[] nums, int target) {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int middle = (int)Math.Floor((double)(right + left) / 2);

            if (nums[middle] == target)
            {
                return middle;
            }
            else if (nums[left] <= nums[middle])
            {
                if (target >= nums[left] && target < nums[middle])
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
            else if (nums[right] >= nums[middle])
            {
                if (target > nums[middle] && target <= nums[right])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
        }

        return -1;
    }
}

/*

    Binary Search with left and right pointers
    (1) Figure out which part of the sorted array the middle is in
    (2) Check if target is in that range

    Time Complexity: O(n)
    Space Complexity: O(1)

*/
