public class Solution
{
    public int MissingNumber(int[] nums)
    {
        Array.Sort(nums);

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1] + 1) return nums[i - 1] + 1;
        }

        int n = nums.Length;
        return nums[n - 1] != n ? n : 0;
    }
}

/*

    Solution 1

    Sorting

    Time: O(nlogn)
    Space: O(1) (depending on sorting algorithm)

    Given an array nums containing n distinct numbers in the range [0, n], return the only number in the range that is missing from the array.

*/



public class Solution2
{
    public int MissingNumber(int[] nums)
    {
        var set = new HashSet<int>();
        foreach (int num in nums) set.Add(num);

        for (int i = 0; i <= nums.Length; i++)
        {
            if (!set.Contains(i)) return i;
        }

        return -1;
    }
}

/*

    Solution 2

    Use a set

    Time: O(n)
    Space: O(n)


*/



public class Solution3
{
    public int MissingNumber(int[] nums)
    {
        int missing = nums.Length; // missing = n
        for (int i = 0; i < nums.Length; i++)
        {
            missing = missing ^ i ^ nums[i];
        }

        return missing;
    }
}

/*

    Solution 3

    Bit manipulation - XOR

    Time: O(n) assuming XOR is a constant time operation
    Space: O(1)

    This works because:
    * XOR of a number with itself is 0: a ^ a = 0
    * XOR of a number with 0 is the number itself: a ^ 0 = a
    * XOR operations don't rely on ordering

    Example 1
    [0,1,2,3] ^ [1,2,3] = 0
       X X X     X X X

    Example 2
    [0,1,2,3] ^ [0,3,2] = 1
     X   X X     X X X 

    --------------------------------------------------------------------------------

    It's more obvious why this works with an example where each value in nums[i] = i.

    If you only XOR each index with itself, then they cancel out to 0, resulting in n itself.

    Input: nums = [0,1,2,3] (n = 4)

    missing = 4

    i
    0: 4 ^ 0 ^ 0    =   0100 ^ (0000 ^ 0000)  =   0100 ^ 0000    = 4
    1: 4 ^ 1 ^ 1    =   0100 ^ (0001 ^ 0001)  =   0100 ^ 0000    = 4
    2: 4 ^ 2 ^ 2    =   0100 ^ (0010 ^ 0010)  =   0100 ^ 0000    = 4
    2: 4 ^ 3 ^ 3    =   0100 ^ (0011 ^ 0011)  =   0100 ^ 0000    = 4

    result = 4

    --------------------------------------------------------------------------------

    Example
    Input: nums = [1,0,2] (n = 3)

    missing = 3

    i
    0: 3 ^ 0 ^ 1    =   0011 ^ 0000 ^ 0001  =   0010    = 2
    1: 2 ^ 1 ^ 0    =   0010 ^ 0001 ^ 0000  =   0010    = 3 
    2: 3 ^ 2 ^ 2    =   0011 ^ 0010 ^ 0010  =   0001    = 3

    result = 3

*/



public class Solution4
{
    public int MissingNumber(int[] nums)
    {
        int n = nums.Length;
        int expectedSum = n*(n + 1)/2; // Gauss' Formula

        int sum = 0;
        foreach (int num in nums) sum += num;

        return expectedSum - sum;
    }
}

/*

    Solution 4

    The "Gauss formula" refers to the math formula used to calculate the sum of a sequence of consecutive positive integers: n(n + 1)/2

    [1]         = 1(1 + 1) / 2 = 1
    [1,2]       = 2(2 + 1) / 2 = 3
    [1,2,3]     = 3(3 + 1) / 2 = 6
    [1,2,3,4]   = 4(4 + 1) / 2 = 10

    Time: O(n)
    Space: O(1)

*/



public class Solution5
{
    public int MissingNumber(int[] nums)
    {
        int n = nums.Length;
        int result = 0;
        for (int i = 1; i <= n; i++)
        {
            result += i - nums[i - 1];
        }

        return result;
    }
}

/*

    Another way of implementing solution 4.

*/
