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



public class Solution2
{
    public uint reverseBits(uint n)
    {
        var memo = new Dictionary<uint, uint>();
        uint result = 0;
        int power = 24;
        while (n > 0)
        {
            result += ReverseByte(Convert.ToUInt32(n & 0xff), memo) << power;
            n >>>= 8;
            power -= 8;
        }

        return result;
    }

    private uint ReverseByte(uint b, Dictionary<uint, uint> memo)
    {
        if (memo.ContainsKey(b)) return memo[b];

        // An algorithm described as "reverse the bits in a byte with 3 operations"
        // From Bit Twiddling Hacks by Sean Eron Anderson
        memo[b] = (uint)((b * 0x0202020202 & 0x010884422010) % 1023);
        
        return memo[b];
    }
}

/*

    Solution 2

    Response to the following follow-up question: If this function is called many times, how would you optimize it?
    - Swap bytes instead of bits
    - Cache the value of each reversed byte using memoization

    This doesn't save much time since the input is a fixed size (uint is a 32-bit integer), but if you were dealing with
    a stream, this would be an impactful optimization compared to Solution 1.

    Time: O(1)
    Space: O(1) because the memoization cache will grow (at most) to hold 256 bytes

*/



public class Solution3
{
    public uint reverseBits(uint n)
    {
        // swap each 16-bit side of the 32-bit uint
        n = (n >>> 16) | (n << 16);

        // swap each 8-bit pair
        n = ((n & 0xFF00FF00) >>> 8) | ((n & 0x00FF00FF) << 8);

        // swap each 4-bit pair
        n = ((n & 0xF0F0F0F0) >>> 4) | ((n & 0x0F0F0F0F) << 4);

        // swap each 2-bit pair
        n = ((n & 0xCCCCCCCC) >>> 2) | ((n & 0x33333333) << 2);

        // swap each bit
        n = ((n & 0xAAAAAAAA) >>> 1) | ((n & 0x55555555) << 1);

        return n;
    }
}

/*

    Solution 3

    Divide and conquer

    Response to the following follow-up question: How would you solve it without using a loop?

    Time: O(1)
    Space: O(1)

    Example
    Input: n = 0000 0010 1001 0100 0001 1110 1001 1100
    Output: 0011 1001 0111 1000 0010 1001 0100 0000

    Left bit masks:
    1111 1111 0000 0000 1111 1111 0000 0000 = 0xFF00FF00
    1111 0000 1111 0000 1111 0000 1111 0000 = 0xF0F0F0F0
    1100 1100 1100 1100 1100 1100 1100 1100 = 0xCCCCCCCC
    1010 1010 1010 1010 1010 1010 1010 1010 = 0xAAAAAAAA
    
    Right bit masks:
    0000 0000 1111 1111 0000 0000 1111 1111 = 0x00FF00FF
    0000 1111 0000 1111 0000 1111 0000 1111 = 0x0F0F0F0F
    0011 0011 0011 0011 0011 0011 0011 0011 = Ox33333333
    0101 0101 0101 0101 0101 0101 0101 0101 = 0x55555555

    0000 0010 1001 0100 0001 1110 1001 1100
                     |
                     v
    0001 1110 1001 1100 0000 0010 1001 0100         n = (n >>> 16) | (n << 16)
                     |
                     v
    1001 1100 0001 1110 1001 0100 0000 0010         n = ((n & 0xff00ff00) >>> 8) | ((n & 0x00ff00ff) << 8)
                     |
                     v
    1100 1001 1110 0001 0100 1001 0010 0000         n = ((n & 0xf0f0f0f0) >>> 4) | ((n & 0x0f0f0f0f) << 4)
                     |
                     v
    0011 0110 1011 0100 0001 0110 1000 0000         n = ((n & 0xcccccccc) >>> 2) | ((n & 0x33333333) << 2)
                     |
                     v
    0011 1001 0111 1000 0010 1001 0100 0000         n = ((n & 0xaaaaaaaa) >>> 1) | ((n & 0x55555555) << 1)

*/
