/**
 * @param {number[]} nums
 * @return {number}
 */
 var maxProduct = function(nums) {
    
    let currMax = 1;
    let currMin = 1;
    let maxProduct = Math.max(...nums);
    
    for (let i = 0; i < nums.length; i++) {
        let temp = currMax;
        currMax = Math.max(nums[i], currMax * nums[i], currMin * nums[i]);
        currMin = Math.min(nums[i], temp * nums[i], currMin * nums[i]);
        maxProduct = Math.max(maxProduct, currMax);
    }

    return maxProduct;
};

/*

    Track current max and min products at each index (to deal with negatives)


    Example: [2,3,-2,4]
    0: [2, 2]
    1: [2, 6]
    2: [-12, -2]
    3: [-48, 4]

    i: [currMin, currMax]
    

    Time Complexity: O(n)
    Space Complexity: O(1)
    
    Where n is the length of nums

*/