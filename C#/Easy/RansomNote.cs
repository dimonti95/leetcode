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

    Brute force solution:
    * For each character found in ransomNote, find and remove that character in magazine
    * If the character is not in magazine, then return false
    * Otherwise, if all ransomNote characters have been removed from magazine, return true

    This is the most straighforward approach, but because strings are immmutable (can't be modified), it's not optimal.

    This is because we would basically need to replace magazine with a new string for each character removed.

    Time: O(n*m)
    Space: O(m) - because of the new magazine object being created

    --------------------------------------------------

    Optimized Solution: Use a single hash map to track character count

    Time: O(n + m)
    Space: O(26) = O(1)

*/
