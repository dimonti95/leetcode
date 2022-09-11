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
  
  let unionFind = new UnionFind(n);
  let res = n;
  for (let edge of edges) {
    let n1 = edge[0];
    let n2 = edge[1];
    res -= unionFind.union(n1, n2);
  }
  
  return res;
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
    
    // path compression optimization
    while (n !== root) {
      let temp = n;
      n = this.parent[n];
      this.parent[temp] = root;
    }
    
    return root;
  }
  
  union(n1, n2) {
    let p1 = this.find(n1);
    let p2 = this.find(n2);
    
    if (p1 === p2)
      return 0;
    
    // ensure the larger set remains the root
    if (this.size[p2] >  this.size[p1]) {
      this.parent[p1] = p2;
      this.size[p2] += this.size[p1];
    }
    else {
      this.parent[p2] = p1;
      this.size[p1] += this.size[p2];
    }
    
    return 1;
  }
  
}

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
