/**
 * Definition for singly-linked list.
 * function ListNode(val, next) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.next = (next===undefined ? null : next)
 * }
 */
/**
 * @param {ListNode} head
 * @return {ListNode}
 */
 var reverseList = function(head) {
    
  let current = head;
  let prev = null;
  
  while (current !== null) {
      if (current.next === null) head = current;
      const temp = current.next;
      current.next = prev        
      prev = current;
      current = temp;
  }

  return head;
};

/*
  
  Loop over the list and reverse the pointer of each node.

  Time Complexity: O(n)
  Space Complexity: O(1)
  
  Where n is the number of nodes in the list.

*/
