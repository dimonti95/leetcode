public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        var result = new List<int[]>();

        // Sort by start time
        Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));

        result.Add(intervals[0]);
        for (int i = 1; i < intervals.Length; i++)
        {
            int[] interval1 = result[result.Count - 1];
            int[] interval2 = intervals[i];

            // Check for overlap
            if (interval1[1] >= interval2[0])
            {
                interval1[1] = Math.Max(interval1[1], interval2[1]);
            }
            else
            {
                result.Add(interval2);
            }
        }

        return result.ToArray();
    }
}

/*

    Brute force solution (not implemented here)
    1. Create an adjacency list for an undirected graph
        - Nodes represent intervals
        - Edges represent overlap between two nodes
    2. Traverse the graph and merge intervals that are connected

    Time: O(n^2)
    Space: O(n^2) because in the worst-case every interval overlaps

    Where n is the number of intervals in the input array.

    ------------------------------------------------

    Optimal Solution:
    1. Sort the input array
    2. Iterate over the input (intervals)
    3. Find and combine overlapping intervals

    Time: O(nlogn)
    Space: O(log) or O(n) (depending on the sorting algorithm)

    Where n is the number of intervals in the input array.

*/
