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
            for (int j = i - 1; j >= 0; j--)
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
