public class Solution {
    public int MaxProfit(int[] prices) {
        int left = 0;
        int max = 0;

        for (int right = 0; right < prices.Length; right++)
        {
            int diff = prices[right] - prices[left];
            if (diff < 0)
                left = right;
            max = Math.Max(max, diff);
        }

        return max;
    }
}

/*

  Kadanes algorithm (two pointers)
  
  Time Complexity: O(n)
  Space Complexity: O(1)
  
  Where n is the length of prices

*/
