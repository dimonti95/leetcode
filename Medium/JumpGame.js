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
  
  Time: O(n^2)
  Space: O(n)
  
  n = length of nums
  m = the average value at each index

  Example: [5,4,3,2,1,0,3] to understand why memoized top down time complexity is O(n*n).

*/



/**
 * @param {number[]} nums
 * @return {boolean}
 */
var canJump = function(nums) {
  
  let table = new Array(nums.length).fill(false);
  table[nums.length - 1] = true;
  
  for (let i = nums.length - 2; i >= 0; i--) {
    for (let j = 1; j <= nums[i]; j++) {
      if (table[i + j]) {
        table[i] = true;
        break;
      }
    }
  }
  
  return table[0];
};

/*

  Bottom-up DP (Tabulation)
  
  Time: O(n^2)
  Space: O(n)

  Example: [5,4,3,2,1,0,3] to understand why memoized top down time complexity is O(n*n).

*/



/**
 * @param {number[]} nums
 * @return {boolean}
 */
var canJump = function(nums) {
  let lastPos = nums.length - 1;
  
  for (let i = nums.length - 2; i >= 0; i--) {
    if (i + nums[i] >= lastPos)
      lastPos = i;
  }
  
  return lastPos == 0;
};

/*

  Greedy
  
  Time: O(n)
  Space: O(1)

*/
