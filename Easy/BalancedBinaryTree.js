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
};

/* 
  
  Standard Top-Down recursion

  Starting from the root node, make recursive calls to get the heights of the left and right subtrees of every node.
  If the difference in height between the two subtrees is less than or equal to 1 then continue down the tree until either a 
  subtree is found that isn't height balanced or all sub-trees have been checked.

  Time Complexity: O(n^2) where n is the number of nodes
  Space Complexity: O(h) where h is the height of the tree

*/

