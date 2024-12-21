public class Solution1
{
    public int[] CountBits(int n)
    {
        var result = new int[n + 1];
        int mask = 1;
        for (int i = 0; i <= n; i++)
        {   
            int x = i;
            int count = 0;

            // This is O(logn) since this number is being divided by 2
            while (x != 0)
            {
                if ((x & mask) != 0) count++;
                x >>= 1; // this is the divide by 2
            }

            result[i] = count;
        }
        
        return result;
    }
}

/*

    Solution 1
    
    Count the number of bits in each number from 0 to n.

    Time: O(nlogn)
    Space: O(1)

*/



public class Solution2
{
    public int[] CountBits(int n)
    {
        var dp = new int[n + 1];
        dp[0] = 0;
        
        int offset = 1;
        for (int i = 1; i <= n; i++)
        {
            if (offset * 2 == i) offset = i;
            dp[i] = dp[i - offset] + 1;
        }

        return dp;
    }
}

/*

    Solution 2  

    Bottom-up DP (tabulation)

    Time: O(n)
    Space: O(1)

    [n]
    [1] = 0001 = dp[1 - 1] + 1 = 1
    [2] = 0010 = dp[2 - 2] + 1 = 1   offset = 2
    [3] = 0011 = dp[3 - 2] + 1 = 2
    [4] = 0100 = dp[4 - 4] + 1 = 1   offset = 4
    [5] = 0101 = dp[5 - 4] + 1 = 2
    [6] = 0110 = dp[6 - 4] + 1 = 2
    [7] = 0111 = dp[7 - 4] + 1 = 3
    [8] = 1000 = dp[8 - 8] + 1 = 1   offset = 8
    
    This works because the only bit that changes is the most signifigant bit (every multiple of 2):
    2^1 = 2
    2^2 = 4
    2^3 = 8
    etc

*/
