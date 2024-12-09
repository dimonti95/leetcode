public class Solution {
    public bool CanAttendMeetings(int[][] intervals)
    {
        if (intervals.Length == 0) return true;

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        for (int i = 1; i < intervals.Length; i++)
        {
            int[] interval1 = intervals[i - 1];
            int[] interval2 = intervals[i];
            if (interval1[1] > interval2[0]) return false;
        }

        return true;
    }
}

/*

    Example 1
    Input = [[0, 5], [5, 10], [11, 14]]
    Output = true

    Example 2
    Input = [[0, 5], [5, 10], [7, 11]]
    Output = false (because theres overlap between intervals[1] and intervals[2])

    Example 3
    Input = []
    Output = true

    Solution 1
    - Compare all combination of meetings (MeetingA and MeetingB)
    - Return false if overlap is found, otherwise return true
    Time: O(n^2)
    Space: O(1)
    
    Optimization
    - Sort intervals by start time
    - Compare end time interval[i] with interval[i + 1]
    - If the end time > start time, return false, otherwise return true
    Time: O(nlogn)
    Space: O(1) (depending on sorting algorithm)

*/