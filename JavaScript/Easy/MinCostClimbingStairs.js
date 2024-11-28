/**
 * @param {number[]} cost
 * @return {number}
 */
 var minCostClimbingStairs = function(cost) { 
    
  let min1 = 0;
  let min2 = 0;
  for (let i = 0; i < cost.length; i++) {
      let current = cost[i] + Math.min(min1, min2);
      min1 = min2
      min2 = current;
  }
  
  return Math.min(min1, min2);
};

/*
          
  Iterative bottom-up
  
  Time Complexity: O(n)
  Space Complexity: O(1)
  
  where n is the size of the cost array
  
  Example: [0, 2, 2, 1]
  
  1.  current = 0 + min(0,0)  min1 = 0, min2 = 0
  2.  current = 2 + min(0,0)  min1 = 0, min2 = 0
  3.  current = 2 + min(0,2)  min1 = 0, min2 = 2
  4.  current = 1 + min(2,2)  min1 = 2, min2 = 3
  return min(2, 3)
  = 2
  
*/



/**
 * @param {number[]} cost
 * @return {number}
 */
var minCostClimbingStairs = function(cost) {
 
    let mem = {};
    
    let minClimb = function (i) {
        
        if (i > cost.length - 1) return 0;
        if (mem[i]) return mem[i];
        
        mem[i] = Math.min(minClimb(i + 1) + cost[i], minClimb(i + 2) + cost[i]);
        return mem[i];
        
    }
    
    return Math.min(minClimb(0), minClimb(1));
    
};

/*
    
    Top-down DP
    
    Time Complexity: O(n)
    Space Complexity: O(n)

    where n is the size of the cost array

*/