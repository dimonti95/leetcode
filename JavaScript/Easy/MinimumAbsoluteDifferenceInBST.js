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
 var getMinimumDifference = function(root) {
    
  let ans = Number.MAX_SAFE_INTEGER;
  let prev = ans;
  
  let traverse = function(node) {
      if (node === null) return;
      traverse(node.left);
      const diff = Math.abs(prev - node.val);
      if (diff < ans) ans = diff;
      prev = node.val;
      traverse(node.right);
  }
  
  traverse(root);
  
  return ans;
};

/*

  Do an in-order traversal of the BST and compare the difference between the current and previous node with the current minimum,
  keeping the smaller of the two values to be the answer.
  
  Time Complexity: O(n)
  Space Complexity: O(h)

  Where n is the number of nodes and h is the height of the tree.

*/
