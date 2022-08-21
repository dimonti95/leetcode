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

  Memoized
  Time: O(n*m)
  Space: O(n+m)
  
*/
