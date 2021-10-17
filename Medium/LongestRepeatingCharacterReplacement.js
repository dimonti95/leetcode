/**
 * @param {string} s
 * @param {number} k
 * @return {number}
 */
 var characterReplacement = function(s, k) {
    
  let map = {};
  let max = 0; 
  let left = 0;

  for (let right = 0; right < s.length; right++) {
    map[s.charAt(right)] ? map[s.charAt(right)]++ : map[s.charAt(right)] = 1;
    let count = (right - left + 1) - getCountOfMostFrequentChar(map);
      while (count > k) {
          map[s.charAt(left)]--;
          left++;
          count = (right - left + 1) - getCountOfMostFrequentChar(map);
      }
      max = Math.max(max, right - left + 1);
  }
  
  return max; 
  
};

let getCountOfMostFrequentChar = function (map) {
  let max = 0;
  for (let key in map) {
      if (map[key] > max) max = map[key];
  }
  return max;
}

/*

  Two pointers, sliding window, track (count of most frequent character - size of window)

  Time Complexity: O(n)
  Space Complexity: O(1) (at most 26 characters will be mapped)

  Where n is the length of the string

*/
