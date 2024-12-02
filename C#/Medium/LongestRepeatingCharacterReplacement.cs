public class Solution {
    public int CharacterReplacement(string s, int k) {
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
