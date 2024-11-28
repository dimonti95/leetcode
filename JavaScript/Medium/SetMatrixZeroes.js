/**
 * @param {number[][]} matrix
 * @return {void} Do not return anything, modify matrix in-place instead.
 */
var setZeroes = function(matrix) {
  
  let nRows = matrix.length;
  let nCols = matrix[0].length;
  let rowZero = false;
  
  for (let r = 0; r < nRows; r++) {
    for (let c = 0; c < nCols; c++) {
      if (matrix[r][c] === 0) {
        matrix[0][c] = 0;
        if (r > 0)
          matrix[r][0] = 0;
        else
          rowZero = true;
      }
    }
  }
  
  for (let r = 1; r < nRows; r++) {
    for (let c = 1; c < nCols; c++) {
      if (matrix[0][c] === 0 || matrix[r][0] === 0)
        matrix[r][c] = 0;
    }
  }
  
  if (matrix[0][0] === 0) {
    for (let r = 0; r < nRows; r++) {
      matrix[r][0] = 0;
    }
  }
  
  if (rowZero) {
    for (let c = 0; c < nCols; c++) {
      matrix[0][c] = 0;
    }
  }
  
  return matrix;
};

/*

  Use the first row/col to track rows/cols that should be set to 0s
  
  Time: O(m*n)
  Space: O(1)

*/
