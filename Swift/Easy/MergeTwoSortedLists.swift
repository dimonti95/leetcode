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
    func mergeTwoLists(_ list1: ListNode?, _ list2: ListNode?) -> ListNode? {
        let pointer: ListNode? = ListNode()
        var current = pointer
        var list1 = list1
        var list2 = list2
        while list1 != nil && list2 != nil {
            if list1!.val < list2!.val {
                current?.next = list1
                list1 = list1?.next
            }
            else {
                current?.next = list2
                list2 = list2?.next
            }

            current = current?.next
        }

        current?.next = list1 ?? list2
        return pointer?.next
    }
}

/*

    Iterative

    Time: O(n + m)
    Space: O(1)

    Where n is the number of nodes in list1 and m is the number of nodes in list2

*/
