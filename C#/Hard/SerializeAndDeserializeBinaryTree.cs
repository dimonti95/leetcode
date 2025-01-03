/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec
{
    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        var sb = new StringBuilder();

        void dfs(TreeNode node)
        {
            if (node == null)
            {
                sb.Append("N" + ",");
                return;
            } 
            
            sb.Append(node.val + ",");
            dfs(node.left);
            dfs(node.right);
        }

        dfs(root);
        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        string[] vals = data.Split(',');
        int i = 0;

        TreeNode dfs(string[] vals)
        {
            string val = vals[i];
            if (val == "N")
            {
                i += 1;
                return null;
            }
            

            var node = new TreeNode();
            node.val = int.Parse(val);
            i += 1;

            node.left = dfs(vals);
            node.right = dfs(vals);
            
            return node;
        }

        return dfs(vals);
    }
}

/*

    Serialize:
    - Traverse the tree using DFS
    - Capture the structure of the tree by creating a pre-order traversal string
    - The pre-order traversal string needs to include null nodes, otherwise it doesn't capture the structure of the tree (key insight)

    Serialize
    Time: O(n)
    Space: O(n)

    Deserialize
    Time: O(n)
    Space: O(n)

    Where n is the number of nodes in the tree

    ------------------------------------------------------------------------------------------------

    This problem can be solved with DFS or BFS. Using DFS, it can be solved using a pre-order, in-order, or post-order traversal.

    Given the following tree:

           Node1
          /    \
        Node2  Node5
        /   \
    Node3  Node4

    Using pre-order DFS traversal, the serialization string would be [1,2,3,N,N,4,N,N,5,N,N]

*/
