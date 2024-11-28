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
    max = Math.max(max, map[key]);
  }
  return max;
}

/*

  Two pointers, sliding window, track (count of most frequent character - size of window)

  Time Complexity: O(n)
  Space Complexity: O(1) (at most 26 characters get mapped)

  Where n is the length of the string

*/



/**
 * @param {string} s
 * @param {number} k
 * @return {number}
 */
var characterReplacement = function(s, k) {
    
  let map = {};
  let max = 0;
  let left = 0;
  let maxFreq = 0;

  for (let right = 0; right < s.length; right++) {
    map[s.charAt(right)] ? map[s.charAt(right)]++ : map[s.charAt(right)] = 1;
    maxFreq = Math.max(maxFreq, map[s.charAt(right)]);
    let count = (right - left + 1) - maxFreq;
    while (count > k) {
      map[s.charAt(left)]--;
      left++;
      count = (right - left + 1) - maxFreq;
    }
    max = Math.max(max, right - left + 1);
  }
  
  return max; 
  
};

/*

  Optimized from O(n*26)
  * When the left pointer gets moved forward the maxFreq doesn't get updated
  * But checking against the wrong maxFreq doesn't change the max
  * The max only updates when a new maxFreq is found

  Time: O(n)
  Space: O(1)

*/
