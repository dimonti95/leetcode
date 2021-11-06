/**
 * @param {number[]} nums
 * @return {number[][]}
 */
 var threeSum = function(nums) {
    
    let ans = [];
    nums.sort((a, b) => a - b);
    
    for (let i = 0; i < nums.length; i++) {
        if (i > 0 && nums[i] === nums[i - 1]) continue;
        let left = i + 1;
        let right = nums.length - 1;
        while (left < right) {
            let threeSum = nums[i] + nums[left] + nums[right];
            if (threeSum > 0) {
                right -= 1;
            }
            else if (threeSum < 0) {
                left += 1;
            }
            else {
                ans.push([nums[i], nums[left], nums[right]]);
                left += 1;
                while (nums[left] === nums[left - 1] && left < right) {
                    left += 1;
                }
            }
        }
    }
    
    return ans;
};

/*

    (1) Sort nums
    (2) Loop the array from start to finish with the first pointer
    (3) Implement Two Sum II algorithm on the sorted array to find triplets that sum to 0
    
    Time Complexity: O(n^2)
    Space Complexity: O(1) or O(n) (Depends on sorting implementation)
    
    Where n is the length of nums

*/
