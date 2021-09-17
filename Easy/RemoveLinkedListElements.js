/**
 * Definition for singly-linked list.
 * function ListNode(val, next) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.next = (next===undefined ? null : next)
 * }
 */
/**
 * @param {ListNode} head
 * @param {number} val
 * @return {ListNode}
 */
 var removeElements = function(head, val) {
 
  let current = head;
  let prev = null;
  
  while (current !== null) {
      
      if (current.val === val) {
          if (current.next === null && current === head) {
              head = null;
          }
          else if (current.next === null) {
              prev.next = null;
          }
          else if (current === head) {
              head = current.next;
          }
          else {
              prev.next = current.next;
              current = current.next;
              continue;
          }
      }
      
      prev = current;
      current = current.next;
  }
  
  return head;
  
};

/*
  
  Loop over the list removing any nodes with a value that matches val.
  
  Time Complexity: O(n)
  Space Complexity: O(1)
  
  Where n is the number of nodes in the list.

*/
