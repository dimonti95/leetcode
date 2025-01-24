class Solution {
    func isAnagram(_ s: String, _ t: String) -> Bool {
        if s.count != t.count { return false } // this is an O(s + t) operation in Swift
        
        var counter = [Character: Int]()
        for i in s.indices {
            counter[s[i], default: 0] += 1
            counter[t[i], default: 0] -= 1
        }

        for (key, value) in counter {
            if counter[key] != 0 { return false }
        }

        return true
    }
}

/*

    Time: O(s + t) - because accessing count is an O(n) time operation
    Space: O(1)

    Where s is the length of s and t is the length of t

*/
