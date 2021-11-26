/**
 * Definition for singly-linked list.
 * function ListNode(val, next) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.next = (next===undefined ? null : next)
 * }
 */
/**
 * @param {ListNode[]} lists
 * @return {ListNode}
 */
 var mergeKLists = function(lists) {
    
    if (lists.length === 0) return null;
    
    while (lists.length > 1) {
        let mergedLists = [];
        
        for (let i = 0; i < lists.length; i += 2) {
            let l1 = lists[i];
            let l2 = i + 1 < lists.length ? lists[i + 1] : null;
            let merged = mergeLists(l1, l2);
            mergedLists.push(merged);
        }
        lists = mergedLists
    }
    
    return lists[0];
};

let mergeLists = function(l1, l2) {
    
    let root = new ListNode();
    let current = root;
    
    while (l1 && l2) {
        if (l1.val < l2.val) {
            current.next = l1;
            l1 = l1.next;
        }
        else {
            current.next = l2;
            l2 = l2.next;
        }
        
        current = current.next;
    }
    
    current.next = l1 || l2;
    
    return root.next;
}

/*

    Non-heap solution - Divide and Conquer - loop the array of linked lists and merge them two at time

    Time: O(nlogk) (Since all n nodes are iterated over logk times)
    Space: O(1)

    Where n is the total number of nodes and k is the number of linked lists.

*/
