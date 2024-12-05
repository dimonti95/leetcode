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
    public int MaxDepth(TreeNode root) {
        if (root == null) return 0;

        int left = MaxDepth(root.left);
        int right = MaxDepth(root.right);

        return Math.Max(left, right) + 1;
    }
}

/*

  Recursive DFS keeping count of max depth from the root node
  
  Time Complexity: O(n)
  Space Complexity: O(h)
  
  Where n is the number of nodes in the tree and h is the max height

*/
