class Solution {
    func countSubstrings(_ s: String) -> Int {
        let s = Array(s)
        var result = 0
        for i in 0..<s.count {
            result += countPalindromes(s, i, i)
            result += countPalindromes(s, i, i + 1)
        } 

        return result
    }

    private func countPalindromes(_ s: [Character], _ left: Int, _ right: Int) -> Int {
        var count = 0
        var l = left // because function arguments are immutable by default in Swift
        var r = right // because function arguments are immutable by default in Swift
        while l >= 0 && r < s.count && s[l] == s[r] {
            l -= 1
            r += 1
            count += 1
        }

        return count
    }
}

/*

    Brute force
    Time: O(n)
    Space: O(n) - because the string needs to be converted to an array

*/