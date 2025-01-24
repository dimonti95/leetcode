class Solution {
    func twoSum(_ nums: [Int], _ target: Int) -> [Int] {
        var map: [Int:Int] = [:]
        for i in 0..<nums.count
        {
            let diff = target - nums[i]
            if let value = map[diff] {
                return [i, value]
            }
            map[nums[i]] = i;
        }

        return []
    }
}

/*

    Time: O(n)
    Space: O(n)

*/
