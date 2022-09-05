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



/**
 * @param {number} n
 * @param {number[][]} edges
 * @return {number}
 */
var countComponents = function(n, edges) {
  
  // track the parent of each node
  let parent = new Array(n);
  
  // track the rank (number of connected child nodes) of each node
  let rank = new Array(n).fill(1);
  
  // initialize parent array so that each node is a parent of itself
  for (let i = 0; i < n; i++)
    parent[i] = i;
  
  /**
   * Finds the root parent of n
   */
  let find = function(n) {
    let res = n;
    
    while (res !== parent[res]) {
      parent[res] = parent[parent[res]]; // path compression optimization
      res = parent[res];
    }
    
    return res;
  }
  
  /**
   * ...
   */
  let union = function (n1, n2) {
    let p1 = find(n1);
    let p2 = find(n2);
    
    if (p1 == p2)
      return 0;
    
    // add to the larger root parent
    if (rank[p2] > rank[p1]) {
      parent[p1] = p2;
      rank[p2] += rank[p1];
    }
    else {
      parent[p2] = p1;
      rank[p1] += rank[p2]
    }
    
    return 1;
  }
  
  let res = n;
  for (let edge of edges) {
    let n1 = edge[0];
    let n2 = edge[1];
    res -= union(n1, n2);
  }
  
  return res;
};

/*

  Union find (DSU - Disjoint Set Union)
  * Start with n different trees (each node is a parent of itself)
  * For each edge we connect those two nodes and decremenet the # of connected components by 1
    * We only decrement if the two nodes aren't already connected
    * The find algorithm finds the root of a given node
  * The parent map tracks the parent of each node
  * The rank map tracks the size of the tree from that node
  
  Time: O(e)
  Space: O(v)
  
  Note: See Solution for LC 261: Graph Valid Tree for a breakdown on how Union Find works

  ---------------------------------------
  
  Example: n = 5, edges = [[0,1],[1,2],[3,4]]
  
  Iteration 0:
    parent = [0,1,2,3,4]
    rank = [1,1,1,1,1]
  
  Iteration 1: edge = 0,1
    p1 = 0
    p2 = 1
    parent = [0,0,2,3,4]
    rank = [2,1,1,1,1]
  
  Iteration 2: edge = 1,2
    p1 = 0
    p2 = 2
    parent = [0,0,0,3,4]
    rank = [3,1,1,1,1]
    
  Iteration 3: edge = 3,4
    p1 = 3
    p2 = 4
    parent = [0,0,0,3,3]
    rank = [3,1,1,2,1]

*/
