/**
 * @param {number[]} nums
 * @return {number}
 */
 var longestConsecutive = function(nums) {
    
    let set = new Set(nums);
    let max = 0;
    for (let num of nums) {
        if (!set.has(num - 1)) {
            let current = num;
            let length = 0;
            while (set.has(current)) {
                length++;
                current++;
            }
            max = Math.max(max, length);
        }
    }
    
    return max;
};

/*

    Use a set to check for the start of each sequence
    
    Time: O(n)
    Space: O(n)

*/
