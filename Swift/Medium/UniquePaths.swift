class Solution {
    func uniquePaths(_ m: Int, _ n: Int) -> Int {
        var memo = Array(repeating: Array(repeating: -1, count: n + 1), count: m + 1)
        func dp(_ m: Int, _ n: Int) -> Int {
            if (m == 1 && n == 1) { return 1 }
            if (m == 0 || n == 0) { return 0 }
            if (memo[m][n] != -1) { return memo[m][n] }

            memo[m][n] = dp(m - 1, n) + dp(m, n - 1)
            return memo[m][n]
        }

        return dp(m, n)
    }
}

/*

    Top-down DP

    Time: O(m * n)
    Space: O(m * n)

*/
