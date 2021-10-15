/**
 * @param {number[]} prices
 * @return {number}
 */
 var maxProfit = function(prices) {
   
  let max = 0;
  let i = 0;
  let j = 1;
  
  while (j < prices.length) {
      const difference = prices[j] - prices[i];
      if (difference < 0) {
          i = j;
          j += 1;
      }
      else {
          max = Math.max(max, difference);
          j++;
      }
  }
  
  return max;
};

/*

  Kadanes algorithm (two pointers)
  
  Time Complexity: O(n)
  Space Complexity: O(1)
  
  Where n is the length of prices

*/
