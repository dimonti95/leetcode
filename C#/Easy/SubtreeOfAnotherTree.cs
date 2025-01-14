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
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (root == null) return false;

        if (root != null && root.val == subRoot.val && IsSameTree(root, subRoot)) return true;
        else if (IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot)) return true;

        return false;
    }

    private bool IsSameTree(TreeNode tree1, TreeNode tree2)
    {
        if (tree1 == null && tree2 != null || tree1 != null && tree2 == null) return false;
        else if (tree1 != null && tree2 != null && tree1.val != tree2.val) return false;
        else if (tree1 == null && tree2 == null) return true;

        if (!IsSameTree(tree1.left, tree2.left) || !IsSameTree(tree1.right, tree2.right)) return false;

        return true;
    }
}

/*

    Check for if subRoot is a subtree at every node
    
    Time: O(n * m)
    Space: O(h)

    Where
    * n is the number of nodes in the tree
    * m is the number of nodes in the subtree
    * h is the height of the tree

*/
