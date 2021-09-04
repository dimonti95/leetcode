/**
 * @param {number} n
 * @param {number[][]} edges
 * @param {number} start
 * @param {number} end
 * @return {boolean}
 */
 var validPath = function(n, edges, start, end) {
    
  let graph = buildGraph(edges);
  
  // dfs
  let stack = [ start ];
  let visited = new Set();

  while(stack.length > 0) {
      let curr = stack.pop();
      if (visited.has(curr)) continue;
      visited.add(curr);
      if (curr === end) return true;
  
      graph[curr].forEach(neighbor => {
          stack.push(neighbor);
      });
  }
  
  return false;
  
};

let buildGraph = function (edges) {
  const graph = {};
  
  for (let edge of edges) {
      const [a, b]  = edge;
      if (!(a in graph)) graph[a] = [];
      if (!(b in graph)) graph[b] = [];
      graph[a].push(b);
      graph[b].push(a);
  }
  
  return graph;
};

/* 

  Explanation:

  Convert edge list to an adjacency list then do iterative DFS on undirected cyclic graph

  Time Complexity: O(n^2)
  Space Complexity: O(n)

  where n is the number of nodes

*/
