/**
 * @param {number} m
 * @param {number} n
 * @return {number}
 */
var uniquePaths = function(m, n, mem = {}) {
  let key = [m,n].toString();
  if (key in mem)
    return mem[key];
  if (m === 0 || n === 0)
    return 0;
  if (m === 1 && n === 1)
    return 1;
  
  mem[key] = uniquePaths(m - 1, n, mem) + uniquePaths(m, n - 1, mem);
  return mem[key];
};

/*

  Non-memoized
  Time: O(2^n+m)
  Space: O(n+m)

  Memoized - Top down
  Time: O(n*m)
  Space: O(n+m)
  
*/



/**
 * @param {number} m
 * @param {number} n
 * @return {number}
 */
 var uniquePaths = function(m, n) {
  
  const table = new Array(m + 1)
    .fill()
    .map(() => new Array(n + 1).fill(0));
  table[1][1] = 1;
  
  for (let r = 0; r <= m; r++) {
    for (let c = 0; c <= n; c++) {
      if (r + 1 <= m) table[r + 1][c] += table[r][c];
      if (c + 1 <= n) table[r][c + 1] += table[r][c];
    }
  }
  
  return table[m][n];
};


/*
     Tabulation - Bottom up
     
     Time: O(m*n)
     Space: O(m*n)
 
*/
