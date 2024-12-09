public class Solution {
    public int MinMeetingRooms(int[][] intervals)
    {
        // Sort meetings by start time
        Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));

        int max = 1;
        var pQueue = new PriorityQueue<int, int>();

        // Queue up the first end time (value = end time, priority = end time)
        pQueue.Enqueue(intervals[0][1], intervals[0][1]);

        for (int i = 1; i < intervals.Length; i++)
        {
            int[] interval = intervals[i];
            int start = interval[0];
            int end = interval[1];
            
            // If the current meeting starts before the next meeting that will end first, then add the new end time to the queue
            // else replace the lowest priorty end time (the meeting that ends first) with the current end time.
            if (start < pQueue.Peek()) pQueue.Enqueue(end, end);
            else pQueue.DequeueEnqueue(end, end);

            max = Math.Max(max, pQueue.Count);
        }

        return max;
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
