class Solution {
    func maxArea(_ height: [Int]) -> Int {
        var left = 0
        var right = height.count - 1
        var result = 0
        while left < right {
            let length = min(height[left], height[right])
            let width = right - left
            result = max(result, length * width)
            if height[left] < height[right] {
                left += 1
            }
            else {
                right -= 1
            }
        }

        return result
    }
}

/*

    Time: O(n)
    Space: O(1)

*/
