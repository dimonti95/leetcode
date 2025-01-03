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
    public int MaxPathSum(TreeNode root)
    {
        int res = root.val;
        
        int MaxPathSumRecursive(TreeNode node)
        {
            if (node == null) return 0;

            int leftSum = MaxPathSumRecursive(node.left);
            int rightSum = MaxPathSumRecursive(node.right);
            leftSum = Math.Max(leftSum, 0);
            rightSum = Math.Max(rightSum, 0);

            res = Math.Max(res, node.val + leftSum + rightSum);

            return node.val + Math.Max(leftSum, rightSum);
        }

        MaxPathSumRecursive(root);

        return res;
    }
}

/*

    DFS traversal checking for current max of split at each node

    The base case is the leaf nodes

    Do two things at every node:
    (1) Get the sum if the path split at that node
    (2) Return the max if the path crossed through that node
    
    Time: O(n)
    Space: O(h)

*/
