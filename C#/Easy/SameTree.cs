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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        
        if (p == null && q == null) return true;
        if (p == null && q != null) return false;
        if (p != null && q == null) return false;
        if (p.val != q.val) return false;

        bool left = IsSameTree(p.left, q.left);
        bool right = IsSameTree(p.right, q.right);

        if (!left || !right) return false;
        else return true;
    }
}

/*

    Recursive DFS

    Time: O(n)
    Space: O(h)
  
    Where n is the number of nodes and h is longest common height between both trees

*/
