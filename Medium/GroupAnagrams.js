/**
 * @param {string[]} strs
 * @return {string[][]}
 */
var groupAnagrams = function(strs) {
    
  let countMap = {};
  for (let str of strs) {
    let counts = new Array(26).fill(0);
    for (let c of str) {
      counts[c.charCodeAt(0) - 'a'.charCodeAt(0)] += 1;
    }
    !(counts in countMap) ? countMap[counts] = [ str ] : countMap[counts].push(str);
  }
  
  let res = [];
  for (let key in countMap)
    res.push(countMap[key]);

  return res;
};

/*

  Solution 1: 
  * Sort the strings and build a map
  * The keys are sorted strings and each sorted string maps to a list of strings with those characters
  
  Time: O(nclogc)
  Space: O(n) or O(nc)
  
  Where n is the number of strings and c is the average length of each string
  * Space is O(nc) because each n string has c characters
  * The input array is also O(nc) space
  
  ----------------------------------------------------------------------------------------------------------------

  Solution2:
  * Rather than sorting just create an 26 element array that tracks the count for each character
  * Use the count array as a key and map each key to the strings that have those counts
  
  Time: O(nc)
  Space: O(nc)
  
  Where n is the number of strings and c is the average length of each string  

*/
