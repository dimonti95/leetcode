class Solution {
    func lengthOfLIS(_ nums: [Int]) -> Int {
        var memo = Array<Int>(repeating: -1, count: nums.count)

        func dp(_ index: Int, _ sequence: inout [Int]) -> Int {
            if (index == nums.count) { return 0 }
            if (memo[index] != -1) { return memo[index] }

            var currentMax = 0
            for i in index..<nums.count {
                if sequence.count == 0 || nums[i] > sequence[sequence.count - 1] {
                    sequence.append(nums[i])
                    currentMax = max(currentMax, 1 + dp(i + 1, &sequence))
                    sequence.removeLast()
                }
            }

            memo[index] = currentMax
            return memo[index]
        }

        var sequence = [Int]()
        return dp(0, &sequence)
    }
}

/*

    Top-down DP

    Time: O(n^2)
    Space: O(n)

    Note: Using inout keyword so that the array is passed by reference, this avoid creating copies of the array

*/



class Solution {
    func lengthOfLIS(_ nums: [Int]) -> Int {
        var dp = Array<Int>(repeating: 1, count: nums.count)

        for i in 1..<nums.count {
            for j in 0..<i {
                if nums[i] > nums[j] {
                    dp[i] = max(dp[i], dp[j] + 1)
                }
            }
        }

        var longest = 0
        for val in dp {
            longest = max(longest, val)
        }

        return longest
    }
}

/*

    Bottom-up DP

    Time: O(n^2)
    Space: O(n)

*/
