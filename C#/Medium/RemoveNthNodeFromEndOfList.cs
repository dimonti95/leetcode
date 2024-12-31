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
public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode temp = new ListNode(0, head);
        ListNode left = temp;
        ListNode right = head;
        
        while (n > 0)
        {
            right = right.next;
            n--;
        }

        while (right != null)
        {
            left = left.next;
            right = right.next;
        }

        left.next = left.next.next;
        return temp.next;
    }
}

/*

    Iterative
     
    Time: O(n)
    Space: O(1)

    Where n is the number of nodes in the list

    Algorithm:
    * Use temp to keep the left pointer n-1 behind the right pointer
    * Iterate until right is null
    * Remove the node

*/
