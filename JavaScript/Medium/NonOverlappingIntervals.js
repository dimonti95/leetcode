/**
 * @param {number[][]} intervals
 * @return {number}
 */
var eraseOverlapIntervals = function(intervals) {
  
  // sort by start value then end value
  intervals.sort((a,b) => a[0] - b[0]);
  intervals.sort((a,b) => a[1] - b[1]);
  
  let res = 0;
  let prevEnd = intervals[0][1];
  for (let i = 1; i < intervals.length; i++) {
    let start = intervals[i][0];
    let end = intervals[i][1];
    
    if (start < prevEnd)
      res += 1;
    else
      prevEnd = end;
  }
   
  return res;
};

/*

  Order by start then end value so that the smaller (interval) of two intervals with the same start value comes first

  Time: O(nlogn)
  Space: O(1)

*/
