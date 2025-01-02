/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        
        if (p.val < root.val && q.val < root.val)
        {
            // go left
            return LowestCommonAncestor(root.left, p, q);
        }
        else if (p.val > root.val && q.val > root.val)
        {
            // go right
            return LowestCommonAncestor(root.right, p, q);
        }

        return root;
    }
}

/*

    Recursive DFS using a range given by the current node of the BST.

    Time: O(n)
    Space: O(h)

    Where n is the number of nodes in the BST and h is the height.

    Note: You don't need a null check because the nodes p and q are guaranteed to exist in the BST.

*/
