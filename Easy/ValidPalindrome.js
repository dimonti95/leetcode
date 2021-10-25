/**
 * @param {string} s
 * @return {boolean}
 */
 var isPalindrome = function(s) {
    
  let right = s.length - 1;
  for (let left = 0; left < s.length; left++) {
      if (!isAlphanumeric(s.charAt(left))) continue;
      while (!isAlphanumeric(s.charAt(right))) right--;
      if (left >= right) break;
      if (s.charAt(left).toLowerCase() !== s.charAt(right).toLowerCase()) 
          return false;
      right--;
  }
  
  return true;
};

const isAlphanumeric = function (char) {
  return /[0-9a-zA-Z]/.test(char);
}

/*

  Two pointers on each end ignoring case and non-alphanumeric characters

  Time Complexity: O(n)
  Space Complexity: O(1)

*/
