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
