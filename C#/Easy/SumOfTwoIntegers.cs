public class Solution
{
    public int GetSum(int a, int b)
    {
        while (b != 0) {
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

    Example (assume 8-bit numbers):
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

*/
