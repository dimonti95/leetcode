/**
 * @param {character[][]} grid
 * @return {number}
 */
 var numIslands = function(grid) {
    
    let visited = new Set();
    let numOfIslands = 0;
    let nRows = grid.length;
    let nCols = grid[0].length;
    
    let dfs = function (m, n) {
        let cell = [m, n].toString();
        if (visited.has(cell) || grid[m] === undefined || grid[m][n] !== "1") return;
        visited.add(cell);
        
        dfs(m + 1, n);
        dfs(m - 1, n);
        dfs(m, n + 1);
        dfs(m, n - 1);
    }
    
    for (let m = 0; m < nRows; m++) {
        for (let n = 0; n < nCols; n++) {
            if (grid[m][n] === "1" && !visited.has([m,n].toString())) {
                dfs(m, n);
                numOfIslands += 1;
            }
        }
    }
    
    return numOfIslands;
};

/*

    DFS on every land node that hasn't already been visited
    
    Time Complexity: O(m*n)
    Space Complexity: O(m*n)

*/



/**
 * @param {character[][]} grid
 * @return {number}
 */
 var numIslands = function(grid) {
    
    if (grid.length === 0) return 0;
    
    let nRows = grid.length;
    let nCols = grid[0].length;
    let visited = new Set();
    let nIslands = 0;
    
    let bfs = function (r, c) {
        let queue = [ [r, c] ];
        
        while (queue.length > 0) {
            let current = queue.shift();
            if (visited.has(current.toString())) continue;
            visited.add(current.toString());
            let row = current[0];
            let col = current[1];
            
            let up = [row + 1, col];
            let down = [row - 1, col];
            let right = [row, col + 1];
            let left = [row, col - 1];
            
            if (grid[row + 1] && grid[row + 1][col] === '1' && !visited.has(up.toString())) {
                queue.push(up);
            }
            if (grid[row - 1] && grid[row - 1][col] === '1' && !visited.has(down.toString())) {
                queue.push(down);
            }
            if (grid[row][col + 1] === '1' && !visited.has(right.toString())) {
                queue.push(right);
            }
            if (grid[row][col - 1] === '1' && !visited.has(left.toString())) {
                queue.push(left);
            }
        }
    }
    
    for (let r = 0; r < nRows; r++) {
        for (let c = 0; c < nCols; c++) {
            if (grid[r][c] === '1' && !visited.has([r, c].toString())) {
                bfs(r, c);
                nIslands += 1;
            }
        }
    }
    
    return nIslands;
};

/*

    BFS on every land node that hasn't already been visited
    
    Time Complexity: O(m*n)
    Space Complexity: O(m*n)

*/
