/**
 * @param {number[][]} edges
 * @return {number}
 */
 var findCenter = function(edges) {
    
  if (edges[0][0] === edges[1][0] || edges[0][0] === edges[1][1]) return edges[0][0]
  else return edges[0][1]
  
};

/* 

  Explanation:

  Since every edge must be touching the center node you can just check the first two edges for the common node

  Time Complexity: O(1)
  Space Complexity: O(1)

*/
