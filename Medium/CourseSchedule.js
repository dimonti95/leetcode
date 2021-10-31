/**
 * @param {number} numCourses
 * @param {number[][]} prerequisites
 * @return {boolean}
 */
 var canFinish = function(numCourses, prerequisites) {
    
	let adjList = {};
    let visited = new Set();
    let visiting = new Set();
    for (let i = 0; i < numCourses; i++) adjList[i] = [];
	for (let edge of prerequisites) {
		let [node1, node2] = edge;
		adjList[node1].push(node2);
	}

    let containsCycle = function(node) {
        if (visited.has(node)) return false;
        if (visiting.has(node)) return true;
        
        visiting.add(node);
        
        for (let neighbor of adjList[node]) {
            if (containsCycle(neighbor)) return true;
        }
        
        visiting.delete(node);
        visited.add(node);
        return false;
    }
    
    
	for (let node in adjList) {
        if (containsCycle(node)) return false;
    }
    
    return true;
};

/*

    DFS - check for cycle

    Traverse all the children of a node first.
    Once done traversing all the children of a particular node, and there are no cycles, then mark the node as visited.

    Time Complexity: O(v + e)
    Space Complexity: O(v + e)

*/
