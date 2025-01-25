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
    
    func decode(_ s: String) -> [String] {
        var result = [String]()
        var i = s.startIndex // O(1)
        let count = s.endIndex // O(1)
        while i < count {
            if let j = s[i...].firstIndex(of: "#") { // O(k) - where k is the length of the substring
                let len = Int(s[i..<j])! // O(k) - where k is the length of the substring
                let j = s.index(j, offsetBy: 1) // O(1) - since the offset is 1
                let endIndex = s.index(j, offsetBy: len) // O(k) - where k is the length of the offset
                result.append(String(s[j..<endIndex])) // O(k) - where k is the length of the substring
                i = s.index(j, offsetBy: len) // O(k) - where k is the length of the offset
            }
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

    Using startIndex and endIndex
    * "Types that conform to Collection are expected to provide the startIndex and endIndex properties and subscript access to elements as O(1) operations."
    * "Types that are not able to guarantee this performance must document the departure, because many collection operations depend on O(1) subscripting performance for their own performance guarantees."

    In Swift, String conforms to the collection protocol.

    Using substring and firstIndex
    * s[i...] is an O(1) operation because the substring is not copied
    * .firstIndex(of: "#") is an O(k) operation where k is the size of the substring (s.count - i), this will be O(n) in the worst case
    * This is because the string needs to be iterated over to find the index of "#"

*/
