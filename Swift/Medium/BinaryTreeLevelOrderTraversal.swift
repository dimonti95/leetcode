/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public var val: Int
 *     public var left: TreeNode?
 *     public var right: TreeNode?
 *     public init() { self.val = 0; self.left = nil; self.right = nil; }
 *     public init(_ val: Int) { self.val = val; self.left = nil; self.right = nil; }
 *     public init(_ val: Int, _ left: TreeNode?, _ right: TreeNode?) {
 *         self.val = val
 *         self.left = left
 *         self.right = right
 *     }
 * }
 */
class Solution {
    func levelOrder(_ root: TreeNode?) -> [[Int]] {
        if root == nil { return [[Int]]() }
        
        var result = [[Int]]()
        var queue = Queue<(Int, TreeNode)>()
        queue.enqueue((0, root!))

        while !queue.isEmpty() {
            if let (level, current) = queue.dequeue() {
                if (level >= result.count) 
                {
                    result.append([current.val])
                }
                else {
                    result[level].append(current.val)
                }

                if let left = current.left { queue.enqueue((level + 1, left)) }
                if let right = current.right { queue.enqueue((level + 1, right)) }
            }
        }

        return result
    }
}

class Node<T> {
    var value: T
    var next: Node?
    init(_ value: T) {
        self.value = value
    }
}

class Queue<T> {
    private var head: Node<T>?
    private var tail: Node<T>?

    init() {}

    func isEmpty() -> Bool {
        return head == nil
    }

    func enqueue(_ val: T) {
        let newNode = Node(val)
        if tail != nil {
            tail?.next = newNode
        }
        else {
            head = newNode
        }

        tail = newNode
    }

    func dequeue() -> T? {
        if let temp = head {
            head = temp.next
            if head == nil { tail = nil }
            return temp.value
        }

        return nil
    }
}

/*

    

*/
