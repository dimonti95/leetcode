public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        var unique = new HashSet<char>();
        int max = 0;
        int left = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];
            while (unique.Contains(c))
            {
                unique.Remove(s[left]);
                left++;
            }
            unique.Add(c);
            max = Math.Max(max, right - left + 1);
        }

        return max;
    }
}

/*

  Sliding window algorithm with two pointers
  
  Time: O(n)
  Space: O(min(n,m))
  
  Where n is the length of the input string s and m is the size of the character set.

  The size of the Set is upper bounded by the size of the string (n) and the number of unique characters.

*/



public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        var count = new Dictionary<char, int>(); // character, index
        int longest = 0;
        int left = 0;
        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];
            if (count.ContainsKey(c)) left = Math.Max(count[c] + 1, left);
            count[c] = right;
            longest = Math.Max(longest, right - left + 1);
        }

        return longest;
    }
}

/*

    Sliding window algorithm with two pointers (optimized)

    Rather than using a HashSet, use a Dictionary that maps the character to its index.

    Using a HashSet requires O(2n) time, but we can optimize this further by jumping past 
    the index of the repeating character.

    Time: O(n)
    Space: O(min(n,m))

    Where n is the length of the input string s and m is the size of the character set.

*/
