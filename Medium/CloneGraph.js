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
