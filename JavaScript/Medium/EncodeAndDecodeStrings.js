/**
 * Encodes a list of strings to a single string.
 *
 * @param {string[]} strs
 * @return {string}
 */
var encode = function(strs) {
    
  let res = "";
  for (const str of strs) {
    res += String.fromCharCode(str.length);
    res += str;
  }
  
  return res;
};

/**
 * Decodes a single string to a list of strings.
 *
 * @param {string} s
 * @return {string[]}
 */
var decode = function(s) {
  
  let res = [];
  for (let i = 0; i < s.length; i++) {
    let len = s.charAt(i).charCodeAt(0);
    let str = "";
    while (len > 0) {
      i++;
      str += s.charAt(i);
      len--;
    }
    res.push(str);
  }
  
  return res;
};

/**
 * Your functions will be called as such:
 * decode(encode(strs));
 */

/*

  Approach 1:
  * Use a delimiter that isn't an ASCII character
  * For example String.fromCharCode(257)

  Approach 2:
  * Put a number before each string seperated by a delimeter
  * This is more flexible since it doesn't depend on the set of input characters

  Approach 3:
  * Based on encoding used in HTTP v1.1
  * Allocate a byte before each string that represents the length of that string
  * Uses less space than the above solutions since only 2 bytes get allocated for each string
  * ["Hello", "World"] => 0x05Hello0x05World

  Time: O(n)
  Space: O(1)
  
*/
