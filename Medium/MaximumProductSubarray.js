/**
 * @param {number[]} nums
 * @return {number}
 */
 var maxProduct = function(nums) {
    
    let max = 1;
    let min = 1;
    let maxProduct = Math.max(...nums);
    for (let i = 0; i < nums.length; i++) {
        if (nums[i] === 0) {
            max = 1;
            min = 1;
            continue;
        }
        let temp = max;
        max = Math.max(nums[i] * max, nums[i] * min, nums[i]);
        min = Math.min(nums[i] * temp, nums[i] * min, nums[i]);
        maxProduct = Math.max(maxProduct, max);
    }
    
    return maxProduct;
};

/*

    Track current max and min products at each index (to deal with negatives)
    
    Time Complexity: O(n)
    Space Complexity: O(1)
    
    Where n is the length of nums

*/