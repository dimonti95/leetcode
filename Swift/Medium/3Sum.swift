class Solution {
    func threeSum(_ nums: [Int]) -> [[Int]] {
        var result: [[Int]] = []
        let nums = nums.sorted()

        for i in 0..<nums.count {
            var left = i + 1
            var right = nums.count - 1

            if i > 0 && nums[i] == nums[i - 1] { continue }

            while left < right {
                let sum = nums[i] + nums[left] + nums[right]
                if sum > 0 {
                    right -= 1
                }
                else if sum < 0 {
                    left += 1
                }
                else {
                    result.append([nums[i], nums[left], nums[right]])
                    left += 1
                    while (nums[left] == nums[left - 1] && left < right) {
                        left += 1
                    }
                }
            }
        }

        return result
    }
}

/*

    Solution:
    * Sort the input array
    * Run a two-pointer find for two numbers that make the sum 0

    Time: O(n^2)
    Space: O(n) or O(logn) depending on the sorting algorithm

    Note: Ignoring the output array for the purpose of complexity analysis

*/
