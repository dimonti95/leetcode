/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {number[]} preorder
 * @param {number[]} inorder
 * @return {TreeNode}
 */
 var buildTree = function(preorder, inorder) {
    
    if (preorder.length === 0 || inorder.length === 0) return null;
    
    let root = new TreeNode(preorder[0]);
    let middle = inorder.indexOf(preorder[0]);
    root.left = buildTree(preorder.slice(1, middle + 1), inorder.slice(0, middle));
    root.right = buildTree(preorder.slice(middle + 1), inorder.slice(middle + 1));
    
    return root;
};

/*

    The first preorder value is always the root. Split inorder at the index where that value is at.
    
    Example:
    preorder: [3,9,20,15,7]
    inorder: [9,3,15,20,7]
    
    inorder splts at 3 to: 
    left subtree nodes -> [9]
    right subtree ndoes -> [15,20,7]

    remaining preorder array gets split:
    [9]
    [20,15,7]
    
    20 is the next first preorder node

    Time: O(n)
    Space: O(n)

*/
