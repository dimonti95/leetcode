public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int left = 0;
        int right = numbers.Length - 1;

        while (left < right)
        {
            int sum = numbers[left] + numbers[right];

            // check for result
            if (sum == target)
                return [left + 1, right + 1];

            if (sum > target) right--;
            else left++;

        }

        return null;
    }
}

/*

  Using two pointers check the sum each iteration and if the current sum is greater than target go to the next 
  smallest number from right, if the current sum is smaller than the target go to the next largest number from left.

  Time Complexity: O(n)
  Space Complexity: O(1)
  
  Where n is the length of numbers.

*/

