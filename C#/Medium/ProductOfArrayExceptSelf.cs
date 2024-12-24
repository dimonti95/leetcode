public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var result = new int[nums.Length];

        int rightProduct = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            rightProduct *= nums[i];
            result[i] = rightProduct;
        }

        int leftProduct = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            rightProduct = i + 1 < nums.Length ? result[i + 1] : 1;
            result[i] = leftProduct * rightProduct;
            leftProduct *= nums[i];
        }

        return result;
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
