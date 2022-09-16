/**
 * @param {string} s
 * @return {string}
 */
 var longestPalindrome = function(s) {
    
    if (!s || s.length < 1) return "";
    let start = 0;
    let end = 0;
    for (let i = 0; i < s.length; i++) {
        let len1 = expandFromCenter(s, i, i);
        let len2 = expandFromCenter(s, i, i + 1);
        let len = Math.max(len1, len2);
        let currentMax = end - start;
        if (len > currentMax) {
            start = Math.ceil(i - (len - 1) / 2);
            end = i + len / 2;
        }
    }

    return s.substring(start, end + 1);
};

let expandFromCenter = function(s, left, right) {
    while (left >= 0 && right < s.length && s.charAt(left) === s.charAt(right)) {
        left -= 1;
        right += 1;
    }
    return right - left - 1;
}

/*
    
    Expand from the center of each index, the center could be between two letters.
    
    Time: O(n^2)
    Space: O(1)

*/



/**
 * @param {string} s
 * @return {string}
 */
var longestPalindrome = function(s) {

  let max = 0;
  let res = "";
  for (let i = 0; i < s.length; i++) {
    let pal1 = expandFromCenter(i, i, s);
    let pal2 = expandFromCenter(i, i + 1, s);
    let currentMax = Math.max(pal1.length, pal2.length);
    if (currentMax > max) {
      max = currentMax;
      res = pal1.length > pal2.length ? pal1 : pal2;
    }
  }
  
  return res;
};

let expandFromCenter = function(left, right, s) {
  while (left >= 0 && right < s.length && s.charAt(left) === s.charAt(right)) {
    left--;
    right++;
  }
  return s.slice(left + 1, right);
}
