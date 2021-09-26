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
 var sumOfLeftLeaves = function(root) {
    
  let sum = 0;
  
  let traverse = function (node, isLeft) {
      
      if (node === null) return; 
  
      if (node.left === null && node.right === null && isLeft === true) sum += node.val;
      
      traverse(node.left, true);
      traverse(node.right, false);    
  }
  
  traverse(root, false);
  
  return sum;
};

/*

  Recurse through the tree keeping track of whether the node is a left or right child and
  track the sum of all left leaves.
  
  Time Complexity: O(n)
  Space Complexity: O(h)
  
  Where n is the number of nodes and h is the height of the tree.

*/
