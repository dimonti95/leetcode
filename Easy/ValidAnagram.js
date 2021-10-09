/**
 * @param {string} s
 * @param {string} t
 * @return {boolean}
 */
 var isAnagram = function(s, t) {
    
  let map = {};
  let charCount = s.length > t.length ? s.length : t.length;

  for (let i = 0; i < charCount; i++) {
      if (s.charAt(i)) map[s.charAt(i)] ? map[s.charAt(i)]++ : map[s.charAt(i)] = 1;
      if (t.charAt(i)) map[t.charAt(i)] ? map[t.charAt(i)]-- : map[t.charAt(i)] = -1;
  }
  
  for (let count in map) {
      if (map[count] !== 0) return false
  }
  
  return true;
};

/*

  Map each character to the difference of the number occurences of each character in each string
  
  Time Complexity: O(n)
  Space Complexity: O(1)

*/
