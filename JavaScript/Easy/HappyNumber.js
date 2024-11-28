/**
 * @param {number} n
 * @return {boolean}
 */
 var isHappy = function(n) {
    
  let seen = {};
  let sum = 0;
  
  while (sum !== 1) {
      if (seen[n]) return false;
      seen[n] = true;
      sum = 0;
      while (n !== 0) {
          const rem = n % 10;
          n -= rem;
          n /= 10;
          sum += Math.pow(rem, 2);
      }
      
      n = sum;
  }
  
  return true;
};

/*

  Iterative - Sum the square of each digit of n, then set the n to be the current sum and repeat until reaching a number that's already been seen or a 1 is found. 

  Time Complexity: O(logn)
  Space Complexity: O(logn)

*/



/**
 * @param {number} n
 * @return {boolean}
 */
 var isHappy = function(n) {
    
  let seen = {};
  
  let recurse = function(num) {
      
      if (num === 1) return true;
      if (seen[num]) return false;
      
      let sum = 0;
      seen[num] = true;
      
      while (num !== 0) {
          const rem = num % 10;
          num -= rem;
          num /= 10;
          sum += Math.pow(rem, 2);
      }
      
      return recurse(sum);
  }
  
  return recurse(n);
};

/*

  Recursive

  Time Complexity: O(logn)
  Space Complexity: O(logn)

*/
