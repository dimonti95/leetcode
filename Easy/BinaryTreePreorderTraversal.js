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
 * @return {number[]}
 */
 var preorderTraversal = function(root) {
  let result = [];
  
  let traverse = function (root) {
      if (root === null) return;
      
      result.push(root.val);
      traverse(root.left);
      traverse(root.right);
  }
  
  traverse(root);
  return result;
};

/* 

  Explanation:

  Recursive Preorder Traversal

  Preorder traversal refers to the order that each node gets visited. In a preorder traversal
  the node is visited before visitng the left and right subtrees.

  Time Complexity: O(n) where n is the number of nodes
  Space Complexity: O(n) where n is the number of nodes

*/
