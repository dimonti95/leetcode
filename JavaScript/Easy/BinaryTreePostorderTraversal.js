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
 var postorderTraversal = function(root) {
  let result = [];
  
  let traverse = function (node) {
      if (node === null) return;
      
      traverse(node.left);
      traverse(node.right);
      result.push(node.val);
  };
  
  traverse(root);
  return result;
};

/* 

  Explanation:

  Recursive Postorder Traversal

  Postorder traversal refers to the order that each node gets visited. In a postorder traversal
  each node is visited after visitng the left and right subtrees.

  Time Complexity: O(n) where n is the number of nodes
  Space Complexity: O(n) where n is the number of nodes

*/
