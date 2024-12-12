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
    public ListNode MergeKLists(ListNode[] lists)
    {
        int k = lists.Length;
        while (k > 1)
        {
            int j = 0;
            for (int i = 1; i <= k; i += 2)
            {
                ListNode list1 = lists[i - 1];
                ListNode list2 = i < k ? lists[i] : null;
                ListNode merged = MergeLists(list1, list2);
                lists[j++] = merged;
            }
            k = (int)Math.Ceiling((double)k / 2);
        }

        return lists.Length > 0 ? lists[0] : null;
    }

    private ListNode MergeLists(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;

        if (list1.val < list2.val)
        {
            list1.next = MergeLists(list1.next, list2);
            return list1;
        }
        else
        {
            list2.next = MergeLists(list1, list2.next);
            return list2;
        }
    }
}

/*

    Non-heap solution - Divide and Conquer - loop the array of linked lists and merge them two at time

    Time: O(nlogk) (Since all n nodes are iterated over logk times)
    Space: O(1)

    Where n is the total number of nodes and k is the number of linked lists.

    Brute Force 1
    1. Put the nodes into an array
    2. Sort the array
    3. Create a new list from those nodes

    Time: O(n*logn)
    Space: O(n)

    Brute Force 2
    1. Search each k lists for the smallest head node each iteration
    2. Update pointers on exisitng nodes (in-place)
    
    Time: O(n*k)
    Space: O(1)


*/
