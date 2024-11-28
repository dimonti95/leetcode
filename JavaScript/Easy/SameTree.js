/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {TreeNode} p
 * @param {TreeNode} q
 * @return {boolean}
 */
 var isSameTree = function(p, q) {
    
  if (p === null && q === null) return true;

  const invalid = (p === null && q !== null) || (p !== null && q === null) || (p.val !== q.val);
  if (invalid) return false;

  let validLeft = isSameTree(p.left, q.left);
  let validRight = isSameTree(p.right, q.right);

  return validLeft && validRight;
  
};

/*

  Recurse through both trees and validate the structure/values match
  
  Time Complexity: O(n)
  Space Complexity: O(h)
  
  Where n is the number of nodes and h is longest common height between both trees

*/



/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {TreeNode} p
 * @param {TreeNode} q
 * @return {boolean}
 */
 var isSameTree = function(p, q) {
    
  if (p === null && q === null) return true;
  if (p === null || q === null) return false;
  
  let pStack = [ p ];
  let qStack = [ q ];
  
  while (pStack.length > 0 && qStack.length > 0) {
      
      let pCurrent = pStack.pop();
      let qCurrent = qStack.pop();
      
      if (pCurrent === null && qCurrent === null) continue;
      if (pCurrent === null || qCurrent === null || pCurrent.val !== qCurrent.val) return false;
      
      pStack.push(pCurrent.left);
      qStack.push(qCurrent.left);
      
      pStack.push(pCurrent.right);
      qStack.push(qCurrent.right);
  }
  
  return true;
};

/*
  
  Iterative

*/
