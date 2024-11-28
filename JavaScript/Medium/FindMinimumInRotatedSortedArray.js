/**
 * @param {number[]} nums
 * @return {number}
 */
 var findMin = function(nums) {
    
    let ans = nums[0];
    let left = 0;
    let right = nums.length - 1;
    
    while (left <= right) {
        if (nums[left] < nums[right]) {
            ans = Math.min(ans, nums[left]);
            break;
        }
        
        let middle = Math.floor((left + right) / 2);
        ans = Math.min(ans, nums[middle]);
        if (nums[middle] >= nums[left]) {
            left = middle + 1;
        }
        else {
            right = middle - 1;
        }
    }
    
    return ans;
};

/*

    Binary search
    
    Time Complexity: O(logn)
    Space Complexity: O(1)

*/
