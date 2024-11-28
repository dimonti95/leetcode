/**
 * @param {number} n - a positive integer
 * @return {number}
 */
 var hammingWeight = function(n) {
    
  let flag = 1;
  let count = 0;
  
  for (let i = 0; i < 32; i++) {
      if (n & flag) count++;
      flag *= 2;
  }
  
  return count;
};

/*

  Check each bit from LSB to MSB and increment count if the bit is set
  
  Time Complexity: O(1)
  Space Complexity: O(1)

*/
