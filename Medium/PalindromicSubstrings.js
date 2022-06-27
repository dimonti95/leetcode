/**
 * @param {string} s
 * @return {number}
 */
var countSubstrings = function(s) {
    
  let count = 0;
  
  for (let i = 0; i < s.length; i++) {
    count += expandFromCenter(s, i, i);
    count += expandFromCenter(s, i, i + 1);
  }
  
  return count;
};

let expandFromCenter = function(s, left, right) {
  let count = 0;
  while (left >= 0 && right < s.length && s.charAt(left) === s.charAt(right)) { 
    left -= 1;
    right += 1;
    count += 1;
  }
  return count;
}

/*

    Expand from the center of each index, the center could be between two letters.

    Time: O(n^2)
    Space: O(1)

*/
