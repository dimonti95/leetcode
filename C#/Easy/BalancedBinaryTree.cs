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
    public bool IsBalanced(TreeNode root)
    {
        bool result = true;

        int dfs(TreeNode node)
        {
            if (node == null) return 0;

            int leftHeight = dfs(node.left);
            int rightHeight = dfs(node.right);

            if (Math.Abs(leftHeight - rightHeight) > 1) result = false;

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        dfs(root);

        return result;
    }
}

/*
    
    Bottom-up recursion

    Time: O(n)
    Space: O(n) - because in the worst case the height of the tree is n

    --------------------------------------------------------------------

    Height-balanced binary tree:
    A binary tree in which the depth of the two subtrees of every node never differs by more than one.

*/
