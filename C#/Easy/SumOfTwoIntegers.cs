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
     0000 0110 = 6 = a
     0000 0101 = 5 = b
    +________________
     0000 1011 = 11
   
    b     = 5
    carry = 0000 0100
    a     = 0000 0011
    b     = 0000 1000

    b     = 8
    carry = 0000 0000
    a     = 0000 1011
    b     = 0000 0000

*/
