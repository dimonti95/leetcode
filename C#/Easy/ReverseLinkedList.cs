/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseList(ListNode head) {
        
        if (head == null) return null;

        ListNode previous = null;
        ListNode current = head;
        while (current != null)
        {
            ListNode temp = current.next;
            current.next = previous;
            previous = current;
            current = temp;
        }

        return previous;
    }
}

/*

  
    Loop over the list and reverse the pointer of each node.

    Space Complexity: O(1)
    Time Complexity: O(n)
  
    Where n is the number of nodes in the list.

*/



/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseList(ListNode head) {
        
        if (head == null) return null;

        ListNode temp = head;

        if (head.next != null)
        {
            temp = ReverseList(head.next);
            head.next.next = head;
        }

        head.next = null;
        return temp;
    }
}

/*

    Recursive

    Time: O(n)
    Space: O(n)

*/
