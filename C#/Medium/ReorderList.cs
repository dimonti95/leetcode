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
    public void ReorderList(ListNode head)
    {
        ListNode left = new ListNode(0, head);
        ListNode right = left;
        while (right != null && right.next != null)
        {
            left = left.next;
            right = right.next.next;
        }

        // Cut the list in half and find the middle node
        ListNode current = left.next;
        left.next = null;

        // Reverse second half
        ListNode previous = null;
        while (current != null)
        {
            ListNode temp = current.next;
            current.next = previous;
            previous = current;
            current = temp;
        }

        // Splice together the two lists
        ListNode list1 = head;
        ListNode list2 = previous;
        while (list1 != null && list2 != null)
        {
            ListNode temp1 = list1.next;
            ListNode temp2 = list2.next;
            list1.next = list2;
            list2.next = temp1;
            list1 = temp1;
            list2 = temp2;
        }
    }
}

/*

    Iterative

    Time: O(n)
    Time: O(1)

    Where n is the number of nodes in the list

*/
