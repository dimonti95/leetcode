/**
 * @param {number[][]} grid
 * @return {number}
 */
 var islandPerimeter = function(grid) {
    
  let count = 0;
  
  for (let i = 0; i < grid.length; i++) {
      for (let j = 0; j < grid[i].length; j++) {
          if (grid[i][j] === 1) {
              if (grid[i][j - 1] === 0 || grid[i][j - 1] === undefined) count++;
              if (grid[i][j + 1] === 0 || grid[i][j + 1] === undefined) count++;
              if (grid[i - 1] === undefined || grid[i - 1][j] === 0 || grid[i - 1][j] === undefined) count++;
              if (grid[i + 1] === undefined || grid[i + 1][j] === 0 || grid[i + 1][j] === undefined) count++;
          }
      }
  }
  
  return count; 
};

/*

  Check the borders of every cell

  Time Complexity: O(n)
  Time Complexity: O(1)
  
  Where n is the number of cells

*/
