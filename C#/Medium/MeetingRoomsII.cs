public class Solution
{
    public int MinMeetingRooms(int[][] intervals)
    {
        // Sort intervals by start time
        Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));

        var pQueue = new PriorityQueue<int, int>(); // min-heap
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



public class Solution
{
    public int MinMeetingRooms(int[][] intervals)
    {
        // Build arrays for start times and end times
        int[] startTimes = new int[intervals.Length];
        int[] endTimes = new int[intervals.Length];
        for (int i = 0; i < intervals.Length; i++)
        {
            int[] interval = intervals[i];
            int startTime = interval[0];
            int endTime = interval[1];
            startTimes[i] = startTime;
            endTimes[i] = endTime;
        }

        Array.Sort(startTimes);
        Array.Sort(endTimes);

        int count = 0;
        int startPointer = 0;
        int endPointer = 0;
        while (startPointer < intervals.Length)
        {
            if (startTimes[startPointer] >= endTimes[endPointer])
            {
                count -= 1;
                endPointer += 1;
            }

            // Increment the count each time a new meeting room is needed
            count += 1;
            startPointer += 1;
        }

        return count;
    }
}

/*

    Solution 2
    1. Add start times to an array
    2. Add end times to another array
    3. Order both arrays
    4. Two pointers on each array
        - While starttime[i++] < endtime[j], incremement i and running count
        - else increment the end time index while startTime[i]  endtime[j]

    Time: O(nlogn)
    Space: O(n)

    Where n is the number of intervals/meetings in the input array

*/
