/**
 * @param {string[]} strs
 * @return {string[][]}
 */
var groupAnagrams = function(strs) {
    
  let groupMap = {};
  for (let i = 0; i < strs.length; i++) {
    let count = []; // a ... z
    for (let j = 0; j < strs[i].length; j++) {
      let c = strs[i][j];
      let index = c.charCodeAt(0) - 'a'.charCodeAt(0)
      count[index] === undefined ? count[index] = 1 : count[index] += 1;
    }
    groupMap[count] === undefined ? groupMap[count] = [ strs[i] ] : groupMap[count].push(strs[i]);
  }
  
  let ans = [];
  for (let key in groupMap)
    ans.push(groupMap[key]);
  
  return ans;
};

/*

    Time: O(n * s)
    Space: O(n)

    where n is the number of strings and s is the average length of each string

 */
