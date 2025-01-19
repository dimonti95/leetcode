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



public class Solution2
{
    public int MajorityElement(int[] nums)
    {
        int current = 0;
        int count = 0;
        foreach (int num in nums)
        {
            if (count == 0)
            {
                current = num;
            }

            count += (num == current) ? 1 : -1;
        }

        return current;
    }
}

/*

    Boyer-Moore Voting Algorithm

    Time: O(n)
    Space: O(1)

    -------------------------------------------------

    Example: [2,2,1,1,1,2,2]

    0: 2    count = 1, current = 2
    1: 2    count = 2, current = 2
    2: 1    count = 1, current = 2
    3: 1    count = 0, current = 2
    4: 1    count = 1, current = 1
    5: 2    count = 0, current = 1
    6: 2    count = 1, current = 2
    
*/
