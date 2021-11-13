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
 * @param {TreeNode} subRoot
 * @return {boolean}
 */
 var isSubtree = function(root, subRoot) {
    
    if (subRoot === null) return true;
    if (root === null) return false;
    
    if (sameTree(root, subRoot) === true) return true;

    return isSubtree(root.left, subRoot) || isSubtree(root.right, subRoot);
};

let sameTree = function (node1, node2) {
    if (node1 === null && node2 === null) return true;
    if (node1 === null || node2 === null || node1.val !== node2.val) return false
        
    let leftSame = sameTree(node1.left, node2.left);
    let rightSame = sameTree(node1.right, node2.right);
    
    return leftSame && rightSame;
}

/*

    Check for if subRoot is a subtree at every node
    
    Time: O(m * n)

*/
