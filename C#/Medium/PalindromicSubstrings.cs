public class Solution
{
    public int CountSubstrings(String s)
    {
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            count += ExpandFromCenter(i, i, s) + ExpandFromCenter(i, i + 1, s);
        }

        return count;
    }

    private int ExpandFromCenter(int left, int right, string s)
    {
        int count = 0;
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            count++;
            left--;
            right++;
        }

        return count;
    }
}

/*

    Expand from the center of each index, the center could be between two letters.

    Time: O(n^2)
    Space: O(1)

*/
