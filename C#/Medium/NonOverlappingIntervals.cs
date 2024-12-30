public class Solution
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));

        int count = 0;
        for (int i = 1; i < intervals.Length; i++)
        {
            int[] interval1 = intervals[i - 1];
            int[] interval2 = intervals[i];
            int end = interval1[1];
            int start = interval2[0];

            // check for overlap
            if (end > start)
            {
                // Set the end time to be the smaller of the two intervals
                interval1[1] = Math.Min(interval1[1], interval2[1]);
                interval2[1] = interval1[1];
                count += 1;
            }
        }
        
        return count;
    }
}

/*

    Key insight: When choosing to "erase" two intervals, always choose the interval that has a later end date.

    Solution:
    1. Sort the intervals by start data.
    2. Compare each pair of intervals (intervals[i] and intervals[i + 1]) for overlap.
    3. Delete the interval with the later end date.

    Time: O(nlogn)
    Space: O(logn) or O(n) (depending on the sorting algorithm)

*/



public class Solution2
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        int count = 0;
        
        // Sort by end time
        Array.Sort(intervals, (a,b) => a[1].CompareTo(b[1]));

        int lastEnd = Int32.MinValue;
        for (int i = 0; i < intervals.Length; i++)
        {
            int[] interval = intervals[i];

            // Check for overlap
            if (interval[0] >= lastEnd)
            {
                // no overlap
                lastEnd = interval[1];
            }
            else
            {
                // overlap
                count++;
            }
        }

        return count;
    }
}

/*

    Solution 2: Greedy

    This is a better way to implement Solution 1
    
    The key insight is the same in that the focus is on keeping intervals that have the earliest end time.

    Time: O(nlogn)
    Space: O(logn) or O(n) (depending on the sorting algorithm)

*/
