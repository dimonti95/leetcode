public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        var memo = new int[nums.Length];

        int LengthOfLIS(int index, List<int> sequence)
        {
            if (index == nums.Length) return 0;
            if (memo[index] > 0) return memo[index];

            int max = 0;
            for (int i = index; i < nums.Length; i++)
            {
                if (sequence.Count == 0 || nums[i] > sequence[sequence.Count - 1])
                {
                    sequence.Add(nums[i]);
                    max = Math.Max(max, 1 + LengthOfLIS(i + 1, sequence));
                    sequence.Remove(nums[i]);
                }
            }

            memo[index] = max;
            return memo[index];
        }

        return LengthOfLIS(0, new List<int>());
    }
}

/*

    Top-down DP (memoization)

    Time: O(n^2)
    Space: O(n)

    Where n is the length of the array nums


*/



public class Solution2
{
    public int LengthOfLIS(int[] nums)
    {
        var table = new int[nums.Length];
        Array.Fill(table, 1);

        for (int i = 1; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    table[i] = Math.Max(table[i], table[j] + 1);   
                } 
            }
        }

        int longest = 1;
        foreach (int count in table)
        {
            longest = Math.Max(longest, count);
        }

        return longest;
    }
}

/*

    Bottom-up DP (tabulation)

    Time: O(n^2)
    Space: O(n)

    Where n is the length of the array nums


*/



public class Solution3
{
    public int LengthOfLIS(int[] nums)
    {
        var sub = new List<int>();
        sub.Add(nums[0]);

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > sub[sub.Count - 1])
            {
                sub.Add(nums[i]);
            }
            else
            {
                for (int j = 0; j < sub.Count; j++)
                {
                    if (sub[j] >= nums[i])
                    {
                        sub[j] = nums[i];
                        break;
                    }
                }
            }
        }

        return sub.Count;
    }
}

/*

    Algorithm:
    * Init a subsequence array with the first value in the array
    * For each nums[i] where 1 <= i < nums.Length, compare the value to the last value in sub
    * If nums[i] is larger, add it to the subarray
    * If nums[i] is smaller, replace it with the first vlaue in sub that's greater than or equal to nums[i]

    Time: O(n^2)
    Space: O(n)

    Note: The values in sub won't be a valid subsequence but the count will always be right, since we're never shrinking the size of sub

*/



public class Solution4
{
    public int LengthOfLIS(int[] nums)
    {
        var sub = new List<int>();
        sub.Add(nums[0]);

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > sub[sub.Count - 1])
            {
                sub.Add(nums[i]);
            }
            else
            {
                int j = BinarySearch(sub, nums[i]);
                sub[j] = nums[i];
            }
        }

        return sub.Count;
    }

    private int BinarySearch(List<int> list, int val)
    {
        int left = 0;
        int right = list.Count - 1;

        while (left < right)
        {
            int middle = (right + left) / 2;
            if (list[middle] < val)
            {
                left = middle + 1;
            }
            else if (list[middle] > val)
            {
                right = middle;
            }
            else
            {
                return middle;
            }
        }

        return left;
    }
}

/*

    Solution 3 Optimization (binary search)

    Key insight: The sub list is always sorted, so we can run binary search rather than scanning the array.

    Time: O(nlogn)
    Space: O(n)

*/
