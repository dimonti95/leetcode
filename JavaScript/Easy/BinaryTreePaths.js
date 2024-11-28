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
 * @return {string[]}
 */
 var binaryTreePaths = function(root) {
    
  let ans = [];
  
  let traverse = function (node, path) {
      
      if (node === null) return;
      
      if (node.left === null && node.right === null) {
          ans.push(node === root ? node.val.toString() : path + '->' + node.val.toString());
          return;
      }
      
      traverse(node.left, node === root ? node.val.toString() : path + '->' + node.val.toString());
      traverse(node.right, node === root ? node.val.toString() : path + '->' + node.val.toString());
      
  }
  
  traverse(root, '');
  
  return ans;
};

/*

  Recurse through the tree keeping a path from the root until a node with two null children is found.

  Time Complexity: O(n)
  Space Complexity: O(h)
  
  Where n is the number of nodes and h is the height of the tree.

*/
