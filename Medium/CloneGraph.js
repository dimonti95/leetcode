/**
 * // Definition for a Node.
 * function Node(val, neighbors) {
 *    this.val = val === undefined ? 0 : val;
 *    this.neighbors = neighbors === undefined ? [] : neighbors;
 * };
 */

/**
 * @param {Node} node
 * @return {Node}
 */
 var cloneGraph = function(node) {
    
    if (node === null) return null;

	let map = {};

	const dfsClone = function(node) {
		
		if (map[node.val] !== undefined) return map[node.val];
		
		let copy = new Node(node.val);
		map[node.val] = copy;

		for (let neighbor of node.neighbors) {
            let temp = dfsClone(neighbor)
			copy.neighbors.push(temp);
		}

		return copy;
	}

	return dfsClone(node);
};

/*

    Recursive DFS
    
    Time Complexity: O(v + e)
    Space Compelxity: O(v)

*/



/**
 * // Definition for a Node.
 * function Node(val, neighbors) {
 *    this.val = val === undefined ? 0 : val;
 *    this.neighbors = neighbors === undefined ? [] : neighbors;
 * };
 */

/**
 * @param {Node} node
 * @return {Node}
 */
var cloneGraph = function(node) {
  
  if (!node)
    return null;
  
  let map = {};
  let stack = [ node ];
  let visited = new Set([ node.val ]);
  map[node.val] = new Node(node.val);
  
  while (stack.length > 0) {
    let current = stack.pop();
    let copy = map[current.val];
    
    for (let neighbor of current.neighbors) {
      if (!map[neighbor.val])
        map[neighbor.val] = new Node(neighbor.val);
      let temp = map[neighbor.val];
      copy.neighbors.push(temp);
      if (!visited.has(neighbor.val)) {
        stack.push(neighbor);
        visited.add(neighbor.val);
      }
    }
  }
  
  return map[node.val];
};

 /*
	
	Iterative DFS
  
  	Time: O(v + e)
	Space: O(v)

  */

