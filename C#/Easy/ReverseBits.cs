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

    Time: O(1)
    Space: O(1)

*/
