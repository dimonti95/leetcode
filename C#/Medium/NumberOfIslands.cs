public class Solution {
    public int NumIslands(char[][] grid)
    {
        int count = 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                string key = i + "," + j;
                if (grid[i][j] == '1')
                {
                    // run DFS and mark visited cells
                    dfs(i, j);
                    count += 1;
                }
            }
        }

        void dfs(int i, int j)
        {
            string key = i + "," + j;
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length) return;
            if (grid[i][j] != '1') return;
            grid[i][j] = '0'; // mark cell as visited

            dfs(i + 1, j);
            dfs(i - 1, j);
            dfs(i, j + 1);
            dfs(i, j - 1);
        }

        return count;
    }
}

/*

    * Loop the grid looking for land cells that aren't already visited
    * Incrememt a count each time unvisted land is found
    * Run DFS on the land, remembering each visited land cell

    Time: O(n * m)
    Space: O(n * m) because worste case is that every cell is land and we're solving the problem recursively (call stack) 

*/
