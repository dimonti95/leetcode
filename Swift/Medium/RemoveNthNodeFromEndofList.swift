/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public var val: Int
 *     public var next: ListNode?
 *     public init() { self.val = 0; self.next = nil; }
 *     public init(_ val: Int) { self.val = val; self.next = nil; }
 *     public init(_ val: Int, _ next: ListNode?) { self.val = val; self.next = next; }
 * }
 */
class Solution {
    func removeNthFromEnd(_ head: ListNode?, _ n: Int) -> ListNode? {
        var n = n
        var temp: ListNode? = ListNode(0, head)
        var current = temp
        while current != nil && n > 0 {
            current = current?.next
            n -= 1
        }

        var previous = temp
        while current != nil && current?.next != nil {
            current = current?.next
            previous = previous?.next
        }

        previous?.next = previous?.next?.next
        return temp?.next
    }
}

/*

    Solution
    * Iterate throught the list with two pointers that are n nodes apart
    * Remove the node from the left pointer once the right node reaches the end of the list

    Time: O(n)
    Space: O(1)

    Where n is the number of nodes in the list

*/
