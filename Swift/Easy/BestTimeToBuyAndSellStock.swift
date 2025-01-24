class Solution {
    func maxProfit(_ prices: [Int]) -> Int {
        var result = 0
        var left = 0
        for right in 1..<prices.count {
            let profit = prices[right] - prices[left]
            if (profit < 0) {
                left = right
            }
            result = max(result, profit)
        }

        return result
    }
}

/*

    Time: O(n)
    Space: O(1)

*/
