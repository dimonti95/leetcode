/**
 * @param {string} s
 * @return {boolean}
 */
 var isPalindrome = function(s) {
    
  let left = 0;
  let right = s.length - 1;
  
  while(left < right) {
      
      while(left < right && !isAlphanumeric(s.charAt(left)))
          left++;
      while(left < right && !isAlphanumeric(s.charAt(right)))
          right--;
      
      if (s.charAt(left).toLowerCase() !== s.charAt(right).toLowerCase())
          return false;
      
      left++;
      right--;
  }
  
  return true;
};

/*

  Two pointers on each end ignoring case and non-alphanumerics

  Time Complexity: O(n)
  Space Complexity: O(1)

*/
