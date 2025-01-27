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



class Solution {
    func uniquePaths(_ m: Int, _ n: Int) -> Int {
        var table = Array(repeating: Array(repeating: 0, count: n + 1), count: m + 1)

        for r in 0..<m {
            for c in 0..<n {
                if r == 0 || c == 0 {
                    table[r][c] = 1
                }
                else {
                    table[r][c] = table[r - 1][c] + table[r][c - 1]
                }
            }
        }

        return table[m - 1][n - 1]
    }
}

/*

    Bottom-up DP

    Time: O(m * n)
    Space: O(m * n)

*/
