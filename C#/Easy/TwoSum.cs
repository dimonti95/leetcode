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

/*

  Loop over nums and keep a mapping of each number to its index, if the difference exists int he map than return the 
  index of that number and the current index.
  
  Time Complexity: O(n)
  Space Complexity: O(n)
  
  Where n is the size of the nums array

*/
