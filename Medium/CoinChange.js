/**
 * @param {number[]} coins
 * @param {number} amount
 * @return {number}
 */
var coinChange = function(coins, amount) {
  
  if (amount < 0)
    return -1;
  if (amount === 0)
    return 0;
  
  let minCount = Number.MAX_SAFE_INTEGER;
  for (let coin of coins) {
    let count = coinChange(coins, amount - coin);
    if (count === -1)
      continue;
    minCount = Math.min(minCount, count + 1);
  }
  
  return minCount === Number.MAX_SAFE_INTEGER ? -1 : minCount;
};
 
/*

  Brute Force (non-memoized)

  Time: O(c^n)
  Space: O(n)

  Where 
  c = the number of coins
  n = the target amount

*/



/**
 * @param {number[]} coins
 * @param {number} amount
 * @return {number}
 */
var coinChange = function(coins, amount, mem = {}) {
  
  if (amount in mem)
    return mem[amount];
  if (amount < 0)
    return -1;
  if (amount === 0)
    return 0;
  
  let minCount = Number.MAX_SAFE_INTEGER;
  for (let coin of coins) {
    let count = coinChange(coins, amount - coin, mem);
    if (count === -1)
      continue;
    minCount = Math.min(minCount, count + 1);
  }
  mem[amount] = minCount === Number.MAX_SAFE_INTEGER ? -1 : minCount;
  
  return mem[amount];
};
 
/*

  Memoized DP (top-down)

  Time: O(n * c)
  Space: O(n)

  Where
  c = the number of coins
  n = the target amount

*/
