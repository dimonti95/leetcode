/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution
{
    public bool HasCycle(ListNode head)
    {
        
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null)
        {
            if (fast.next == null) return false;

            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast) return true;
        }

        return false;
    }
}

/*

    Brute force solution: 
    * Iterate through the list
    * Use a a HashSet to find cycle

    Time: O(n)
    Space: O(n)

    Where n is the number of nodes in the list

    ---------------------------------------------

    Optimized space solution (Floyd's cycle finding algorithm):
    * Iterate through the list with a slow and fast pointer
    * If the pointers meet then there's a cycle

    Time: O(n)
    Space: O(1)

*/



/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution
{
    public bool HasCycle(ListNode head)
    {
        if (head == null || head.next == null) return false;
        return HasCycleRecursive(head.next, head.next.next);
    }

    private bool HasCycleRecursive(ListNode slow, ListNode fast)
    {
        if (slow == null || fast == null || fast.next == null) return false;
        if (slow == fast) return true;
        return HasCycleRecursive(slow.next, fast.next.next);
    }
}

/*

    Recursive solution

    Time: O(n)
    Space: O(n)

    Where n is the number of nodes in the list

*/
