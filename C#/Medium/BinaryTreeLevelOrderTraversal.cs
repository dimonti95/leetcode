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
        var queue = new Queue<Tuple<TreeNode, int>>();
        queue.Enqueue(new Tuple<TreeNode, int>(root, 0));

        while (queue.Count > 0)
        {
            Tuple<TreeNode, int> tuple = queue.Dequeue();
            
            if (tuple.Item2 < res.Count) res[tuple.Item2].Add(tuple.Item1.val);
            else res.Add(new List<int>{ tuple.Item1.val });

            if (tuple.Item1.left != null) queue.Enqueue(new Tuple<TreeNode, int>(tuple.Item1.left, tuple.Item2 + 1));
            if (tuple.Item1.right != null) queue.Enqueue(new Tuple<TreeNode, int>(tuple.Item1.right, tuple.Item2 + 1));
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
