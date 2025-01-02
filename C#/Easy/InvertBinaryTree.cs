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
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null) return null;

        TreeNode temp = root.right;
        root.right = InvertTree(root.left);
        root.left = InvertTree(temp);

        return root;
    }
}

/*

    Recursive

    Time: O(n)
    Space: O(h)

    Where n is the number of nodes and h is the height of the tree

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
public class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null) return null;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue();
            if (current.left != null) queue.Enqueue(current.left);
            if (current.right != null) queue.Enqueue(current.right);

            TreeNode temp = current.left;
            current.left = current.right;
            current.right = temp;
        }

        return root;
    }
}

/*

    Iterative BFS (iterative DFS would work too)

    Time: O(n)
    Space: O(n) because in the worst case all n/2 leaf nodes will be in the queue

*/
