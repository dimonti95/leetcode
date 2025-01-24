class Solution {
    func isValid(_ s: String) -> Bool {
        var stack = [Character]()
        for char in s {
            if char == "(" || char == "[" || char == "{" {
                stack.append(char);
            }
            else {
                if stack.isEmpty { return false }
                let last = stack.removeLast()
                if (char == ")" && last != "(") || 
                    (char == "]" && last != "[") || 
                    (char == "}" && last != "{") { 
                    return false
                }
            }
        }

        return stack.isEmpty
    }
}

/*

    Time: O(n)
    Space: O(n)

    Where n is the length of the input string

*/



class Solution2 {
    func isValid(_ s: String) -> Bool {
        var map = [Character: Character]()
        var stack = [Character]()
        map["("] = ")"
        map["["] = "]"
        map["{"] = "}"

        for char in s {
            if let temp = map[char] {
                stack.append(temp)
                continue
            }

            if stack.isEmpty { return false }
            let last = stack.removeLast()
            if last != char { return false }
        }

        return stack.isEmpty
    }
}

/*

    Time: O(n)
    Space: O(n)

    Same solution as the first but the mappings are stored in a dictionary

*/
