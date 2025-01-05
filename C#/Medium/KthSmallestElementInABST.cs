/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int KthSmallest(TreeNode root, int k)
    {
        var stack = new Stack<TreeNode>();
        TreeNode current = root;

        while (current != null || stack.Count > 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }

            current = stack.Pop();

            // in-order
            if (k == 1) return current.val;
            else k--;

            current = current.right;
        }

        return 0;
    }
}

/*

    Iterative in-order DFS

    Time: O(h + k)
    Space: O(h)

    Where n is the number of nodes in the tree and h is the height of the tree

    ----------------------------------------------------------------------------

    Follow-up question: If the BST is modified often (i.e., we can do insert and delete operations) and you need to find the kth smallest frequently, how would you optimize?

    Time of insertion into a BST: O(logn) if it's balanced, O(n) if it's skewed
    Time of deletion from a BST: O(logn) if it's balanced, O(n) if it's skewed
    Time of search for the kth smallest element in a BST: O(n)

    A1: Add the K smallest element in the BST to a max heap. Each time a new node is added to the tree, check if it's smaller than the node at the
    top of the heap, if it is, then add it to the heap and remove to keep the heap of size k. This only works if K is constant.

    A2: ...

*/



/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public int KthSmallest(TreeNode root, int k)
    {
        int result = root.val;
        
        void dfs(TreeNode node)
        {
            if (node == null || k == 0) return;
            
            dfs(node.left);
            
            k -= 1;
            if (k == 0)
            {
                result = node.val;
                return;
            }
            
            dfs(node.right);
        }
        
        dfs(root);
        
        return result;
    }
}

/*

    Recursive in-order traversal

    Time: O(n)
    Space: O(h)

    Where n is the number of nodes in the tree and h is the height of the tree

*/
