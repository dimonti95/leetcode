public class Solution {
    public bool IsAnagram(string s, string t) {
        var count = new Dictionary<char, int>();

        // confirm both strings are the same length
        if (s.Length != t.Length) return false;

        // create sMap
        for (int i = 0; i < s.Length; i++)
        {
            char sChar = s[i];
            char tChar = t[i];

            if (count.ContainsKey(sChar)) count[sChar] += 1;
            else count.Add(sChar, 1);

            if (count.ContainsKey(tChar)) count[tChar] -= 1;
            else count.Add(tChar, -1);
        }

        // check the count of each character
        foreach (var pair in count)
        {
            if (count[pair.Key] != 0) return false;
        }
        
        return true;
    }
}

/*

  Map each character to the difference of the number occurences of each character in each string
  
  Time Complexity: O(n)
  Space Complexity: O(1) because the input is gauranteed to be lowercase english characters

*/
