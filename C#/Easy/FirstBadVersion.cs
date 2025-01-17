/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl
{
    public int FirstBadVersion(int n)
    {
        int left = 1;
        int right = n;
        while (left < right)
        {
            int middle = (left + right) >>> 1; // to avoid overflow
            if (IsBadVersion(middle))
            {
                right = middle;
            }
            else
            {
                left = middle + 1;
            }
        }

        return left;
    }
}

/*

    Binary Search

    Time: O(logn)
    Space: O(1)

    ---------------------------------------------------

    Note: 1 <= n <= 2^31 - 1

    This means that finding the middle value by doing (left + right) / 2 can lead to overflow.

    There are two ways around this:
    left + (right - left) / 2
    (left + right) >>> 1

    Overflow happens when the result of an arithmetic operation exceeds the range that can be represented by the data type being used.

*/
