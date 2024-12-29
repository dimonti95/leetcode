public class Solution
{
    public string MinWindow(string s, string t)
    {
        var tCount = new Dictionary<char, int>();
        var sCount = new Dictionary<char, int>();
        var res = new Tuple<int, int, int>(Int32.MaxValue, 0, -1); // min, left, right

        // Create character freq map for t
        foreach (char c in t)
        {
            if (!tCount.ContainsKey(c)) tCount.Add(c, 0);
            tCount[c] += 1;
        }

        int needCount = tCount.Keys.Count;
        int haveCount = 0;
        int left = 0;
        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];
            if (!sCount.ContainsKey(c)) sCount.Add(c, 0);
            sCount[c] += 1; 

            if (tCount.ContainsKey(c) && sCount[c] == tCount[c]) haveCount += 1;

            // check if window is valid
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

    Where s is the length of the input string s and t is the length of the input string t.

    Key insight/optimization: It's not necessary to check the count of every character on each iteration, instead just track the following:
    * needCount = the number of unique characters in t (the characters that are required for the window to be valid)
    * haveCount = the number of unique characters in the current window at the target frequency

    --------------------------------------------------------------------------------------------------------

    Additional optimization: Create a filtered version of string s.
    
    The bottleneck of the algorithm is the sliding window portion that runs in O(2s) where s is the length of the input string s.
    In the worste case, both pointers iterate the full length of s.

    We can optmize this by creating a filtered version of s. For example,
    
    Input: s="faswzbebwf", t="asbb"
    Output: "aswzbeb"

    The only information we need on s is the position of the characters from t.

    filtered s = [(a,1), (s,2), (b,5), (b,7)]

    Where (a,1) means that the character 'a' is at index 1.

*/
