/**
 * @param {number[]} nums
 * @return {number[]}
 */
 var productExceptSelf = function(nums) {
    
  let ans = [];
  
  let prefix = 1;
  for (let i = 0; i < nums.length; i++) {
      prefix *= nums[i];
      ans.push(prefix);
  }
  
  let postfix = 1;
  for (let i = nums.length - 1; i >= 0; i--) {
      let current = ans[i - 1] !== undefined ? ans[i - 1] : 1;
      ans[i] = current * postfix;
      postfix *= nums[i];
  }
  
  return ans;
  
};

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
  Space Compelxity: O(1) Not counting answer array
  
  Where n is the size of the array

*/
