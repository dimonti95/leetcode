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
