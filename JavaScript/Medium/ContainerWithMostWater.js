/**
 * @param {number[]} height
 * @return {number}
 */
 var maxArea = function(height) {
    
    let left = 0;
    let right = height.length - 1;
    let max = 0;
    
    while (left < right) {
        let y = Math.min(height[left], height[right]);
        let x = right - left;
        max = Math.max(max, x*y);
        
        if (height[left] < height[right]) {
            left += 1;
        }
        else {
            right -= 1;
        }
    }
    
    return max;
};

/*

    Two pointers, move the pointer at the smaller value
    
    Time Complexity: O(n)
    Space Complexity: O(1)

*/
