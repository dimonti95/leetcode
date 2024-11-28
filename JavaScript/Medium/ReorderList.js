/**
 * Definition for singly-linked list.
 * function ListNode(val, next) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.next = (next===undefined ? null : next)
 * }
 */
/**
 * @param {ListNode} head
 * @return {void} Do not return anything, modify head in-place instead.
 */
 var reorderList = function(head) {

  let slow = head;
  let fast = head.next;
  while (fast && fast.next) {
    slow = slow.next;
    fast = fast.next.next;
  }
  
  let second = slow.next;
  slow.next = null;
  
  // reverse second half
  let prev = null;
  while (second) {    
    let next = second.next
    second.next = prev;
    prev = second;
    second = next;
  }
  
  // combine
  let first = head;
  second = prev;
  while (first && second) {
    let nextFirst = first.next;
    let nextSecond = second.next;
    first.next = second;
    second.next = nextFirst;
    first = nextFirst;
    second = nextSecond;
  }
  
  return head;
};

/*

  Time: O(n)
  Space: O(1)

*/
