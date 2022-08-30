/**
 * @param {number} n
 * @param {number[][]} edges
 * @return {number}
 */
var countComponents = function(n, edges) {
  
  const adjList = {};
  for (let i = 0; i < n; i++)
    adjList[i] = [];
  
  for (let edge of edges) {
    let a = edge[0];
    let b = edge[1];
    adjList[a].push(b);
    adjList[b].push(a);
  }
  
  const set = new Set();
  let dfs = function(node) {
    if (set.has(node))
      return;
    
    set.add(node);
    for (let child of adjList[node]) {
      dfs(child);
    }
  }
  
  let count = 0;
  for (let i = 0; i < n; i++) {
    if (!set.has(i)) {
      dfs(i);
      count += 1;
    }
  }
  
  return count;
};

/*

  DFS
  
  Time: O(e + v)
  Space: O(e + v)

*/
