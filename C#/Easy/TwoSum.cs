public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            var diff = target - num;
            if (map.ContainsKey(diff))
            {
                return [map[diff], i];
            }
            else
            {
                map.Add(num, i);
            }
        }

        return null;
    }
}