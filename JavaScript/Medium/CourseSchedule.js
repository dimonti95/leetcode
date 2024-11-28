/**
 * @param {number} numCourses
 * @param {number[][]} prerequisites
 * @return {boolean}
 */
 var canFinish = function(numCourses, prerequisites) {
    
    let adjList = {};
    for (let i = 0; i < numCourses; i++) adjList[i] = [];
    for (let pre of prerequisites) {
        const crs1 = pre[0];
        const crs2 = pre[1];
        adjList[crs1].push(crs2);
    }
    
    let visited = new Set();
    let dfs = function (course) {
        if (visited.has(course)) return false;
        if (adjList[course] === []) return true;
        
        visited.add(course);
        for (let neighbor of adjList[course]) {
            if (dfs(neighbor) === false) return false;
        }
        visited.delete(course);
        adjList[course] = [];
        return true;
    }
    
    for (let i = 0; i < numCourses; i++) {
        if (dfs(i) === false) return false;
    }
    
    return true;
};

/*

    DFS - check for cycle

    Time Complexity: O(v + e)
    Space Complexity: O(v + e)

*/
