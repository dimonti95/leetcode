public class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var count = new Dictionary<char, int>();

        foreach (char c in magazine)
        {
            if (!count.ContainsKey(c)) count.Add(c, 0);
            count[c] += 1;
        }

        foreach (char c in ransomNote)
        {
            if (!count.ContainsKey(c) || count[c] == 0) return false;
            count[c] -= 1;
        }

        return true;
    }
}

/*

    Use a single hash map to track character count

    Time: O(n + m)
    Space: O(26) = O(1)

*/
