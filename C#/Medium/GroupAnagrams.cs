public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var res = new List<IList<string>>();
        var countMap = new Dictionary<string, List<string>>();
        
        // map character counts to List of anagrams
        for (int i = 0; i < strs.Length; i++)
        {
            string str = strs[i];
            var counts = new int[26]; // C# will automatically init these values to 0 (the default value for an int)

            foreach (char c in str)
            {
                counts[c - 'a'] += 1;
            }

            string key = string.Join(",", counts);
            if (countMap.ContainsKey(key))
                countMap[key].Add(str);
            else
                countMap[key] = new List<string> { str };
        }

        // loop over each count array and add the anagram group to the final list
        foreach (var pair in countMap)
        {
            res.Add(countMap[pair.Key]);
        }

        return res;
    }
}

/*

    Time: O(n * m)
    Space: O(m)

    Brute force solution:
    1. Loop over the input array
    2. Sort the string
    3. Using the sorted string as a key, map it to a list with the original string

    Time: O(n * mlogm)

    Where n is the length of strs
    And m is the average length of each string

    Key insight: Anagrams must have the same character frequency, so we can map the character to a count.

    Optimized solution:
    1. Build a character frequency map for each string
    2. Use character frequency map as a key to group the anagrams

    Time: O(n * m)
    Space: O(m)

    C# notes:
    * You can't use a Dictionary as a key for a Dictionary, because it doesn't implement GetHashCode().
    * You can conver the integer array to a string and use that as the Dictionary key.

*/
