/**
 * @param {string[]} words
 * @return {string}
 */
var alienOrder = function(words) {
    
  const adjList = {};
  for (let word of words)
    for (let c of word)
      adjList[c] = [];
  
  // build adjacency list
  for (let i = 1; i < words.length; i++) {
    let word1 = words[i - 1];
    let word2 = words[i];
    let minLength = Math.min(word1.length, word2.length);
    
    // edge case check for invalid ordering
    if (word1.length > word2.length && word1.startsWith(word2))
        return "";
    
    for (let j = 0; j < minLength; j++) {
      let c1 = word1.charAt(j);
      let c2 = word2.charAt(j);
      if (c1 !== c2) {
        adjList[c2].push(c1); // point edges in opposite direction
        break;
      }
    }
  }
  
  let res = "";
  const visited = {}; // true=visted, false=current path
  let dfs = function(node) {
    if (node in visited)
      return visited[node];
  
    visited[node] = false;
    for(let neighbor of adjList[node]) {
      if (!dfs(neighbor))
        return false;
    }
    res += node;
    visited[node] = true;
    return true;
  }
  
  for (let key in adjList)
    if (!dfs(key))
      return "";
  
  return res;
};

/*
  
  Topological Sort
  1. Loop for every pair of adjacent words and find the first character that differs
  2. Create a directed edge between those two characters and build a graph
  3. The direction of the edges should be reversed so that a post-order traversal returns the right order
  4. Run a DFS that checks for cycles using graph coloring
  
  Graph coloring:
  unvisited = white
  current path = grey
  visited = black

  undefined = white
  false = grey
  true = visited
  
  Time: O(c) - Where c is the total # of characters
  Space: O(1) or O(u + min(u^2,N)) - Since u is fixed at 26
  
  Where u is the total # of unique characters and N is the total number of words
  * There are N - 1 pairs of adjacent words

*/
