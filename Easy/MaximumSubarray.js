/**
 * @param {number[]} nums
 * @return {number}
 */
 var maxSubArray = function(nums) {
    
  let max = nums[0];
  let currentSum = Number.MIN_SAFE_INTEGER;
  
  for (let i = 0; i < nums.length; i++) {
      currentSum = Math.max(nums[i], currentSum + nums[i]);
      max = Math.max(currentSum, max)
  }
  
  return max;
  
};

/* 

  Explanation:

  Loop over the array keeping a current sum to be either the current value or the current sum up to that point
  + the current value, whichever is larger. Then check for a new max.

  (Kadane's Algorithm)

  Time Complexity: O(n)
  Space Complexity: O(1)

*/
