/**
 * @param {number} n - a positive integer
 * @return {number} - a positive integer
 */
 var reverseBits = function(n) {
    
  let start = 1;
  let end = Math.pow(2, 31);
  
  for (let i = 0; i < 16; i++) {
      let startSet = (start & n) !== 0;
      let endSet = (end & n) !== 0;
      
      if (startSet !== endSet) {
          n = n ^ start;
          n = n ^ end;
      }
      
      start *= 2;
      end /= 2;
  }
  
  return n >>> 0; // return unsigned
};

/*

  Keep a pointer on the MSB and LSB and each iteration invert the bits if they're different.

  Time Complexity: O(1)
  Space Complexity: O(1)

  Since there will always be only 32 bits

*/
