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
 var maxPathSum = function(root) {
    
    let res = root.val;
    
    let dfs = function (node) {
        
        if (node === null) return 0;
        
        let leftMax = dfs(node.left);
        let rightMax = dfs(node.right);
        leftMax = Math.max(leftMax, 0);
        rightMax = Math.max(rightMax, 0);
        
        res = Math.max(res, node.val + leftMax + rightMax);
        
        return node.val + Math.max(leftMax, rightMax);
    }
    
    dfs(root);
    
    return res;
};

/*

    DFS traversal checking for current max of split at each node

    The base case is the leaf nodes

    Do two things at every node:
    (1) Get the sum if the path split at that node
    (2) Return the max if the path crossed through that node
    
    Time: O(n)
    Space: O(h)

*/
