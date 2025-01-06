public class Solution
{
    public int CountComponents(int n, int[][] edges)
    {
        var adjList = new Dictionary<int, List<int>>();
        var visited = new HashSet<int>();

        // Build an adj list
        for (int i = 0; i < n; i++) adjList.Add(i, new List<int>());
        foreach (int[] edge in edges)
        {
            int n1 = edge[0];
            int n2 = edge[1];
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

        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (!visited.Contains(i))
            {
                count++;
                dfs(i);
            }
        }

        return count;
    }
}

/*

    DFS on an adjacency list - tracking nodes that have already been visited

    Time: O(v + e)
    Space: O(v + e)

*/
