public class Solution {
    public int MinMeetingRooms(int[][] intervals)
    {
        // Sort intervals by start time
        Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));

        var pQueue = new PriorityQueue<int, int>();
        for (int i = 0; i < intervals.Length; i++)
        {
            int[] interval = intervals[i];
            int start = interval[0];
            int end = interval[1];

            // If the current meeting starts after (or at) the next end time, then remove the next meeting that ended
            if (pQueue.Count > 0 && start >= pQueue.Peek()) pQueue.Dequeue();
            pQueue.Enqueue(end, end);
        }

        return pQueue.Count;
    }
}

/*

    Solution 1
    1. Sort the meeting intervals by start time
    2. Use a priority queue to keep track of the next meeting that will end first
        - When finding a meeting that starts before the earliest end time, simply that end time to the priorty queue
        - When finding a meeting that starts after the earliest end time, replace the end time with the new end time
    3. Keep a max that tracks the max size that the priority queue grows to

    Time: O(nlogn)
    Space: O(n)

    Where n is the number of intervals/meetings in the input array

*/
// If the current meeting starts before the next meeting that will end first, then add the new end time to the queue
            // else replace the lowest priorty end time (the meeting that ends first) with the current end time.