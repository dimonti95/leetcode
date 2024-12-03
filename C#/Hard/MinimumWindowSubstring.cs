public class Solution {
    public string MinWindow(string s, string t) {
        var tCount = new Dictionary<char, int>();
        var sCount = new Dictionary<char, int>();
        var res = new Tuple<int, int, int>(Int32.MaxValue, 0, -1); // min, left, right
        int needCount = 0;
        int haveCount = 0;

        // Create character freq map for t
        foreach (char c in t)
        {
            if (tCount.ContainsKey(c))
            {
                tCount[c] += 1;
            }
            else
            {
                tCount.Add(c, 1);
                needCount += 1;
            }
        }

        int left = 0;
        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];
            if (sCount.ContainsKey(c))
            {
                sCount[c] += 1;
            } 
            else
            {
                sCount.Add(c, 1);
            } 

            if (tCount.ContainsKey(c) && sCount[c] == tCount[c]) haveCount += 1;

            // check to see if window is valid
            while (haveCount == needCount)
            {
                int windowSize = right - left + 1;

                // check for new min
                if (windowSize < res.Item1)
                {
                    res = new Tuple<int, int, int>(windowSize, left, right);
                }

                // contract window size
                char leftChar = s[left];
                if (tCount.ContainsKey(leftChar) && sCount[leftChar] == tCount[leftChar])
                    haveCount -= 1;
                sCount[leftChar] -= 1;
                left++;
            }
        }

        return s.Substring(res.Item2, res.Item3 - res.Item2 + 1);
    }
}

/*

    Time: O(s + t)
    Space: O(1) since the total number of unique characters never exceeds 52 (26 uppercase & 26 lowercase)

    Optimization:
    needCount = the number of unique characters in t
    haveCount = the number of unique characters in the current window at the target frequency

*/
