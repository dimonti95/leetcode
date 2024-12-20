public class Solution
{
    public int[] CountBits(int n)
    {
        var result = new int[n + 1];
        int mask = 1;
        for (int i = 0; i <= n; i++)
        {   
            int x = i;
            int count = 0;
            while (x != 0)
            {
                if ((x & mask) != 0) count++;
                x >>= 1;
            }

            result[i] = count;
        }
        
        return result;
    }
}

/*

    Solution 1
    
    Count the number of bits in each number from 0 to n.

    Time: O(n)
    Space: O(1)

*/
