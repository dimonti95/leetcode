public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        // build adjacency list
        var adjList = new Dictionary<int, List<int>>();
        for (int i = 0; i < numCourses; i++) adjList.Add(i, new List<int>());
        foreach (int[] prereq in prerequisites)
        {
            int course1 = prereq[0];
            int course2 = prereq[1];
            adjList[course1].Add(course2);
        }

        var visited = new HashSet<int>();
        bool dfs(int course)
        {
            if (visited.Contains(course)) return false;
            visited.Add(course);

            foreach (int neighbor in adjList[course])
            {
                if (!dfs(neighbor)) return false;
            }

            adjList[course].Clear(); // optimization
            visited.Remove(course);
            return true;
        }

        // check for a cycle starting from each course
        for (int i = 0; i < numCourses; i++)
        {
            if (!dfs(i)) return false;
        }

        return true;
    }
}

/*

    DFS - check for cycle

    Time Complexity: O(v + e)
    Space Complexity: O(v + e)

*/
