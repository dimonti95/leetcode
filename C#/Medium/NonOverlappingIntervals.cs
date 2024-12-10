public class Solution {
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
