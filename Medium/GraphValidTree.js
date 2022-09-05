/**
 * @param {number} n
 * @param {number[][]} edges
 * @return {boolean}
 */
var validTree = function(n, edges) {
    
  const adjList = {};
  for (let i = 0; i < n; i++)
    adjList[i] = [];
  for (let edge of edges) {
    let a = edge[0];
    let b = edge[1];
    adjList[a].push(b);
    adjList[b].push(a);
  }
  
  // remove from array helper
  let remove = function(arr, val) {
    var index = arr.indexOf(val);
    if (index !== -1) {
      arr.splice(index, 1);
    }
  }
  
  const stack = [ 0 ];
  const visited = new Set([ 0 ]);
  while (stack.length > 0) {
    let current = stack.pop();
    
    for (let neighbor of adjList[current]) {
      if (visited.has(neighbor))
        return false;
      stack.push(neighbor);
      visited.add(neighbor);
      remove(adjList[neighbor], current);
    }
  }
  
  // make sure the graph is connected
  if (visited.size !== n)
    return false;
  
  return true;
};

/*

  Approach 1
  * The graph is a vaid tree iff there are no cycles and the graph is connected
  * Traverse the tree (DFS in this solution)
  * Since the graph is undirected the parent node of each neighbor gets removed
  
  Time: O(v + e)
  Space: O(v + e)

*/
