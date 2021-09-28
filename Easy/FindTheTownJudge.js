/**
 * @param {number} n
 * @param {number[][]} trust
 * @return {number}
 */
 var findJudge = function(n, trust) {
    
  // build directed adjacency list
  let adjList = {};
  for (let i = 0; i < trust.length; i++) {
      const personA = trust[i][0];
      const personB = trust[i][1];
      adjList[personA] ? adjList[personA].push(personB) : adjList[personA] = [ personB ];
  }
  
  let everyoneTrusts = function(person) {
      let count = 0;
  
      for (let edge of trust) {
          if (edge[1] === person) count++;
      }
  
      if (count === n - 1) return true;
      else return false;
  }
  
  for (let i = 1; i <= n; i++) {
      if ((adjList[i] === undefined || adjList[i].length === 0) && everyoneTrusts(i)) {
          return i;
      }
  }
  
  return -1;
};

/*

  Create an adjacency list from the list of edges, then loop over each node until a person is found
  who trusts no one (no outgoing edges) and who everyone trusts (every other node has an edge that
  points to that node).
  
  Time Complexity: O(n + m)
  Space Complexity: O(n + m)
  
  Where n is the number of nodes and m is the number of edges.

*/
