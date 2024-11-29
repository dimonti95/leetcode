public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int leftProduct = 1;
        var res = new int[nums.Length];

        int rightProduct = 1;
        for (int right = nums.Length - 1; right >= 0; right--)
        {
            rightProduct *= nums[right];
            res[right] = rightProduct;
        }

        for (int left = 0; left < nums.Length; left++)
        {
            if (left + 1 < nums.Length)
                rightProduct = res[left + 1];
            else
                rightProduct = 1;

            res[left] = leftProduct * rightProduct;
            leftProduct *= nums[left];
        }

        return res;
    }
}

/*

  Example: [1,2,3,4]
  
  Prefix =  [1,  2,  6, 24]
  Postfix = [24, 24, 12, 4]

  6 = (6 * 1)
  8 = (4 * 2)
  12 = (2 * 6)
  24 = (1 * 24)
  Answer = [24, 12, 8, 6]
  
  Get value of each index by multiplying prefix/postfix values
  
  Time Complexity: O(n)
  Space Compelxity: O(1) Not counting result array
  
  Where n is the size of the array

*/
