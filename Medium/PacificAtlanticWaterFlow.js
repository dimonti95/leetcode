/**
 * @param {number[][]} heights
 * @return {number[][]}
 */
 var pacificAtlantic = function(heights) {
    
    let nRows = heights.length;
    let nCols = heights[0].length;
    let pac = new Set();
    let atl = new Set();
    
    let dfs = function (r, c, visited, prevHeight) {
        if (visited.has([r, c].toString()) || r < 0 || c < 0 || r >= nRows || c >= nCols || heights[r][c] < prevHeight) {
            return;
        }
        
        visited.add([r, c].toString());
        dfs(r + 1, c, visited, heights[r][c]);
        dfs(r - 1, c, visited, heights[r][c]);
        dfs(r, c + 1, visited, heights[r][c]);
        dfs(r, c - 1, visited, heights[r][c]);
    }
    
    for (let r = 0; r < nRows; r++) {
        dfs(r, 0, pac, heights[r][0]);
        dfs(r, nCols - 1, atl, heights[r][nCols - 1]);
    }
    
    for (let c = 0; c < nCols; c++) {
        dfs(0, c, pac, heights[0][c]);
        dfs(nRows - 1, c, atl, heights[nRows - 1][c]);
    }
    
    let ans = [];
    for (let r = 0; r < nRows; r++) {
        for (let c = 0; c < nCols; c++) {
            if (pac.has([r, c].toString()) && atl.has([r, c].toString())) {
                ans.push([r, c]);
            }
        }
    }
    
    return ans;
};

/*

    DFS from all of the edge cells moving backwards (Rather than doing a DFS from each cell outward which would be O(m*n)^2 time)
    
    Time Complexity: O(m*n)
    Space Complexity: O(m*n)

*/
