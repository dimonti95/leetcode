/**
 * @param {number} n
 * @return {number}
 */
 var climbStairs = function(n) {  
  let map = {};
  
  let recurse = function (x) {
      if (map[x]) return map[x];
      if (x >= n) return x === n ? 1 : 0;
      
      map[x] = recurse(x + 1) + recurse(x + 2);
      return map[x];
  };
  
  return recurse(0);
};

/*

  Explanation:
  
  Recursive memoized DP
  
  Time Complexity: O(n)
  Space Complexity: O(n)

  where n is the number of steps

*/



/**
 * @param {number} n
 * @return {number}
 */
 var climbStairs = function(n) {  
  
  const table = new Array(n + 1).fill(0);
  table[0] = 1;
  for (let i = 0; i < n; i++) {
    table[i + 1] += table[i];
    table[i + 2] += table[i];
  }
  
  return table[n];
};

/*

  Tabulation (bottom-up)
  Time: O(n)
  Space: O(n)
  
*/



/**
 * @param {number} n
 * @return {number}
 */
 var climbStairs = function(n) {  
    
  let n1 = 0;
  let n2 = 1;
  
  while (n > 0) {
      let temp = n2;
      n2 = n1 + n2;
      n1 = temp;
      n--;
  }
  
  return n2;
};

/*
  Explanation:
  
  Bottom up DP
  
  Time Complexity: O(n)
  Space Complexity: O(1)
  
  where n is the number of stairs
  
*/
