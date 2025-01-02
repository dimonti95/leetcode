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
    public int MaxDepth(TreeNode root)
    {
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
  
  Where n is the number of nodes in the tree and h is the max height (note that in the worste case, h will be equal to n)

  ------------------------------------------------------------------------

  This is not the optimal approach for two reasons:
  1. Space complexity as a result of the call stack
  2. Call stack overhead could lead to stack overflow for a big enough tree

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
public class Solution2
{
    public int MaxDepth(TreeNode root)
    {
        int max = 0;
        var stack = new Stack<(TreeNode, int)>(); // The (TreeNode, int) syntax is a value tuple
        if (root != null) stack.Push((root, 1));

        while (stack.Count > 0)
        {
            (TreeNode, int) current = stack.Pop();
            max = Math.Max(max, current.Item2);

            if (current.Item1.left != null)
                stack.Push((current.Item1.left, current.Item2 + 1));
            if (current.Item1.right != null)
                stack.Push((current.Item1.right, current.Item2 + 1));
        }

        return max;
    }
}

/*

  Iterative DFS
  
  Time Complexity: O(n)
  Space Complexity: O(h)
  
  Where n is the number of nodes in the tree and h is the max height

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
public class Solution3
{
    public int MaxDepth(TreeNode root)
    {
        int max = 0;
        var queue = new Queue<(TreeNode, int)>(); // The (TreeNode, int) syntax is a value tuple
        if (root != null) queue.Enqueue((root, 1));

        while (queue.Count > 0)
        {
            (TreeNode, int) current = queue.Dequeue();
            max = Math.Max(max, current.Item2);

            if (current.Item1.left != null)
                queue.Enqueue((current.Item1.left, current.Item2 + 1));
            if (current.Item1.right != null)
                queue.Enqueue((current.Item1.right, current.Item2 + 1));
        }

        return max;
    }
}

/*

  BFS
  
  Time Complexity: O(n)
  Space Complexity: O(w) (worst-case O(n))
  
  Where n is the number of nodes in the tree and w is the width of the tree

*/
