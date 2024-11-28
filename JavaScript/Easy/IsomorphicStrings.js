/**
 * @param {string} s
 * @param {string} t
 * @return {boolean}
 */
 var isIsomorphic = function(s, t) {
    
  let sMap = {};
  let tMap = {};
  
  let charCount = s.length > t.length ? s.length : t.length;
  
  for (let i = 0; i < charCount; i++) {
      if(!sMap[s.charAt(i)]) sMap[s.charAt(i)] = t.charAt(i);
      if(!tMap[t.charAt(i)]) tMap[t.charAt(i)] = s.charAt(i);
      if (sMap[s.charAt(i)] !== t.charAt(i) || tMap[t.charAt(i)] !== s.charAt(i)) {
          return false;
      }
  }
  
  return true;
};

/*

  Two-way map the characters of each string and return false if the mappings don't match
  
  Time Complexity: O(n)
  Space Complexity: O(1) (s and t consist of any valid ascii character)
  
  Where n is the total number of characters
  
*/
