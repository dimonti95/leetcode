public class Solution {
    public bool IsAnagram(string s, string t) {
        var sMap = new Dictionary<char, int>();
        var tMap = new Dictionary<char, int>();

        // create sMap
        foreach (char c in s)
        {
            if (sMap.ContainsKey(c)) sMap[c] += 1;
            else sMap.Add(c, 1);
        }

        // create tMap
        foreach (char c in t)
        {
            if (tMap.ContainsKey(c)) tMap[c] += 1;
            else tMap.Add(c, 1);
        }

        // return false if the number of unique characters isn't equal
        if (sMap.Keys.Count != tMap.Keys.Count) return false;

        // check the count of each character
        foreach (var pair in sMap)
        {
            if (!tMap.ContainsKey(pair.Key)) return false;
            if (sMap[pair.Key] != tMap[pair.Key]) return false;
        }
        
        return true;
    }
}

/*

  Map each character to the difference of the number occurences of each character in each string
  
  Time Complexity: O(n)
  Space Complexity: O(1) because the input is gauranteed to be lowercase english characters

*/
