/**
 * @param {string} s
 * @return {number}
 */
 var lengthOfLongestSubstring = function(s) {
    
  let seen = new Set();
  let max = 0;
  let j = 0;

  for (let i = 0; i < s.length; i++) {
    while (seen.has(s.charAt(i))) {
          seen.delete(s.charAt(j));
          j++;
      }
      seen.add(s.charAt(i));
      max = Math.max(max, i - j + 1);
  }

  return max;    
};

/*

  Sliding window algorithm with two pointers
  
  Time Complexity: O(n)
  Space Complexity: O(n)
  
  Where n is the length of the string

*/
