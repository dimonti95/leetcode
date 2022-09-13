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
  Space Complexity: O(min(m,n))
  
  Where n is the length of the string

  The size of the Set is upper bounded by the size of the string (n) and the number of unique characters.

*/



/**
 * @param {string} s
 * @return {number}
 */
var lengthOfLongestSubstring = function(s) {
  
  let indexMap = {};
  let max = 0;
  let left = 0;
  for (let right = 0; right < s.length; right++) {
    let c = s.charAt(right);
    if (s.charAt(right) in indexMap) {
      left = Math.max(indexMap[s.charAt(right)] + 1, left);
    }
    indexMap[s.charAt(right)] = right;
    max = Math.max(max, right - left + 1);
  }
  
  return max;
};


/*

  Optimized Sliding window

  Time: O(n)
  Space: O(min(m,n))
  
  The size of the Map is upper bounded by the size of the string (n) and the number of unique characters.

*/
