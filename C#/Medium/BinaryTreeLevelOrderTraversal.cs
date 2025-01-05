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
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        void dfs(TreeNode node, int level)
        {
            if (node == null) return;

            if (level == result.Count) result.Add(new List<int>());
            result[level].Add(node.val);

            dfs(node.left, level + 1);
            dfs(node.right, level + 1);
        }

        dfs(root, 0);
        return result;
    }
}

/*

    Recursive DFS

    Time: O(n)
    Space: O(h) - assuming the output array doesn't count as extra space

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
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        if (root == null) return new List<IList<int>>();

        var res = new List<IList<int>>();
        var queue = new Queue<(TreeNode, int)>(); // (TreeNode, int) = C# ValueTuple
        queue.Enqueue((root, 0));

        while (queue.Count > 0)
        {
            (TreeNode, int) tuple = queue.Dequeue();
            
            if (tuple.Item2 < res.Count) res[tuple.Item2].Add(tuple.Item1.val);
            else res.Add(new List<int>{ tuple.Item1.val });

            if (tuple.Item1.left != null) queue.Enqueue((tuple.Item1.left, tuple.Item2 + 1));
            if (tuple.Item1.right != null) queue.Enqueue((tuple.Item1.right, tuple.Item2 + 1));
        }

        return res;
    }
}

/*

    DFS, keeping track of the level of each node

    Time: O(n)
    Space: O(h)

    Where n is the number of nodes in the tree and h is the height of the tree

*/
