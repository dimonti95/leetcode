public class Solution {
    public string LongestPalindrome(string s) {
        
        int left = 0;
        int right = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int len1 = GetMaxPalindromeLengthFromCenter(s, i, i);
            int len2 = GetMaxPalindromeLengthFromCenter(s, i, i + 1);
            int len = Math.Max(len1, len2);
            int currentMax = right - left;
            if (len > currentMax)
            {
                left = i - (len - 1) / 2;
                right = i + len / 2;
            }
        }
        
        return s.Substring(left, right - left + 1);
    }

    private int GetMaxPalindromeLengthFromCenter(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }

        return right - left - 1;
    }
}

/*
    
    Expand from the center of each index, the center could be between two letters.
    
    Time: O(n^2)
    Space: O(1)

*/
