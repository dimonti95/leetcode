public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] heights) 
    {
        var res = new List<IList<int>>();
        var pacificCells = new Dictionary<string, List<int>>();
        var atlanticCells = new Dictionary<string, List<int>>();
        int rowCount = heights.Length;
        int colCount = heights[0].Length;

        // Left and right columns
        for (int r = 0; r < rowCount; r++)
        {
            traverse(r, 0, 0, pacificCells);
            traverse(r, colCount - 1, 0, atlanticCells);
        }

        // Top and bottom rows
        for (int c = 0; c < colCount; c++)
        {
            traverse(0, c, 0, pacificCells);
            traverse(rowCount - 1, c, 0, atlanticCells);
        }

        void traverse(int r, int c, int prevHeight, Dictionary<string, List<int>> map)
        {
            if (r < 0 || r >= rowCount || c < 0 || c >= colCount) return;
            if (prevHeight > heights[r][c]) return;
            
            string key = r + "," + c;
            if (map.ContainsKey(key)) return;
            map.Add(key, new List<int> { r, c } );

            traverse(r + 1, c, heights[r][c], map);
            traverse(r - 1, c, heights[r][c], map);
            traverse(r, c + 1, heights[r][c], map);
            traverse(r, c - 1, heights[r][c], map);
        }

        // Find common cells that can reach both oceans
        foreach (var pair in pacificCells)
        {
            if (atlanticCells.ContainsKey(pair.Key)) res.Add(pacificCells[pair.Key]);
        }

        return res;
    }
}

/*

    DFS from all of the edge cells moving backwards (Rather than doing a DFS from each cell outward which would be O(m*n)^2 time)
    
    Time Complexity: O(m*n)
    Space Complexity: O(m*n)

*/
