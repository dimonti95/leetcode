/**
 * @param {number[]} nums
 * @return {boolean}
 */
 var canJump = function(nums, i = 0) {
  
    if (i === nums.length - 1)
      return true;
    if (nums[i] === 0 || i >= nums.length)
      return false;
    
    // try the biggest jumps first
    for (let j = nums[i]; j >= 1; j--) {
      let res = canJump(nums, i + j);
      if (res === true)
        return true;
    }
    
    return false;
  };
  
  /*
  
    Brute Force
    
    Time: O(m^n)
    Space: O(n)
    
    n = length of nums
    m = the average value at each index
  
  */  



/**
 * @param {number[]} nums
 * @return {boolean}
 */
var canJump = function(nums, i = 0, mem = {}) {
  
  if (i in mem)
    return mem[i];
  if (i === nums.length - 1)
    return true;
  if (nums[i] === 0 || i >= nums.length)
    return false;
  
  // try the biggest jumps first
  for (let j = nums[i]; j >= 1; j--) {
    mem[i] = canJump(nums, i + j, mem);
    if (mem[i] === true)
      return true;
  }
  
  return false;
};

/*

  Top-Down Memoized DP
  
  Time: O(n*m)
  Space: O(n)
  
  n = length of nums
  m = the average value at each index

*/
