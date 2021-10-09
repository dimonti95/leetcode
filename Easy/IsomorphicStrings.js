/**
 * @param {string} s
 * @param {string} t
 * @return {boolean}
 */
 var isIsomorphic = function(s, t) {
    
  let sMap = {};
  let tMap = {};
  let charCount = s.length > t.length ? s.length : t.length;
  
  let sUniqueCount = 1;
  let tUniqueCount = 1;
  let sMapped = ''
  let tMapped = ''
  for (let i = 0; i < charCount; i++) {
      if (!sMap[s.charAt(i)]) sMap[s.charAt(i)] = sUniqueCount++;
      if (!tMap[t.charAt(i)]) tMap[t.charAt(i)] = tUniqueCount++;
      sMapped += sMap[s.charAt(i)].toString()
      tMapped += tMap[t.charAt(i)].toString()
  }
  
  if (sMapped === tMapped) return true;
  
  return false
};

/*

  Map every letter to a integer with the first unique character mapped to 1, the second mapped to 2..
  
  Time Complexity: O(n)
  Space Complexity: O(n)
  
  Where n is the total number of characters
  

*/
