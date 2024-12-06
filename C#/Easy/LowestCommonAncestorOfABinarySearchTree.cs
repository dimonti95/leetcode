/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null) return null;
        
        if (p.val < root.val && q.val < root.val)
        {
            // go left
            TreeNode left = LowestCommonAncestor(root.left, p, q);
            if (left != null) return left;
        }
        else if (p.val > root.val && q.val > root.val)
        {
            // go right
            TreeNode right = LowestCommonAncestor(root.right, p, q);
            if (right != null) return right;
        }

        return root;
    }
}

/*

    Recursive DFS using a range given by the current node of the BST.

    Time: O(n)
    Space: O(h)

    Where n is the number of nodes in the BST and h is the height.

*/
