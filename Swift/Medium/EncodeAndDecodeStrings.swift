class Codec {
    func encode(_ strs: [String]) -> String {
        var result = ""
        for str in strs {
            let len = String(str.count)
            result.append(len + "#")
            for char in str {
                result.append(char)
            }
        }

        return result
    }

    // Notes:
    // s.startIndex is an O(1) operation
    // s.endIndex is an O(1) operation
    // Range operations like s[currentIndex...] are an O(1) operation
    func decode(_ s: String) -> [String] {
        var result = [String]()
        var currentIndex = s.startIndex
        while currentIndex < s.endIndex {
            guard let hashIndex = s[currentIndex...].firstIndex(of: "#") else { // O(k) - where k is the length of the substring
                break // No more data to decode
            }
        
            // Extract the length of the next string
            // O(k) - where k is the length of the substring
            let length = Int(s[currentIndex..<hashIndex])!
        
            // Move to the start of the actual string
            let stringStartIndex = s.index(after: hashIndex) // O(k) - where k is the length of the offset
            let stringEndIndex = s.index(stringStartIndex, offsetBy: length) // O(k) - where k is the length of the substring
        
            // Append the decoded string
             // O(k) - where k is the length of the substring
            result.append(String(s[stringStartIndex..<stringEndIndex]))
        
            // Move the current index to the next segment
            currentIndex = stringEndIndex
        }

        return result
    }
}

/*

    encode
    Time: O(n)
    Space: O(n)


    Where n is the total number of characters across all strings

    --------------------------------------------------------------------------------

    Runtime analysis:

    Using startIndex and endIndex - from the Swift docs on Collection protocol:
    * "Types that conform to Collection are expected to provide the startIndex and endIndex properties and subscript access to elements as O(1) operations."
    * "Types that are not able to guarantee this performance must document the departure, because many collection operations depend on O(1) subscripting performance for their own performance guarantees."

    In Swift, String conforms to the Collection protocol.

    Using substring and firstIndex
    * s[i...] is an O(1) operation because the substring is not copied
    * .firstIndex(of: "#") is an O(k) operation where k is the size of the substring (s.count - i), this will be O(n) in the worst case
    * This is because the string needs to be iterated over to find the index of "#"

    Using .index() - from the Swift docs on the Collection protocol:
    * "O(1) if the collection conforms to RandomAccessCollection; otherwise, O(k), where k is the absolute value of the offset."
    * "RandomAccessCollection is a Swift protocol that indicates the collection supports efficient random-access index traversal"
    
    Note: The String type does not currently conform to RandomAccessCollection, but Array does.

*/
