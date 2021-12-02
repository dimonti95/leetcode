/**
 * @param {number} numCourses
 * @param {number[][]} prerequisites
 * @return {number[]}
 */
 var findOrder = function(numCourses, prerequisites) {
    
    let adjList = {};
    for (let course = 0; course < numCourses; course++) adjList[course] = [];
    for (let prereq of prerequisites) {
        let courseA = prereq[0];
        let courseB = prereq[1];
        adjList[courseA].push(courseB);
    }
    
    let order = [];
    let visited = new Set();
    let ordered = new Set();
    let dfs = function(node) {
        
        if (visited.has(node)) return false;
        visited.add(node);
        
        for (let neighbor of adjList[node]) {
            if (!dfs(neighbor)) return false;
        }
        
        visited.delete(node);
        adjList[node] = [];
        
        if (!ordered.has(node)) {
            order.push(node);
            ordered.add(node);
        }
        
        return true;
    }
    
    for (let course = 0; course < numCourses; course++) {
        if (!dfs(course)) return [];
    }
    
    return order;
};

/*

    Recursive DFS

    Time: O(v + e)
    Space: O(v + e)

*/
