/**
 * Definition for singly-linked list.
 * function ListNode(val, next) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.next = (next===undefined ? null : next)
 * }
 */
/**
 * @param {ListNode} l1
 * @param {ListNode} l2
 * @return {ListNode}
 */
 var mergeTwoLists = function(l1, l2) {
    
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
};

/*
    Iterative    

    Time: O(n)
    Space: O(1)

*/



/**
 * Definition for singly-linked list.
 * function ListNode(val, next) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.next = (next===undefined ? null : next)
 * }
 */
/**
 * @param {ListNode} list1
 * @param {ListNode} list2
 * @return {ListNode}
 */
var mergeTwoLists = function(list1, list2) {

  if (!list1) return list2;
  if (!list2) return list1;
  
  if (list1.val < list2.val) {
    list1.next = mergeTwoLists(list1.next, list2);
    return list1;
  }
  else {
    list2.next = mergeTwoLists(list1, list2.next);
    return list2;
  }
  
};

/*

    Recursive

    Time: O(n)
    Space: O(n)

*/
