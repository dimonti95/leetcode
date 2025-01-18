public class Solution
{
    public int GetSum(int a, int b)
    {
        if (b == 0) return a;
        return GetSum(a ^ b, (a & b) << 1);
    }
}

/*

    Recursion

    Time: O(1) - since the integer is 32-bits
    Space: O(1) - since the integer is 32-bits

    --------------------------------------------------

    This solution takes advantage of the fact that the problem can be broken down into sub-problems:
    * The base-case is when b is 0, in which case the answer will always be the value of a
    * The value of b will always go to zero, once there's no longer a carry bit
    * This works for both positive and negative numbers because C# represents negative numbers with two's complement

*/



public class Solution2
{
    public int GetSum(int a, int b)
    {
        while (b != 0)
        {
            int answer = a ^ b;
            int carry = (a & b) << 1;
            a = answer;
            b = carry;
        }

        return a;
    }
}

/*

    Iterative

    Time: O(1) - since an integer is 32 bits
    Space: O(1) - since we're not using any additional data structures

    -------------------------------------------------------------------

    Example assumes an 8-bit integer

    Example 1 - Two posative integers:
     0001 1100 = 28 = a
     0000 0101 = 5 = b
    +________________
     0010 0001 = 33
   
    a            =  0001 1100  = 28
    b            =  0000 0101  = 5

    a ^ b        =  0001 1001  = 25
    a & b << 1   =  0000 1000  = 8

    a ^ b        =  0001 0001  = 17
    a & b << 1   =  0001 0000  = 16

    a ^ b        =  0000 0001  = 1
    a & b << 1   =  0010 0000  = 32

    a ^ b        =  0010 0001  = 33
    a & b << 1   =  0000 0000  = 0

    The carry is guaranteed to eventually go to 0 because eventually all 1's carry over.

    -------------------------------------------------------------------

    Example assumes an 8-bit integer

    Example 2 - A posative and negative integer:
     0001 1100 = 28 = a
     1111 1011 = -5 = b
    +________________
     0001 0111 = 23

    a                =  0001 1100  = 28
    b                =  1111 1011  = -5

    a = a ^ b        =  1110 0111  = -25
    b = a & b << 1   =  0011 0000  = 48

    a = a ^ b        =  1101 0111  = -37
    b = a & b << 1   =  0100 0000  = 64

    a = a ^ b        =  1001 0111  = -105 
    b = a & b << 1   =  1000 0000  = 128

    a = a ^ b        =  0001 0111  = 23 
    b = a & b << 1   =  0000 0000  = 0

    Again, the carry eventually goes to 0.

    -------------------------------------------------------------------

    C# language specifics

    - Every langauge represents negative numbers differently.
    - C# represents numbers as 32 bits (int is an alias for System.Int32).
    - The left most bit (most signifigant bit) is used for the sign, 1 for negative, 0 for posative.
    - The remaining 31 bits are used for the value.

    We don't need to manage negatives seperately because C# manages negative numbers automatically using two's complement.

*/
