/**
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 */

/**
 * @param {ListNode} headA
 * @param {ListNode} headB
 * @return {ListNode}
 */
 var getIntersectionNode = function(headA, headB) {
    
  let currentA = headA;
  
  while (currentA !== null) {
      currentA.visited = true;
      currentA = currentA.next;
  }
  
  let currentB = headB;
  
  while (currentB !== null) {
      if (currentB.visited === true) return currentB;
      currentB = currentB.next;
  }
  
  return null;
};


/*

  Mark all nodes in list A, then loop over all nodes in list B and return the first marked node found.
  
  Time Complexity: O(n)
  Space Complexity: O(1)
  
  Where n is the total number of nodes.

*/
