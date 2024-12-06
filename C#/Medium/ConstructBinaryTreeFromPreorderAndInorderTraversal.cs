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
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        if (preorder.Length == 0 || inorder.Length == 0) return null;

        var node = new TreeNode(preorder[0]);
        int i = Array.IndexOf(inorder, preorder[0]);
        
        // left preorder
        int len = i;
        int[] leftPreorder = new int[len];
        Array.Copy(preorder, 1, leftPreorder, 0, len);

        // left inorder
        int[] leftInorder = new int[len];
        Array.Copy(inorder, 0, leftInorder, 0, len);

        // right preorder
        len = preorder.Length - i - 1;
        int[] rightPreorder = new int[len];
        Array.Copy(preorder, i + 1, rightPreorder, 0, len);

        // left inorder
        int[] rightInorder = new int[len];
        Array.Copy(inorder, i + 1, rightInorder, 0, len);

        node.left = BuildTree(leftPreorder, leftInorder);
        node.right = BuildTree(rightPreorder, rightInorder);

        return node;
    }
}

/*

    The first preorder value is always the root. Split inorder at the index where that value is at.
    
    Example:
    preorder: [3,9,20,15,7]
    inorder: [9,3,15,20,7]
    
    inorder splts at 3 to: 
    left subtree nodes -> [9]
    right subtree ndoes -> [15,20,7]

    remaining preorder array gets split:
    [9]
    [20,15,7]
    
    20 is the next first preorder node

    Time: O(n)
    Space: O(n)

*/
