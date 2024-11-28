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



/**
 * @param {number} n
 * @param {number[][]} edges
 * @return {boolean}
 */
var validTree = function(n, edges) {
    
  if (edges.length !== n - 1)
    return false;
  
  let adjList = {};
  for (let i = 0; i < n; i++)
    adjList[i] = [];
  
  for (let edge of edges) {
    let a = edge[0];
    let b = edge[1];
    adjList[a].push(b);
    adjList[b].push(a);
  }
  
  let visited = new Set();
  let dfs = function(n) {
    if(visited.has(n))
      return;
    
    visited.add(n);
    for (let neighbor of adjList[n])
      dfs(neighbor);
  }
  
  dfs(0);
  
  if (visited.size !== n)
    return false
  
  return true;
};

/*

  Approach 2
  
  Another definition for whether a graph is a tree:
  * Has exactly n-1 edges
  * The graph is fully connected

  Time: O(v)
  Space: O(v)

  v == e since the first check verifies the number of edges

*/



/**
 * @param {number} n
 * @param {number[][]} edges
 * @return {boolean}
 */
var validTree = function(n, edges) {
  
  // graph must contain n-1 edges to be a valid tree
  if (edges.length !== n - 1)
    return false;
  
  // graph must be a single connected component
  const unionFind = new UnionFind(n);
  for (let edge of edges) {
    let a = edge[0];
    let b = edge[1];
    if (!unionFind.union(a, b))
      return false;
  }
  
  return true;
};

class UnionFind {
  
  constructor(n) {
    this.parent = new Array(n);
    this.size = new Array(n);
    for (let i = 0; i < n; i++) {
      this.parent[i] = i;
      this.size[i] = 1;
    } 
  }
  
  find(n) {
    let root = n;
    while (root !== this.parent[root]) {
      root = this.parent[root];
    }
    
    while (n !== root) {
      let oldRoot = this.parent[n];
      this.parent[n] = root;
      n = oldRoot;
    }
    
    return root;
  }
  
  union(n1, n2) {
    let p1 = this.find(n1);
    let p2 = this.find(n2);
    
    if (p1 === p2)
      return false;
    
    // ensure the larger set remains the root
    if (this.size[p2] >  this.size[p1]) {
      this.parent[p1] = p2;
      this.size[p2] += this.size[p1];
    }
    else {
      this.parent[p2] = p1;
      this.size[p1] += this.size[p2];
    }
    
    return true;
  }
}


/*

  Approach 3
  
  Use Union Find
  * Union find represents each set as a directed tree where edges point to the root
  * Union find is a DS with the following operations
    * initialize
    * find(n)
    * union(n1, n2)
  * Two nodes that are part of the same connected component have the same root
  
  Time: O(v * α(v))
  Space: O(v)
  
  * e == v since we return false if the total # of edges isn't n - 1
  * The α(v) in the time complexity comes from the find(n) function
  
  This is better than the 2nd approach since big O ignores multiplicitive constants that can impact the run-time

*/
