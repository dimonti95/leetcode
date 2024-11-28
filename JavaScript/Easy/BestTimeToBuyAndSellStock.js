/**
 * @param {number[]} prices
 * @return {number}
 */
var maxProfit = function(prices) {
 
	let max = 0;
	let left = 0;

	for (let right = 0; right < prices.length; right++) {
		let difference = prices[right] - prices[left];
		if (difference < 0) {
			left = right;
		}
		max = Math.max(max, difference);
	}

	return max;
};

/*

  Kadanes algorithm (two pointers)
  
  Time Complexity: O(n)
  Space Complexity: O(1)
  
  Where n is the length of prices

*/
