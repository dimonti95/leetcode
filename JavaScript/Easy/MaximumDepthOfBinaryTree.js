/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {TreeNode} root
 * @return {number}
 */
 var maxDepth = function(root) {
    
  if (root === null) return 0;
  
  let leftDepth = maxDepth(root.left) + 1;
  let rightDepth = maxDepth(root.right) + 1;
  
  return Math.max(leftDepth, rightDepth);
};

/*

  Recursive DFS keeping count of max depth from the root node
  
  Time Complexity: O(n)
  Space Complexity: O(h)
  
  Where n is the number of nodes in the tree and h is the max height

*/
