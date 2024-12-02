public class Solution {
    public int LengthOfLongestSubstring(string s) {
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
  
  Time Complexity: O(n)
  Space Complexity: O(min(m,n))
  
  Where n is the length of the string

  The size of the Set is upper bounded by the size of the string (n) and the number of unique characters.

*/
