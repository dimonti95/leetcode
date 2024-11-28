/**
 * @param {number[]} nums
 * @return {number}
 */
 var majorityElement = function(nums) {
    
  let map = {};
  
  for (let i = 0; i < nums.length; i++) {
      map[nums[i]] ? map[nums[i]]++ : map[nums[i]] = 1;
      if (map[nums[i]] > nums.length/2) return nums[i];
  }
  
};

/*
  
  Create a map that tracks the total number of occurences of each number
  
  Time Complexity: O(n)
  Space Complexity: O(n)
  
  Where n is the length of the nums array

*/
