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
        while let l1 = list1, let l2 = list2 {
            if l1.val < l2.val {
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
        if (list1 == nil && list2 == nil) { return nil }
        if (list1 == nil && list2 != nil) { return list2 }
        if (list1 != nil && list2 == nil) { return list1 }
        
        if (list1!.val < list2!.val) {
            list1!.next = mergeTwoLists(list1!.next, list2)
            return list1
        }
        else {
            list2!.next = mergeTwoLists(list1, list2!.next)
            return list2
        }
    }
}

/*

    Recursive

    Time: O(n)
    Space: O(n)

*/