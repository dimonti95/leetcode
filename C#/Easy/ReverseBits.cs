public class Solution
{
    public uint reverseBits(uint n)
    {
        uint result = 0;
        uint rMask = 1U << 31;
        while (n > 0)
        {
            // check if LSB is 1
            if ((n & 1) > 0)
            {
                // set the masked bit to 1
                result |= rMask;
            }

            n >>>= 1;
            rMask >>>= 1;
        }

        return result;
    }
}

/*

    Solution 1

    Compare each bit

    Time: O(1)
    Space: O(1)

    Solution:
    - Shift n right (using usigned shift operator) each iteration until n is 0
    - For every 1 bit found, update the corresponding result bit

*/
