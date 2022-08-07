/**
 * @param {number[][]} matrix
 * @return {number[]}
 */
var spiralOrder = function(matrix) {
    
  let res = [];
  let top = 0;
  let bottom = matrix.length;
  let left = 0;
  let right = matrix[0].length;
  
  while (left < right && top < bottom) {
    // top
    for (let i = left; i < right; i++)
      res.push(matrix[top][i]);
    top += 1;
    
    // right
    for (let i = top; i < bottom; i++)
      res.push(matrix[i][right - 1]);
    right -= 1;
    
    if (left >= right || top >= bottom)
      break;
    
    // bottom
    for (let i = right - 1; i >= left; i--)
      res.push(matrix[bottom - 1][i]);
    bottom -= 1;
    
    // left
    for (let i = bottom - 1; i >= top; i--)
      res.push(matrix[i][left]);
    left += 1;
  }
  
  return res;
};

/*

  Time: O(m*n)
  Space: O(1)
  
  Edge cases:
  * A matrix with a single column
  * A matrix with a single row

*/
