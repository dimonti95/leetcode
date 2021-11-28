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
