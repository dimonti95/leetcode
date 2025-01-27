class Solution {
    func groupAnagrams(_ strs: [String]) -> [[String]] {
        var groups = [[Int]: [String]]()
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
            result.append(val)
        }

        return result
    }
}

/*

    Time: (s * t)
    Space: O(s * t)
    
    Where s is the length of the input array and t is the average length of each string

    ---------------------------------------------------------------------------------

    There's two main ways to create the groupings:
    1. Map each sorted string to a group (the big O is O(s*tlogt))
    2. Map each count to a group (the big O is O(s*t))

*/
