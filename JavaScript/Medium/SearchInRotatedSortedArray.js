/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number}
 */
 var search = function(nums, target) {
    
    let left = 0;
    let right = nums.length - 1;
    
    while (left <= right) {
        
        let middle = Math.floor((left + right) / 2);
        if (nums[middle] === target) return middle;
        
        if (nums[middle] >= nums[left]) {
            if (target > nums[middle] || target < nums[left]) {
                left = middle + 1;
            }
            else {
                right = middle - 1;
            }
        }
        else {
            if (target < nums[middle] || target > nums[right]) {
                right = middle - 1;
            }
            else {
                left = middle + 1;
            }
        }
           
    }
    
    return -1;
};

/*

    Binary Search with left and right pointers
    (1) Figure out which part of the sorted array the middle is in
    (2) Check if target is in that range

    Time Complexity: O(n)
    Space Complexity: O(1)

*/
