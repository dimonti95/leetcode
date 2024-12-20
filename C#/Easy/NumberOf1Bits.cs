public class Solution
{
    public int HammingWeight(int n)
    {
        int mask = 1;
        int count = 0;
        for (int i = 0; i < 32; i++)
        {
            if ((n & mask) != 0) count++;
            mask <<= 1;
        }

        return count;
    }
}

/*

    Solution 1

    Iterate through each bit and check for using using the AND and shift bitwise operators.

    On each iteration of the for loop, the mask bit is shifted left by one.
    
    For example (assuming 8-bit integer): 
    - 0000 0001
    - 0000 0010
    - 0000 0100
    - 0000 1000
    - 0001 0000
    - 0010 0000
    - 0100 0000
    - 1000 0000
    
    Time: O(1) because an integer is only 32 bits
    Space: O(1)

    --------------------------------------------------

    Example 1
    Input: 5
    Output: 2
    Because 5 in binary is 0000 0101.

*/



public class Solution2
{
    public int HammingWeight(int n)
    {
        int mask = 1;
        int count = 0;
        while (n != 0)
        {
            if ((n & mask) != 0) count++;
            n >>= 1;
        }

        return count;
    }
}

/*

    Solution 2

    Rather than shifting the mask bit, shift n right until it reaches 0.

    Time: O(1)
    Space: O(1)

*/
