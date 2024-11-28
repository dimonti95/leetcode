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
 * @return {number[][]}
 */
var levelOrder = function(root) {

    let queue = [ root ];
    let ans = [];

    while (queue.length > 0) {
        let len = queue.length;
        let level = [];

        for (let i = 0; i < len; i++) {
            let node = queue.shift();    
            if (node !== null) {
                level.push(node.val);
                queue.push(node.left);
                queue.push(node.right);
            }
        }

        if (level.length > 0) ans.push(level);
    }

    return ans;
};

/*

    BFS

    Time Complexity: O(n)
    Space Complexity: O(n)

    Where n is the number of nodes in the tree

*/
