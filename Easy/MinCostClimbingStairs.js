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

*/