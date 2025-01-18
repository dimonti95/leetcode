public class Solution
{
    public int GetSum(int a, int b)
    {
        while (b != 0)
        {
            int carry = a & b;  // Calculate carry (AND)
            a = a ^ b;          // Sum without carry (XOR)
            b = carry << 1;     // Shift carry left by 1
        }
        return a;
    }
}

/*

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
