public class Solution {
    public string AlienOrder(string[] words)
    {
        // Init the graph for each unique character
        var adjList = new Dictionary<char, List<char>>();
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
            int j = 0;
            int len = Math.Min(w1.Length, w2.Length);
            bool samePrefix = true;
            while (j < len)
            {
                char c1 = w1[j];
                char c2 = w2[j];
                if (c1 != c2)
                {
                    adjList[c1].Add(c2);
                    samePrefix = false;
                    break;
                }
                j++;
            }

            if (samePrefix && w1.Length > w2.Length) return "";
        }

        // Run topological sort and check for cycles
        var res = new List<char>();
        var visited = new Dictionary<char, bool>(); // false=visited, true=in current path
        bool dfs(char c)
        {
            if (visited.ContainsKey(c)) return visited[c];
            
            if (!visited.ContainsKey(c)) visited.Add(c, true);
            else visited[c] = true;

            foreach (char neighbor in adjList[c])
            {
                if (dfs(neighbor)) return true;
            }

            visited[c] = false;
            res.Add(c);
            return false;
        }

        // Run topolocal sort on each unvisited piece/subgraph checking for cycles
        foreach (var pair in adjList)
        {
            if (!visited.ContainsKey(pair.Key))
            {
                if (dfs(pair.Key)) return "";
            }
        }

        // Reverse the output string
        res.Reverse();
        return new string(res.ToArray());
    }
}

/*

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
    2. Build a graph from those dependency relationships
        - letters as nodes
        - relationships as edges
    3. Run a topological sort on the graph to derive a valid ordering (there may be more than one)
        - If a cycle is found, then return an empty string
        - If no cycle is found, return the ordering
    
    Time: O()
    Time: O()

    Where

*/
