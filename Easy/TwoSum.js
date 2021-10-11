/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
 var twoSum = function(nums, target) {
    
  let map = {};

  for (let i = 0; i < nums.length; i++) {
    const difference = target - nums[i];
    if (map[difference] !== undefined) return [i, map[difference]];
    map[nums[i]] = i;
  }
  
};

/*

  Loop over nums and keep a mapping of each number to its index, if the difference exists int he map than return the 
  index of that number and the current index.
  
  Time Complexity: O(n)
  Space Complexity: O(n)
  
  Where n is the size of the nums array

*/
