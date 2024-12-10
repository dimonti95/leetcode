public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var result = new List<int[]>();
        int i = 0;
        
        // Add all intervals that come before the newInterval
        while (i < intervals.Length && intervals[i][1] < newInterval[0])
        {
            result.Add(intervals[i]);
            i++;
        }
        
        // Merge all overlapping intervals
        while (i < intervals.Length && intervals[i][0] <= newInterval[1])
        {
            newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
            newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
            i++;
        }
        
        // Add the merged newInterval
        result.Add(newInterval);

        // Add the remaining intervals that come after the newInterval
        while (i < intervals.Length)
        {
            result.Add(intervals[i]);
            i++;
        }

        return result.ToArray();
    }
}

/*

    Solution:
    1. Add any intervals that end before newInterval starts
    2. Expand newInterval to cover any overlapping inverals
    3. Add any intervals that start after the newInterval ends

    Time: O(n)
    Space: O(1) (assuming the result array doesn't count as extra space)

    Where n is the number of intervals
    
*/
