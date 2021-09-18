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
 * @return {TreeNode}
 */
 var invertTree = function(root) {
    
  let traverse = function (node) {
      
      if (node === null) return;
      
      // swap
      let temp = node.left
      node.left = node.right
      node.right = temp;
      
      traverse(node.left);
      traverse(node.right);
      
      
  }
  
  traverse(root);
  
  return root;
  
};

/* 

  Pre-order traversal swapping

  Time Complexity: O(n)
  Space Complexity: O(1)

*/
