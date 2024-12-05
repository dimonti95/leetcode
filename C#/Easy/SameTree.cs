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
        if (p == null || q == null) return false;

        var pStack = new Stack<TreeNode>();
        pStack.Push(p);

        var qStack = new Stack<TreeNode>();
        qStack.Push(q);

        while (pStack.Count > 0 && qStack.Count > 0)
        {
            TreeNode pCurrent = pStack.Pop();
            TreeNode qCurrent = qStack.Pop();
            if (pCurrent.val != qCurrent.val) return false;

            // left
            if (pCurrent.left != null && qCurrent.left != null)
            {
                pStack.Push(pCurrent.left);
                qStack.Push(qCurrent.left);
            }
            else if (pCurrent.left == null && qCurrent.left == null)
            {
                // no-op
            }
            else
            {
                return false;
            }

            // right
            if (pCurrent.right != null && qCurrent.right != null)
            {
                pStack.Push(pCurrent.right);
                qStack.Push(qCurrent.right);
            }
            else if (pCurrent.right == null && qCurrent.right == null)
            {
                // no-op
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}

/*

    Iterative DFS

    Time: O(n)
    Space: O(h)
    
    Where n is the number of nodes and h is longest common height between both trees

*/
