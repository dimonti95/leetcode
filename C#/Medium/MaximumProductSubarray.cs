public class Solution
{
    public int MaxProduct(int[] nums)
    {
        int currentMin = 1;
        int currentMax = 1;
        int max = nums[0];

        for (int i = 0; i < nums.Length; i++)
        {
            int temp = currentMax;
            currentMax = Math.Max(Math.Max(nums[i] * currentMin, nums[i] * currentMax), nums[i]);
            currentMin = Math.Min(Math.Min(nums[i] * currentMin, nums[i] * temp), nums[i]);

            max = Math.Max(max, currentMax);
        }

        return max;
    }
}

/*

    Track current max and min products at each index (to deal with negatives)

    Example: [2,3,-2,4]
    0: [2, 2]
    1: [2, 6]
    2: [-12, -2]
    3: [-48, 4]

    i: [currMin, currMax]
    
    Time Complexity: O(n)
    Space Complexity: O(1)
    
    Where n is the length of nums

    Key insight: Zeros and negative numbers can cause an algorithm to lose the max product

*/
