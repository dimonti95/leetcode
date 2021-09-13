/**
 * @param {number} n
 * @return {boolean}
 */
var divisorGame = function(n) {
    return n % 2 === 0;
};

/*

  Optimal

  Time Complexity: O(1)
  Space Complexity: O(1)

*/



/**
 * @param {number} n
 * @return {boolean}
 */
var divisorGame = function(n) {
    
    let mem = {};
    
    let div = function (n) {
        if (n <= 1)  return false;
        if (mem[n]) return mem[n];

        for (let x = 0; x <= n/2; x++) {
            if (n % x === 0) {
                if (!div(n - x)) {
                    mem[n] = true;
                    return true;
                }
            }
        }
        
        mem[n] = false;
        return false;
    }
    
    return div(n, true)
};

/*

  Top-Down DP (Memoization)

  Time Complexity: O(n)
  Space Complexity: O(n)

*/
