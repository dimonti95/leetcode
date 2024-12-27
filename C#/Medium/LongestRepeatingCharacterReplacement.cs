public class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        var charFrequency = new Dictionary<char, int>();
        int left = 0;
        int max = 0;
        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];
            if (charFrequency.ContainsKey(c)) charFrequency[c] += 1;
            else charFrequency.Add(c, 1);

            int mostFreqChar = GetMostFrequentChar(charFrequency);
            int len = right - left + 1;

            while (len - mostFreqChar > k && left < right)
            {
                charFrequency[s[left]] -= 1;
                left += 1;
                mostFreqChar = GetMostFrequentChar(charFrequency);
                len = right - left + 1;
            }

            max = Math.Max(max, len);
        }

        return max;
    }

    private int GetMostFrequentChar(Dictionary<char, int> charFrequency)
    {
        int max = 0;

        foreach (var pair in charFrequency)
        {
            max = Math.Max(max, charFrequency[pair.Key]);
        }

        return max;
    }
}

/*

  Two pointers, sliding window, track (count of most frequent character - size of window)

  Time Complexity: O(n)
  Space Complexity: O(1) (at most 26 characters get mapped)

  Where n is the length of the string

*/



public class Solution2
{
    public int CharacterReplacement(string s, int k)
    {
        var count = new Dictionary<char, int>(); // char, count
        int longest = 0;
        int max = 0;
        for (int right = 0, left = 0; right < s.Length; right++)
        {
            char c = s[right];
            int len = right - left + 1;

            if (!count.ContainsKey(c)) count.Add(c, 0);
            count[c] += 1;

            max = Math.Max(max, count[c]);
            if (len - max > k)
            {
                count[s[left]] -= 1;
                left += 1;
            }

            longest = right - left + 1;
        }

        return longest; 
    }
}

/*
 
  Small optimization to avoid re-calculating the max freqency more often than is needed.

  Time: O(n)
  Space: O(1)

  ------------------------------------------------------------------------------------

  Optimized from O(n*26)

  Key insights: It's not necessary to check the character count map for the most frequent character.

  This works because the only way for the window size to grow past the max (longest) is for the max
  character count for a given character to grow to be larger than the last max.

*/
