class Solution {
    func isPalindrome(_ s: String) -> Bool {
        let s = Array(s.lowercased().filter { $0.isLetter || $0.isNumber })
        var left = 0
        var right = s.count - 1
        while left < right {
            if s[left] != s[right] { return false }

            left += 1
            right -= 1
        }

        return true;
    }
}

/*

    Time: O(n)
    Space: O(n)

*/
