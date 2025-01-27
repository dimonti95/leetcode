class Solution {
    func minWindow(_ s: String, _ t: String) -> String {
        // Count the frequency of characters in t
        var tCount = [Character: Int]()
        for char in t {
            tCount[char, default: 0] += 1
        }
        
        var sCount = [Character: Int]() // Frequency count of characters in current window
        var expected = tCount.keys.count // Number of unique characters in t
        var formed = 0 // Number of characters meeting the required count in the window
        
        var left = s.startIndex
        var leftInt = 0
        var right = s.startIndex
        var rightInt = 0
        
        var minLength = Int.max
        var startIndex = s.startIndex
        
        while right < s.endIndex {
            let rightChar = s[right]
            sCount[rightChar, default: 0] += 1
            
            // Check if this character satisfies the required frequency
            if let count = tCount[rightChar], sCount[rightChar] == count {
                formed += 1
            }
            
            // Try shrinking the window if all characters are satisfied
            while formed == expected {
                let windowLength = rightInt - leftInt + 1
                if windowLength < minLength {
                    minLength = windowLength
                    startIndex = left
                }
                
                let leftChar = s[left]
                sCount[leftChar, default: 0] -= 1
                
                // Check if shrinking the window breaks the condition
                if let count = tCount[leftChar], sCount[leftChar]! < count {
                    formed -= 1
                }
                
                left = s.index(after: left) // Move the left pointer
                leftInt += 1
            }
            
            right = s.index(after: right) // Move the right pointer
            rightInt += 1
        }
        
        return minLength == Int.max ? "" : String(s[startIndex..<s.index(startIndex, offsetBy: minLength)])
    }
}

/*

    Sliding window

    Time: O(s + t)
    Space: O(52) = O(1)

    --------------------------------------------------------------------------------------------

    Notes:
    * It's not possible to get the distance between two String.Index values in O(1) time
    * This is the reason for tracking the int of the index separate from the String.Index
    * Another option would be to convert s into a [String], but this would cost O(s) space
    * There is a s.distance(from: left, to: right) method, but it runs in O(n) time

*/
