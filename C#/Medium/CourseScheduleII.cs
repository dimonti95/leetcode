public class Solution
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        var result = new List<int>();
        var adjList = new Dictionary<int, List<int>>();
        var visited = new Dictionary<int, bool>(); // true=in path, false=processed

        // Add each node to the adjList
        for (int i = 0; i < numCourses; i++) adjList.Add(i, new List<int>());

        // Add edges to the adjList (to build directed graph)
        foreach (int[] prereq in prerequisites)
        {
            int c1 = prereq[0];
            int c2 = prereq[1];
            adjList[c1].Add(c2);
        }

        bool dfs(int node)
        {
            if (visited.ContainsKey(node)) return visited[node];
            visited.Add(node, true);
            
            foreach (int neighbor in adjList[node])
            {
                if (dfs(neighbor)) return true;
            }

            result.Add(node);
            visited[node] = false;
            return false;
        }

        // Run DFS from each node
        foreach (KeyValuePair<int, List<int>> pair in adjList)
        {
            if (dfs(pair.Key)) return new int[0];
        }

        return result.ToArray();
    }
}

/*

    Solution
    1. Build a directed graph from an adjacency list
    2. Run topological sort (post-order DFS) to find a valid ordering

    Time: O(v + e)
    Space: O(v + e)

    Where v is the number of nodes (courses), and e is the number of edges (prerequisites)

    ---------------------------------------------------------------------------------

    Note: This problem is just an easier version of 269. Alien Dictionary (which also requires topological sort).
    
*/
