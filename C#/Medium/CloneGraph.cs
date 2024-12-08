/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node)
    {
        if (node == null) return null;

        var copyMap = new Dictionary<int, Node>();

        Node dfs(Node n)
        {
            if (copyMap.ContainsKey(n.val)) return copyMap[n.val];
            
            var copy = new Node(n.val);
            copyMap.Add(n.val, copy);

            foreach (Node neighbor in n.neighbors)
            {
                copy.neighbors.Add(dfs(neighbor));
            }

            return copy;
        }

        return dfs(node);
    }
}

/*

    Recursive DFS
    
    Time Complexity: O(n + e)
    Space Compelxity: O(n)

*/


