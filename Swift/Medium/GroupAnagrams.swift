class Solution {
    func groupAnagrams(_ strs: [String]) -> [[String]] {
        var groups = [Array<Int>: [String]]()
        var result = [[String]]()

        for str in strs {
            var count = Array(repeating: 0, count: 26) // Creates an array [0, 0, 0, 0, 0, ...]
            for char in str {
                let index = Int(char.asciiValue! - Character("a").asciiValue!)
                count[index] += 1
            }

            groups[count, default: [String]()].append(str)
        }

        for (key, val) in groups {
            if let value = groups[key] {
                result.append(value)   
            }
        }

        return result
    }
}

/*

    Time: (s * t)
    Space: O(s * t)
    
    Where s is the length of the input array and t is the average length of each string

*/
