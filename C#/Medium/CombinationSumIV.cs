public class Solution
{
    public int CombinationSum4(int[] nums, int target)
    {
        var memo = new int[target + 1];
        Array.Fill(memo, -1);

        int CombinationSum4Recursive(int[] nums, int target)
        {
            if (target == 0) return 1;
            if (target < 0) return 0;
            if (memo[target] > -1) return memo[target];

            int result = 0;
            foreach (int num in nums)
            {
                result += CombinationSum4Recursive(nums, target - num);
            }

            memo[target] = result;
            return memo[target];        
        }

        return CombinationSum4Recursive(nums, target);
    }
}

/*

    Top-down DP (memoization)

    Time: O(t*n)
    Space: O(t)

    Where t is the value of target n is the size of nums

*/



public class Solution2
{
    public int CombinationSum4(int[] nums, int target)
    {
        var table = new int[target + 1];
        table[0] = 1;
        
        for (int i = 1; i < table.Length; i++)
        {
            foreach (int num in nums)
            {
                int diff = i - num;
                if (diff >= 0) table[i] += table[diff];
            }
        }
        
        return table[target];
    }
}

/*

    Bottom-up DP (tabulation)

    Time: O(t*n)
    Space: O(t)

    Where n is the size of nums and t is the value of target

    Key insight: Think about what the "key" is that needs to be used to look back in the table, and think about what needs to be returned as the values in the table.

*/
