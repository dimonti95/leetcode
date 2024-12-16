public class Solution
{
    public int Rob(int[] nums)
    {
        var memo = new int[nums.Length];
        Array.Fill(memo, -1);

        int RobRecursive(int i, int[] nums)
        {   
            if (i >= nums.Length) return 0;
            if (memo[i] > -1) return memo[i];
            if (i == nums.Length - 1) return nums[i];

            int left = nums[i];
            int right = nums[i + 1];
            left += RobRecursive(i + 2, nums);
            right += RobRecursive(i + 3, nums);

            memo[i] = Math.Max(left, right);
            return memo[i];
        }

        return RobRecursive(0, nums);
    }
}

/*

    Top-down DP (memoization)

    Time: O(n)
    Space: O(n/2) = O(n)

    Check all combinations of houses so that no paths include adjacent "houses".

    ---------------------------------------------------------------------------

    Key insight: There is no "Greedy" alogirthm that works

*/



public class Solution2
{
    public int Rob(int[] nums)
    {
        int max1 = 0;
        int max2 = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            int temp = max1;
            max1 = Math.Max(max1, max2 + nums[i]);
            max2 = temp;
        }

        return max1;
    }
}

/*

    Bottom-up DP (memory optimized)
    Time: O(n)
    Space: O(1)

    ------------------------------------------------

    Example
    Input = [10,20,5,1,50]
    Output = (20 + 50) = 70

    i = 1
    [10,20,5,1,50]
     ^
    max1 = 10
    max2 = 0

    i = 2
    [10,20,5,1,50]
        ^ 
    max1 = 20
    max2 = 10

    i = 3
    [10,20,5,1,50]
           ^ 
    max1 = 20
    max2 = 20

    i = 4
    [10,20,5,1,50]
             ^ 
    max1 = 21
    max2 = 20

    i = 5
    [10,20,5,1,50]
               ^ 
    max1 = 70
    max2 = 21

*/
