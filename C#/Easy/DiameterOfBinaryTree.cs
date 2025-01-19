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
    public int DiameterOfBinaryTree(TreeNode root)
    {
        int result = 0;
        
        int DiameterOfBinaryTreeRecursive(TreeNode node)
        {
            if (node == null) return 0;

            int leftDepth = DiameterOfBinaryTreeRecursive(node.left);
            int rightDepth = DiameterOfBinaryTreeRecursive(node.right);
            
            result = Math.Max(result, leftDepth + rightDepth);
            return Math.Max(leftDepth, rightDepth) + 1;
        }
        DiameterOfBinaryTreeRecursive(root);

        return result;
    }
}

/*

    Solution:
    * Recusively find the max depth of the left and right subtree of each node
    * Add those max depths together keeping a max

    Time: O(n)
    Space: O(n) - because in the worst-case the tree is skewed (so the height of the tree would be n)

*/
