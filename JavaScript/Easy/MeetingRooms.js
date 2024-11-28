/**
 * @param {number[][]} intervals
 * @return {boolean}
 */
var canAttendMeetings = function(intervals) {
  
  for (let i = 0; i < intervals.length; i++) {
    for (let j = i + 1; j < intervals.length; j++) {
      let minEnd = Math.min(intervals[i][1], intervals[j][1]);
      let maxStart = Math.max(intervals[i][0], intervals[j][0]);
      if (minEnd > maxStart)
        return false;
    }
  }
  
  return true;
};

/*

  Approach 1:
  
  Brute force nested for loop
  
  Check for overlap between two non-sorted intervals by comparing the minimum end time with the max start time
  
  Time: O(n^2)
  Space: O(1)

*/



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
