/**
 * @param {number[][]} intervals
 * @param {number[]} newInterval
 * @return {number[][]}
 */
var insert = function(intervals, newInterval) {
  let res = [];
  
  for (let i = 0; i < intervals.length; i++) {
    if (newInterval[1] < intervals[i][0]) {
      res.push(newInterval); 
      return res.concat(intervals.slice(i));
    }
    else if (newInterval[0] > intervals[i][1]) {
      res.push(intervals[i]);
    }
    else {
      // overlap
      let start = Math.min(newInterval[0], intervals[i][0]);
      let end = Math.max(newInterval[1], intervals[i][1]);
      newInterval = [start, end];
    } 
  }
  
  res.push(newInterval);
  
  return res;
};

/*

  Time: O(n)
  Space: O(n) 

*/