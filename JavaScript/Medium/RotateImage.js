/**
 * @param {number[][]} matrix
 * @return {void} Do not return anything, modify matrix in-place instead.
 */
var rotate = function(matrix) {
    
  let left = 0;
  let right = matrix.length - 1;

  while (left < right) {
    for (let i = 0; i < right - left; i++) {
      let top = left;
      let bottom = right;
      
      // Save top left value
      let topLeft = matrix[top][left + i];
      
      // move bottom left into top left
      matrix[top][left + i] = matrix[bottom - i][left];
      
      // move bottom right into bottom left
      matrix[bottom - i][left] = matrix[bottom][right - i];
      
      // move top right into bottom right
      matrix[bottom][right - i] = matrix[top + i][right];
      
      // move top left to top right
      matrix[top + i][right] = topLeft;
    }
    right -= 1;
    left += 1;
  }

  return matrix;
};

/*

  Time: O(n^2)
  Space: O(1)
  
  Keep top, left, right, and bottom pointers

*/