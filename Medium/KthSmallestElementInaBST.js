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
 * @param {number} k
 * @return {number}
 */
 var kthSmallest = function(root, k) {
    
    let inorderArray = [];

	let inorder = function (node) {
		
		if (node === null) return;

		inorder(node.left);
		inorderArray.push(node.val);
		inorder(node.right);
	}
    
	inorder(root);
    return inorderArray[k - 1];
};

/*

    Inorder traversal - create an inorder array and return that value.

    Time: O(n)
    Space:  O(n)

*/
