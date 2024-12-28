public class Solution
{
    public string LongestPalindrome(string s)
    {
        int max = 0;
        int start = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int len1 = ExpandFromCenter(i, i, s);
            int len2 = ExpandFromCenter(i, i + 1, s);
            int currentMax = Math.Max(len1, len2);
            if (currentMax > max)
            {
                start = i - (currentMax - 1) / 2;
                max = currentMax;
            }
        }

        return s.Substring(start, max);
    }

    private int ExpandFromCenter(int i, int j, string s)
    {
        while (i >= 0 && j < s.Length && s[i] == s[j])
        {
            i--;
            j++;
        }

        return j - i - 1;
    }
}

/*
    
    Expand from the center of each index, the center could be between two letters.
    
    Time: O(n^2)
    Space: O(1)

*/
