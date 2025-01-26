class Solution {
    func validTree(_ n: Int, _ edges: [[Int]]) -> Bool {
        var adjList = [Int: [Int]]()
        for edge in edges {
            let n1 = edge[0]
            let n2 = edge[1]
            adjList[n1, default: []].append(n2)
            adjList[n2, default: []].append(n1)
        }

        var visited = Set<Int>()
        func dfs(_ node: Int, _ parent: Int) -> Bool {
            if visited.contains(node) { return true }
            visited.insert(node)

            if let neighbors = adjList[node] {
                for neighbor in neighbors {
                    if neighbor != parent && dfs(neighbor, node) { return true }
                }
            }

            return false
        }

        if dfs(0, -1) { return false }

        return visited.count == n
    }
}

/*

    A graph is a valid tree if
    1. It does not contain cycles
    2. It is connected
    3. It has exactly n - 1 edges

    --------------------------------------------------------------------------------------

    Solution 1: Use properties 1 and 2 to determine whether the tree is a graph
    * Build an adj list from the input
    * Run a graph traversal algorithm (DFS or BFS) on the undirected graph to check for cycles
        - Avoid trivial cycles by keeping track of the parent
        - Check for cycles by using a set
    * Ensure that every node has been visited at least once
    
    Time: O(v + e)
    Space: O(v + e)

*/



class Solution2 {
    func validTree(_ n: Int, _ edges: [[Int]]) -> Bool {
        if edges.count != n - 1 { return false }
        
        var adjList = [Int: [Int]]()
        for edge in edges {
            let n1 = edge[0]
            let n2 = edge[1]
            adjList[n1, default: []].append(n2)
            adjList[n2, default: []].append(n1)
        }

        var visited = Set<Int>()
        func dfs(_ node: Int) {
            if visited.contains(node) { return }
            visited.insert(node)

            if let neighbors = adjList[node] {
                for neighbor in neighbors {
                    dfs(neighbor)
                }
            }
        }

        dfs(0)
        return visited.count == n
    }
}

/*

    A graph is a valid tree if
    1. It does not contain cycles
    2. It is connected
    3. It has exactly n - 1 edges

    --------------------------------------------------------------------------------------

    Solution 2: Use properties 2 and 3 to determine whether the tree is a graph using DFS
    
    Time: O(v + e)
    Space: O(v + e)

*/



class Solution {
    func validTree(_ n: Int, _ edges: [[Int]]) -> Bool {
        if edges.count != n - 1 { return false }
        
        var unionFind = UnionFind(n: n)
        for edge in edges {
            let n1 = edge[0]
            let n2 = edge[1]
            if unionFind.union(n1, n2) { return false }
        }

        return true
    }
}

class UnionFind {

    var parent: [Int]

    init(n: Int) {
        self.parent = Array(0..<n)
    }

    func find(_ n: Int) -> Int {
        var n = n
        while n != parent[n] {
            n = parent[n]
        }

        return n
    }

    func union(_ n1: Int, _ n2: Int) -> Bool {
        var parent1 = find(n1)
        var parent2 = find(n2)

        if parent1 == parent2 { return true }
        parent[parent1] = parent2

        return false
    }   
}

/*

    Solution 3: Use properties 2 and 3, check property 2 using union find rather than graph traversal

    Note: This is Union Find without the Path Compression optimization

*/