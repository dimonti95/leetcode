public class Solution {
    public bool CanAttendMeetings(int[][] intervals)
    {
        for (int i = 0; i < intervals.Length; i++)
        {
            int[] interval1 = intervals[i];
            for (int j = i + 1; j < intervals.Length; j++)
            {
                int[] interval2 = intervals[j];
                bool endsBefore = interval1[1] <= interval2[0];
                bool startsAfter = interval1[0] >= interval2[1];
                if (!endsBefore && !startsAfter) return false;
            }
        }

        return true;
    }
}

/*

    Key insights:
    - The meetings may not be sorted by start time
    - No two meetings can overlap

    Solution 1
    - Compare all combination of meetings (MeetingA and MeetingB)
    - Return false if overlap is found, otherwise return true
    Time: O(n^2)
    Space: O(1)

*/



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

    Optimization
    - Sort intervals by start time
    - Compare end time interval[i] with interval[i + 1]
    - If the end time > start time, return false, otherwise return true
    Time: O(nlogn)
    Space: O(1) (depending on sorting algorithm)

*/