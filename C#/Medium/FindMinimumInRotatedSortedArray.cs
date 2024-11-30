public class Solution {
    public int FindMin(int[] nums) {
        int left = 0;
        int right = nums.Length - 1;
        int min = nums[0];

        while (left <= right)
        {
            int middle = (int)Math.Floor((double)(left + right) / 2);

            // look for sorted half
            if (nums[left] <= nums[middle])
            {
                min = Math.Min(min, nums[left]);
                left = middle + 1;
            }
            else if (nums[middle] <= nums[right])
            {
                min = Math.Min(min, nums[middle]);
                right = middle - 1;
            }
        }

        return min;
    }
}

/*

    Binary search
    1. Find the middle
    2. Compare to the left and right number and find sorted half
    3. Set the minimum to be the smallest number in the sorted half
    4. Move on to the other half
    
    Time Complexity: O(logn)
    Space Complexity: O(1)

*/
