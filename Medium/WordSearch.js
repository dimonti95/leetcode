/**
 * @param {character[][]} board
 * @param {string} word
 * @return {boolean}
 */
 var exist = function(board, word) {
    
    let nRows = board.length,
        nCols = board[0].length;
    let visited = new Set();
    
    let dfs = function(r, c, i) {
        
        if (i === word.length) return true;
        
        let cellKey = [r, c].toString();
        if (r < 0 || c < 0 || r >= nRows || c >= nCols || word[i] !== board[r][c] || visited.has(cellKey)) return false;
        
        visited.add(cellKey);
        
        let up = dfs(r + 1, c, i + 1);
        let down = dfs(r - 1, c, i + 1);
        let right = dfs(r, c + 1, i + 1);
        let left = dfs(r, c - 1, i + 1);
        
        visited.delete(cellKey);
        
        return up || down || left || right;
    }
    
    for (let r = 0; r < nRows; r++) {
        for (let c = 0; c < nCols; c++) {
            let found = dfs(r, c, 0);
            if (found) return true;
        }
    }
    
    return false;
};

/*

    Backtracking - DFS - mark current path and backtrack if it doesn't lead to the answer
    
    Time: O(N * 3L)
    Space: O(L)
    
    Where N is the number of cells and L is the length of the word

*/
