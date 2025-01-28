class Solution {
    func lengthOfLIS(_ nums: [Int]) -> Int {
        var memo = Array<Int>(repeating: -1, count: nums.count)

        func dp(_ index: Int, _ sequence: [Int]) -> Int {
            if (index == nums.count) { return 0 }
            if (memo[index] != -1) { return memo[index] }

            var sequence = sequence
            var currentMax = 0
            for i in index..<nums.count {
                if sequence.count == 0 || nums[i] > sequence[sequence.count - 1] {
                    sequence.append(nums[i])
                    currentMax = max(currentMax, 1 + dp(i + 1, sequence))
                    sequence.removeLast()
                }
            }

            memo[index] = currentMax
            return memo[index]
        }

        return dp(0, [Int]())
    }
}

/*

    

*/
