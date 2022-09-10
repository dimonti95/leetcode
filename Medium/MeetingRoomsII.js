/**
 * @param {number[][]} intervals
 * @return {number}
 */
var minMeetingRooms = function(intervals) {
    
  const startTimes = [];
  const endTimes = [];
  for (let interval of intervals) {
    startTimes.push(interval[0]);
    endTimes.push(interval[1]);
  }
  
  startTimes.sort((a, b) => a - b);
  endTimes.sort((a, b) => a - b);
  
  let usedRooms = 0;
  let endPointer = 0;
  for (let startPointer = 0; startPointer < startTimes.length; startPointer++) {
    if (startTimes[startPointer] >= endTimes[endPointer]) {
      usedRooms -= 1;
      endPointer += 1;
    }
    usedRooms += 1;
  }
  
  return usedRooms;
};

/*

  Treat start and end times seperately and track the number of rooms currently in use
  * Use two pointers to track the current start/end time in each array
  * If a meeting ended before the current start time go to the next end time and decrement the in use counter

  Time: O(nlogn)
  Space: O(n)

*/
