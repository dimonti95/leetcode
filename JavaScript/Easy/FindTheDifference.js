/**
 * @param {string} s
 * @param {string} t
 * @return {character}
 */
 var findTheDifference = function(s, t) {
    
  let sCharMap = {};
  let tCharMap = {};

  for (let i = 0; i < t.length; i++) {
    if (s.charAt(i) && !sCharMap[s.charAt(i)]) sCharMap[s.charAt(i)] = 1;
    else if (s.charAt(i))  sCharMap[s.charAt(i)]++;
    if (!tCharMap[t.charAt(i)]) tCharMap[t.charAt(i)] = 1;
    else tCharMap[t.charAt(i)]++;
  }

  for (let c in tCharMap) {
    if (!sCharMap[c]) return c;
    if (sCharMap[c] < tCharMap[c]) return c;
  }
  
};

/*
  Map each character to the number of occurences in each string and either return the character that 
  doesn't exist in s or the character that is mapped to more occurences in t

  Time Complexity: O(n)
  Space Complexity: O(1) (s and t consist of lower-case English letters)
  
  Where n is the length of each string

*/
