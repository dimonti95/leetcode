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
            if (offset * 2 == i) offset = i; // check for multiple of 2 (2,4,8,16,etc)
            dp[i] = dp[i - offset] + 1;
        }

        return dp;
    }
}

/*

    Solution 2  

    Bottom-up DP (tabulation) using the Most Signifigant Bit

    Time: O(n)
    Space: O(1)

    [n]
    [1] = 0001 =    dp[1 - 1] + 1 = 1                        0001
    [2] = 0010 =    dp[2 - 2] + 1 = 1   offset = 2 (2^1)     0010    - MSB changed
    [3] = 0011 =    dp[3 - 2] + 1 = 2                        0011
    [4] = 0100 =    dp[4 - 4] + 1 = 1   offset = 4 (2^2)     0100    - MSB changed
    [5] = 0101 =    dp[5 - 4] + 1 = 2                        0101
    [6] = 0110 =    dp[6 - 4] + 1 = 2                        0110
    [7] = 0111 =    dp[7 - 4] + 1 = 3                        0111
    [8] = 1000 =    dp[8 - 8] + 1 = 1   offset = 8 (2^3)     1000    - MSB changed
    
    This works because the only bit that changes is the most signifigant bit (every multiple of 2):
    2^1 = 2
    2^2 = 4
    2^3 = 8
    2^4 = 16
    etc

    Between each multiple of 2, the bits follow the same pattern, so the results can re-used.

*/



public class Solution3
{
    public int[] CountBits(int n)
    {
        var dp = new int[n + 1];
        dp[0] = 0;
    
        for (int i = 1; i <= n; i++)
        {
            dp[i] = dp[i / 2] + (i & 1);
        }

        return dp;
    }
}

/*

    Solution 3

    Bottom-up DP (tabulation) using the Least Signifigant Bit (LSB)

    Time: O(n)
    Space: O(1)

    [n]
    [0] = 0000
    [1] = 0001 =    dp[1] = dp[0] + 1   = 1     - LSB changed
    [2] = 0010 =    dp[2] = dp[1] + 0   = 1
    [3] = 0011 =    dp[3] = dp[1] + 1   = 2     - LSB changed
    [4] = 0100 =    dp[4] = dp[2] + 0   = 1 
    [5] = 0101 =    dp[5] = dp[2] + 1   = 2     - LSB changed
    [6] = 0110 =    dp[6] = dp[3] + 0   = 2
    [7] = 0111 =    dp[7] = dp[3] + 1   = 3     - LSB changed
    [8] = 1000 =    dp[8] = dp[4] + 0   = 1
    
    This works in a similar way as solution 2, except instead of checking the MSB we check the LSB.

*/



public class Solution3
{
    public int[] CountBits(int n)
    {
        var dp = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            dp[i] = dp[i & (i - 1)] + 1;
        }

        return dp;
    }
}