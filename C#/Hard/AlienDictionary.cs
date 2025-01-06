public class Solution
{
    public string AlienOrder(string[] words)
    {
        var result = new List<char>();
        var adjList = new Dictionary<char, List<char>>();
        var visited = new Dictionary<char, bool>(); // true=in current path, false=processed

        // Init the graph for each unique character
        for (int i = 0; i < words.Length; i++)
        {
            foreach (char c in words[i])
            {
                if (!adjList.ContainsKey(c)) adjList.Add(c, new List<char>());
            }
        }

        // Add relationships to the graph
        for (int i = 1; i < words.Length; i++)
        {
            string w1 = words[i - 1];
            string w2 = words[i];
            int len = Math.Min(w1.Length, w2.Length);
            bool samePrefix = true;
            for (int j = 0; j < len; j++)
            {
                char c1 = w1[j];
                char c2 = w2[j];
                if (c1 != c2)
                {    
                    if (!adjList.ContainsKey(c1)) adjList.Add(c1, new List<char>());
                    adjList[c1].Add(c2);
                    samePrefix = false;
                    break;
                }
            }

            // An important edge case - if the prefixes are the same, the smaller word should ALWAYS come first.
            // If the smaller of two matching prefixes doesnt come first, then the order is invalid.
            if (samePrefix && w1.Length > w2.Length) return "";
        }

        // Run topological sort and check for cycles
        bool dfs(char c)
        {
            if (visited.ContainsKey(c)) return visited[c];
            visited.Add(c, true);

            foreach (char neighbor in adjList[c])
            {
                if (dfs(neighbor)) return true;
            }

            result.Add(c);
            visited[c] = false;
            return false;
        }

        // Run topolocal sort on each unvisited piece/subgraph checking for cycles
        foreach (var pair in adjList)
        {
            if (dfs(pair.Key)) return "";
        }

        // Reverse the output string
        result.Reverse();
        return new string(result.ToArray());
    }
}

/*

    The first step to solving this problem is understanding lexographical ordering.

    English letters have the following lexigraphical ordering "abcd..."

    s2 is lexigraphically smaller than s1
    string s1 = "abc"
    string s2 = "aba"

    s1 is lexigraphically smaller than s2
    string s1 = "ab"
    string s2 = "aba"

    s2 is lexigraphically smaller than s1
    string s1 = "ab"
    string s2 = "aaa"

    Solution:
    1. Derive the dependency relationship between letters
    2. Build a directed graph from those dependency relationships
        - letters as nodes
        - relationships as edges
    3. Run a topological sort on the graph to derive a valid ordering (there may be more than one)
        - If a cycle is found, then return an empty string
        - If no cycle is found, return the ordering
    
    Time: O(c)
    Space: O(1)

    Where c is the total number of characters in each word added together

*/
