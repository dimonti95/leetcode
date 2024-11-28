/**
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 */
/**
 * @param {ListNode} node
 * @return {void} Do not return anything, modify node in-place instead.
 */
 var deleteNode = function(node) {
    
  let current = node;
  let prev = null;
  
  while (current !== null) {
      if (current.next === null) {
          prev.next = null;
          return;
      }
      
      current.val = current.next.val;
      prev = current;
      current = current.next;
  }
  
};

/*

  Loop from the node being deleted to the end of the list keeping a pointer to the previous node, swap the value of 
  current node with next node until reaching the last node, then point the second to last node to null.

  Time Complexity: O(n)
  Space Complexity: O(1)
  
  Where n is the number of nodes in the list.

*/
