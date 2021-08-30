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
 * @return {boolean}
 */
 var isBalanced = function(root) {
  if (root === null) return true; 
      
  let leftHeight = getHeight(root.left);
  let rightHeight = getHeight(root.right);
  
  if (Math.abs(leftHeight - rightHeight) <= 1 && isBalanced(root.left) && isBalanced(root.right)) return true;
  
  return false;
  
};

let getHeight = function(node) {
  if (node === null) return 0;
  
  let leftHeight = getHeight(node.left);
  let rightHeight = getHeight(node.right);
  
  return Math.max(leftHeight, rightHeight) + 1;
  
}
