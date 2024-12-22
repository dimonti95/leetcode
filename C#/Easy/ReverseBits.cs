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
        var memo = new byte[Byte.MaxValue + 1];
        byte[] bytes = BitConverter.GetBytes(n);
        int left = 0;
        int right = bytes.Length - 1;
        while (left < right)
        {
            byte temp = ReverseByte(bytes[left], memo);
            bytes[left] = ReverseByte(bytes[right], memo);
            bytes[right] = temp;
            left++;
            right--;
        }

        return BitConverter.ToUInt32(bytes);
    }

    private byte ReverseByte(byte b, byte[] memo)
    {
        memo[b] = (byte)((b * 0x0202020202 & 0x010884422010) % 1023);
        return memo[b];
    }
}

/*

    Solution 2

    Response to the following follow-up question: If this function is called many times, how would you optimize it?
    - Swap bytes instead of bits
    - Cache the value of each reversed byte using memoization
    
    It's not much of an improvement when the input is a single byte, but if we were dealing with a stream it would be a signifigant optimization.

    Time: O(1)
    Space: O(1)

*/