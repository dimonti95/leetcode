public class Solution {
    public int CountSubstrings(string s) {
        int count = 0;

        for (int i = 0; i < s.Length; i++)
        {
            count += GetPalindromeCountFromCenter(s, i, i);
            count += GetPalindromeCountFromCenter(s, i, i + 1);
        }

        return count;
    }

    private int GetPalindromeCountFromCenter(string s, int left, int right)
    {
        int count = 0;
        
        while (left >= 0 && right < s.Length)
        {
            if (s[left] == s[right]) count++;
            else break;
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
