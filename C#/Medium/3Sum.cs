public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        // Sort the array
        Array.Sort(nums);

        var res = new List<IList<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            int j = i + 1;
            int k = nums.Length - 1;

            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];

                if (sum == 0)
                {
                    res.Add(new List<int>{ nums[i], nums[j], nums[k] });
                    j++;
                    while (j < k && nums[j] == nums[j - 1])
                        j++;
                }
                else if (sum > 0)
                {
                    k--;
                }
                else
                {
                    j++;
                }
            }
        }

        return res;
    }
}

/*

    (1) Sort nums
    (2) Loop the array from start to finish with the first pointer
    (3) Implement Two Sum II algorithm on the sorted array to find triplets that sum to 0
    
    Time Complexity: O(n^2)
    Space Complexity: O(1) or O(n) (Depends on sorting implementation)
    
    Where n is the length of nums

*/
