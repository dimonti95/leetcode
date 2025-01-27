public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
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

        return new List<IList<string>>(countMap.Values);
    }
}

/*

    Time: O(n * m)
    Space: O(n * m)

    ----------------------------------------------------------------------------------------------------------------

    Brute force solution:
    1. Loop over the input array
    2. Sort the string
    3. Using the sorted string as a key, map it to a list with the original string

    Time: O(n * mlogm)

    Where n is the length of strs
    And m is the average length of each string

    ----------------------------------------------------------------------------------------------------------------

    Key insight: Anagrams must have the same character frequency, so we can map the character to a count.

    Optimized solution:
    1. Build a character frequency map for each string
    2. Use character frequency map as a key to group the anagrams

    Time: O(n * m)
    Space: O(n * m)

    Where n is the length of strs
    And m is the average length of each string

    ----------------------------------------------------------------------------------------------------------------

    C# notes:
    * By default, the GetHashCode function for all reference types use the memory address rather than the content.
    * This means you can't use Dictionary, List, or Array as a key for the Dictionary, because they're all reference types.
    * Two Dictionary/Array/List objects with the same content (e.g., [1, 1, 1] and [1, 1, 1]) are still distinct objects stored at different memory locations.
    * This is why the array needs to be converted to a string to use it as a Dictionary key.

*/
