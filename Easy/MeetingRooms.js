/**
 * @param {number[][]} intervals
 * @return {boolean}
 */
var canAttendMeetings = function(intervals) {
  
  intervals.sort((a,b) => a[0] - b[0]);
  
  for (let i = 1; i < intervals.length; i++) {
    let interval1 = intervals[i - 1];
    let interval2 = intervals[i];
    if (interval1[1] > interval2[0])
      return false;
  }
    
  return true;
};

/*

  Approach 2:

  Sort based on start value and check if the end value exceeds the start of the next interval

  Time: O(nlogn)
  Space: O(1)

*/
