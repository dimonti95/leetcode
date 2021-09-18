/**
 * Definition for a binary tree node.
 * function TreeNode(val) {
 *     this.val = val;
 *     this.left = this.right = null;
 * }
 */

/**
 * @param {TreeNode} root
 * @param {TreeNode} p
 * @param {TreeNode} q
 * @return {TreeNode}
 */
 var lowestCommonAncestor = function(root, p, q) {
    
  if (root.val > p.val && root.val > q.val) return lowestCommonAncestor(root.left, p, q);
  if (root.val < p.val && root.val < q.val) return lowestCommonAncestor(root.right, p, q);
  
  return root;
};


/*

  Starting from the root, while the current node is larger than both p and q, traverse down the tree left.
  Otherwise if the current node is smaller than both p and q traverse right. Return the first node found 
  that's not larger than both p and q or smaller than both p and q.
  
  
  Time Complexity: O(h)
  Space Complexity: O(h)
  
  Where h is the height of the tree.

*/
