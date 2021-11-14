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
 var isValidBST = function(root) {
    
    let valid = function(node, left, right) {
        if (node === null) return true;
        
        if (node.val <= left || node.val >= right) return false;
        
        return valid(node.left, left, node.val) && valid(node.right, node.val, right);
    }
  
    return valid(root, Math.MIN_SAFE_NUMBER, Math.MAX_SAFE_NUMBER)
};

/*

    DFS return false if out of range
    
                5   
            |       |
            1       6
                 |     |
                 3     7         
                 
    -MAX < 5 < MAX
    -MAX < 1 < 5
       5 < 6 < MAX  
       5 < 3 < 6    --- false
    
    Time: O(n)
    Space: O(h)
                 
*/