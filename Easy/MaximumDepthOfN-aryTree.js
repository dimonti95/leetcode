/**
 * // Definition for a Node.
 * function Node(val,children) {
 *    this.val = val;
 *    this.children = children;
 * };
 */

/**
 * @param {Node|null} root
 * @return {number}
 */
 var maxDepth = function(root) {
    
  let max = 0;
  
  let traverse = function (node, depth) {
      
      if (node === null) return;
      
      if (node.children.length === 0 && depth > max) {
          max = depth;
          return;
      }
      
      for (let child of node.children) {
          traverse(child, depth + 1);
      }
      
  }
  
  traverse(root, 1);
  return max;
};

/*

  Traverse the tree keeping a count of the depth and check if a new max depth is found at every leaf (Depth First Search).
  
  Time Complexity: O(n)
  Space Complexity: O(h)
  
  Where n is the number of nodes in the tree and h is the height of the tree.

*/



/**
 * // Definition for a Node.
 * function Node(val,children) {
 *    this.val = val;
 *    this.children = children;
 * };
 */

/**
 * @param {Node|null} root
 * @return {number}
 */
 var maxDepth = function(root) {
    
  if (root === null) return 0;
  
  let queue = [ root ];
  let depth = 0;
  
  while (queue.length > 0) {
      let size = queue.length;
      
      for (let i = 0; i < size; i++) {
          let current = queue.shift();
          for (let child of current.children) {
              queue.push(child);
          }
      }
      depth++;
  }
  
  return depth;
  
};

/*

  Traverse the tree keeping track of the current depth (Breadth First Search).
  
  Time Complexity: O(n)
  Space Complexity: O(n)
  
  Where n is the number of nodes in the tree.

*/
