/**
 * @param {string} s
 * @param {string} t
 * @return {string}
 */
var minWindow = function(s, t) {
  
  if (s.length === 0 || t.length === 0)
    return "";
  
  let tMap = {};
  for (let i = 0; i < t.length; i++) {
    let c = t.charAt(i);
    tMap[c] === undefined ? tMap[c] = 1 : tMap[c] += 1;
  }
  
  let required = Object.keys(tMap).length;
  let left = 0;
  let right = 0;
  let formed = 0;
  let windowCounts = {};
  let ans = [-1, 0, 0]; // [window length, left, right]
  
  while (right < s.length) {
    let c = s.charAt(right);
    windowCounts[c] === undefined ? windowCounts[c] = 1 : windowCounts[c] += 1;
    
    if (tMap[c] && windowCounts[c] === tMap[c])
      formed++;
    
    while (left <= right && formed === required) {
      let c = s.charAt(left);
      
      if (ans[0] === -1 || right - left + 1 < ans[0]) {
        ans[0] = right - left + 1;
        ans[1] = left;
        ans[2] = right;
      }
      
      windowCounts[c] -= 1;
      if (tMap[c] && windowCounts[c] < tMap[c])
        formed--;
      
      left += 1;
    }
    
    right += 1;
  }
  
  return ans[0] == -1 ? "" : s.substring(ans[1], ans[2] + 1);
}

/*

    Time: O(s + t)
    Space: O(1) since the total number of unique characters never exceeds 52 (26 uppercase & 26 lowercase)

    Optimization:
    required = the number of unique characters in t
    formed = the number of unique characters in the current window at the target frequency

*/



/**
 * @param {string} s
 * @param {string} t
 * @return {string}
 */
var minWindow = function(s, t) {
  
  if (s.length === 0 || t.length === 0)
    return "";
  
  let tCount = {};
  for (let i = 0; i < t.length; i++) {
    let c = t.charAt(i);
    tCount[c] === undefined ? tCount[c] = 1 : tCount[c] += 1;
  }
  
  let left = 0;
  let right = 0;
  let windowCount = {};
  let ans = [-1, 0, 0]; // [window length, left, right]
  
  while (right < s.length) {
    let c = s.charAt(right);
    windowCount[c] === undefined ? windowCount[c] = 1 : windowCount[c] += 1;
    
    // try to contract the window
    
    while (left <= right && validWindow(windowCount, tCount)) {
      let c = s.charAt(left);
      
      if (ans[0] === -1 || right - left + 1 < ans[0]) {
        ans[0] = right - left + 1;
        ans[1] = left;
        ans[2] = right;
      }
      
      windowCount[c] -= 1;
      left += 1;
    }
    
    right += 1;
  }
  
  return ans[0] == -1 ? "" : s.substring(ans[1], ans[2] + 1);
}

let validWindow = function(windowCount, tCount) {
  for (let c in tCount) {
    if (windowCount[c] === undefined || windowCount[c] < tCount[c])
      return false;
  }
  return true;
}

/*

    Time: O(s*52 + t)
    Space: O(1) since the total number of unique characters never exceeds 52 (26 uppercase & 26 lowercase)

    Unoptimized since theres a check for a valid window every iteration

*/
