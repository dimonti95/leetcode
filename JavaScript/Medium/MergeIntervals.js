/**
 * @param {number[][]} intervals
 * @return {number[][]}
 */
var merge = function(intervals) {
  
  intervals.sort((a, b) => a[0] - b[0]);
  let res = [ intervals[0] ];
  
  for (let i = 1; i < intervals.length; i++) {
    let start = intervals[i][0];
    let end = intervals[i][1];
    let lastEnd = res[res.length - 1][1];
    
    if (start <= lastEnd)
      res[res.length - 1][1] = Math.max(lastEnd, end);
    else
      res.push([start, end]);
  }
  
  return res;
};

/*

  Time: O(n)
  Space: O(1)

*/