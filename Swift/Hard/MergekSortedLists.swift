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
    func mergeKLists(_ lists: [ListNode?]) -> ListNode? {
        if lists.isEmpty { return nil }
        
        var lists = lists
        var interval = 1
        while interval < lists.count {
            for i in stride(from: 0, to: lists.count, by: interval * 2) {
                let list1 = lists[i]
                let list2 = i + interval < lists.count ? lists[i + interval] : nil
                lists[i] = mergeLists(list1, list2)
            }
            interval *= 2
        }

        return lists[0]
    }

    func mergeLists(_ list1: ListNode?, _ list2: ListNode?) -> ListNode? {
        if (list1 == nil && list2 == nil) { return nil }
        if (list1 != nil && list2 == nil) { return list1 }
        if (list1 == nil && list2 != nil) { return list2 }

        var list1 = list1
        var list2 = list2
        if let l1 = list1, let l2 = list2 {
            if l1.val < l2.val {
                list1?.next = mergeLists(list1?.next, list2)
                return list1
            }
            else {
                list2?.next = mergeLists(list1, list2?.next)
                return list2
            }
        }

        return nil
    }
}

/*

    Merge lists two at a time (in-place)

    Time: O(nlogk)
    Time: O(1)

*/
