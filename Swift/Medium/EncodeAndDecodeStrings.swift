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
        var i = s.startIndex
        let count = s.endIndex
        while i < count {
            if let j = s[i...].firstIndex(of: "#") {
                let len = Int(s[i..<j])!
                let j = s.index(j, offsetBy: 1)
                let endIndex = s.index(j, offsetBy: len)
                result.append(String(s[j..<endIndex]))
                i = s.index(j, offsetBy: len)
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

*/
