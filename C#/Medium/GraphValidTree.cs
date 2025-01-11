public class Solution
{
    public bool ValidTree(int n, int[][] edges)
    {
        var adjList = new List<List<int>>();
        var visited = new HashSet<int>();

        // Build and adjacency list
        for (int i = 0; i < n; i++) adjList.Add(new List<int>());
        foreach (int[] edge in edges)
        {
            int n1 = edge[0];
            int n2 = edge[1];

            // The edges are undirected
            adjList[n1].Add(n2);
            adjList[n2].Add(n1);
        }

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



public class Solution2
{
    public bool ValidTree(int n, int[][] edges)
    {
        // If the graph has more than n−1 edges, it must contain at least one cycle
        // If the graph has fewer than n−1 edges, it will be disconnected and not a tree
        if (edges.Length != n - 1) return false;

        var visited = new HashSet<int>();
        var adjList = new List<List<int>>();

        // Build adjacency list
        for (int i = 0; i < n; i++) adjList.Add(new List<int>());
        foreach (int[] edge in edges)
        {
            int n1 = edge[0];
            int n2 = edge[1];

            // The edges are undirected
            adjList[n1].Add(n2);
            adjList[n2].Add(n1);
        }

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



public class Solution3
{
    public bool ValidTree(int n, int[][] edges)
    {
        if (edges.Length != n - 1) return false;

        var unionFind = new UnionFind(n);
        foreach (int[] edge in edges)
        {
            int n1 = edge[0];
            int n2 = edge[1];
            if (!unionFind.Union(n1, n2)) return false;
        }

        return true;
    }
}

public class UnionFind
{
    int[] parent;

    public UnionFind(int n)
    {
        parent = new int[n];
        for (int i = 0; i < n; i++) parent[i] = i;
    }

    public int Find(int n)
    {
        while (parent[n] != n)
            n = parent[n];
        return n;
    }

    public bool Union(int n1, int n2)
    {
        int rootOne = Find(n1);
        int rootTwo = Find(n2);
        if (rootOne == rootTwo) return false;
        parent[rootOne] = rootTwo;
        return true;
    }
}

/*
    
    Union find (without union find optimizations)

    Time: O(n^2) - because the function returns when e != n - 1, so e == n - 1
    Space: O(n)

    ---------------------------------------------------

    The parent array is initialized so that every node is a parent of itself.

    Example: n=5, edges=[[0,1],[0,2],[0,3],[1,4]]

    [0,1,2,3,4]
     0 1 2 3 4

    union(0,1)
    parent=[0,0,2,3,4]
            0 1 2 3 4
    
    union(0,2)
    parent=[0,0,0,3,4]
            0 1 2 3 4
    
    ... etc

*/



public class Solution
{
    public bool ValidTree(int n, int[][] edges)
    {
        if (edges.Length != n - 1) return false;

        var unionFind = new UnionFind(n);
        foreach (int[] edge in edges)
        {
            int n1 = edge[0];
            int n2 = edge[1];
            if (!unionFind.Union(n1, n2)) return false;
        }

        return true;
    }
}

public class UnionFind
{
    int[] parent;
    int[] size;

    public UnionFind(int n)
    {
        parent = new int[n];
        size = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            size[i] = 1;
        }
    }

    public int Find(int n)
    {
        int root = n;
        while (parent[root] != root)
            root = parent[root];

        while (parent[n] != n)
        {
            int temp = parent[n];
            parent[n] = root;
            n = temp;
        }
            
        return root;
    }

    public bool Union(int n1, int n2)
    {
        int rootOne = Find(n1);
        int rootTwo = Find(n2);
        if (rootOne == rootTwo) return false;

        if (size[rootOne] < size[rootTwo])
        {
            parent[rootOne] = rootTwo;
            size[rootTwo] += size[rootOne];
        }
        else
        {
            parent[rootTwo] = rootOne;
            size[rootOne] += size[rootTwo];
        }
        
        return true;
    }
}

/*
    
    Union find

    Time: O(n*α(n))
    Space: O(n)

    Where e is the number of edges and n is the number of nodes.

    Time explained:
    * If the number of edges is not n - 1 the function returns, so e == n - 1
    * α(n) = amortized linear time
    * 



*/  
