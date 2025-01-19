public class Solution
{
    public int MajorityElement(int[] nums)
    {
        int n = nums.Length;
        int result = 0;
        for (int i = 0; i < 32; i++)
        {
            int bit = 1 << i;

            int bitCount = 0;
            foreach (int num in nums)
            {
                if ((num & bit) == bit) bitCount++;
            }

            if (bitCount > n / 2) result |= bit;
        }
        
        return result;
    }
}

/*

    Bit manipulation

    Time: O(nlogm)
    Space: O(1)

    Where n is the length of nums and m is the size of the largest possible value in nums.

    ------------------------------------------------------------------------
    
    For each number in nums, count the occurrence of each bit, if it's greater than n/2, then it should be set in the result.

*/

