class Solution {
    func getSum(_ a: Int, _ b: Int) -> Int {
        if (b == 0) { return a }
        return getSum(a ^ b, (a & b) << 1)
    }
}

/*

    Recursive

    Time: O(1)
    Space: O(1)

    Constant time and space because the Int type is either a 32-bit integer or 64-bit integer

*/
