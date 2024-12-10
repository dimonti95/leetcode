public class Solution {
    public int[][] Merge(int[][] intervals)
    {
        // Sort by start value
        Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));

        var result = new List<int[]>();
        result.Add(new int[] { intervals[0][0], intervals[0][1] });

        for (int i = 1; i < intervals.Length; i++)
        {
            int[] interval1 = result[result.Count - 1];
            int[] interval2 = intervals[i];
            int endTime = interval1[1];
            int startTime = interval2[0];

            // check for overlap
            if (endTime >= startTime)
            {
                // Combine the two overlapping intervals
                result[result.Count - 1] = new int[] { interval1[0], Math.Max(interval1[1], interval2[1]) };
            }
            else
            {
                result.Add(new int[] { interval2[0], interval2[1] });
            }
        }

        return result.ToArray();
    }
}

/*

    Solution:
    1. Sort the input array
    2. Iterate over the input (intervals)
    3. Find and combine overlapping intervals

    Time: O(nlogn)
    Space: O(log) or O(n) (depending on the sorting algorithm)

*/
