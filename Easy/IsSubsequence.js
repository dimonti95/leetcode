/**
 * @param {string} s
 * @param {string} t
 * @return {boolean}
 */
 var isSubsequence = function(s, t) {
    
  let tIndex = 0;
  for (let sIndex = 0; sIndex < s.length; sIndex++) {
      while (tIndex < t.length && s[sIndex] !== t[tIndex]) tIndex++;
      tIndex++; // skip past current to avoid checking against the same character twice
      if (tIndex > t.length) return false;
  }
  
  return true;
};

/* 

  Explanation:
  
  Two pointers: One at the start of s and one at the start of t

  Time Complexity: O(n + m)
  Space Complexity: O(1)
  where n is the length of s and m is the length of t
  
*/
