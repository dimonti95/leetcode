/**
 * Definition for a binary tree node.
 * function TreeNode(val) {
 *     this.val = val;
 *     this.left = this.right = null;
 * }
 */

/**
 * Encodes a tree to a single string.
 *
 * @param {TreeNode} root
 * @return {string}
 */
var serialize = function(root) {
    
  if (!root)
    return 'N';
  
  let left = serialize(root.left);
  let right = serialize(root.right);
  
  return root.val + ',' + left + ',' + right;
};

/**
 * Decodes your encoded data to tree.
 *
 * @param {string} data
 * @return {TreeNode}
 */
var deserialize = function(data) {
  
  let vals = data.split(',');
  let i = 0;
  
  let dfs = function() {
    let c = vals[i];
    
    if (c === 'N') {
      i += 1;
      return null;
    } 
    
    let node = new TreeNode(parseInt(c));
    i += 1;
    node.left = dfs();
    node.right = dfs();
    
    return node;
  }
  
  return dfs();
  
};

/**
 * Your functions will be called as such:
 * deserialize(serialize(root));
 */


/*

  Serialize
  Time: O(n)
  Space: O(h)
  
  Deserialize
  Time: O(n)
  Space: O(h)

*/
