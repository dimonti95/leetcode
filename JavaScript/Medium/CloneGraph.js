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
    
    Time Complexity: O(n + e)
    Space Compelxity: O(n)

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
  map[node.val] = new Node(node.val);
  
  while (stack.length > 0) {
    let current = stack.pop();
    let copy = map[current.val];
    
    for (let neighbor of current.neighbors) {
      if (!map[neighbor.val]) {
        map[neighbor.val] = new Node(neighbor.val);
        stack.push(neighbor);
      }
      let temp = map[neighbor.val];
      copy.neighbors.push(temp);
    }
  }
  
  return map[node.val];
};

 /*
	
	Iterative DFS
  
  	Time: O(n + e)
	Space: O(n)

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
  
  let copyMap = {};
  let queue = [ node ];
  copyMap[node.val] = new Node(node.val);
  
  while (queue.length > 0) {
    let current = queue.shift()
    
    for (let neighbor of current.neighbors) {
      if (neighbor.val in copyMap) {
        copyMap[current.val].neighbors.push(copyMap[neighbor.val]);
      }
      else {
        copyMap[neighbor.val] = new Node(neighbor.val);
        copyMap[current.val].neighbors.push(copyMap[neighbor.val]);
        queue.push(neighbor);
      }
    }
  }
  
  return copyMap[node.val];
};

/*

  BFS
  
  Time: O(n + e)
  Space: O(n)

*/