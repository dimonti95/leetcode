public class Solution {
    public bool ValidTree(int n, int[][] edges)
    {
        // Build and adjacency list
        var adjList = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++) adjList.Add(i, new List<int>());
        foreach (int[] edge in edges)
        {
            int n1 = edge[0];
            int n2 = edge[1];

            // The edges are undirected
            adjList[n1].Add(n2);
            adjList[n2].Add(n1);
        }

        var visited = new HashSet<int>();
        bool dfs(int node, int parent)
        {
            if (visited.Contains(node)) return false;

            visited.Add(node);
            foreach (int neighbor in adjList[node])
            { 
                // ignore trivial cycles (A -> B -> A)
                if (neighbor != parent) {
                    if (!dfs(neighbor, node)) return false;
                }
            }

            return true;
        }

        return dfs(0, 0) && visited.Count == n;
    }
}

/*

    Recursive DFS + Graph Theory
    
    A graph is considered a tree if the following conditions are met:
    1. The graph doesn't contain any non-trivial cycles (a trivial cyle is a cycle between two nodes connected by a single undirected edge)
    2. All nodes in the graph are connected

    Solution:
    1. Build an adjacency list from the list of edges
    2. Confirm the following...
        1. The graph is connected
        2. The graph doesn't contain a cycle (avoiding trivial cycles - i.e. the same edge between two nodes)
    3. If both of the above conditions are met, then the graph is a tree, otherwise it's not

    Time: O(v + e)
    Space: O(v + e)

    Where v is the number of nodes in the graph and e is the number of edges

*/



public class Solution {
    public bool ValidTree(int n, int[][] edges)
    {
        // If the graph has more than n−1 edges, it must contain at least one cycle
        // If the graph has fewer than n−1 edges, it will be disconnected and not a tree
        if (edges.Length != n - 1) return false;

        // Build adjacency list
        var adjList = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++) adjList.Add(i, new List<int>());
        foreach (int[] edge in edges)
        {
            int n1 = edge[0];
            int n2 = edge[1];

            // The edges are undirected
            adjList[n1].Add(n2);
            adjList[n2].Add(n1);
        }

        var visited = new HashSet<int>();
        void dfs(int node)
        {
            if (visited.Contains(node)) return;
            
            visited.Add(node);
            foreach (int neighbor in adjList[node])
            {
                dfs(neighbor);
            }
        }

        dfs(0);

        // If the graph is connected and contains exactly n−1 edges, it is guaranteed to be a tree
        return visited.Count == n;
    }
}

/*

    Recursive DFS + Advanced Graph Theory

    For an undirected graph:
    - If the graph is connected and contains exactly n−1 edges, it is guaranteed to be a tree
    - If it has more than n−1 edges, it must contain at least one cycle
    - If it has fewer than n−1 edges, it will be disconnected and not a tree

    Solution:
    1. Confirm the graph has exactly n-1 edges
        - If it has fewer, return false
        - If it has more, return false
    2. Build and adjacency list
    3. Perform DFS and confirm all nodes have been visited (to confirm the graph is connected)
        - If it is connected, return true
        - If it's not connected, return false

    Time: O(n) - because we've already confirmed that the number of edges is n-1
    Space: O(n)

    Where n is the number of nodes

*/
