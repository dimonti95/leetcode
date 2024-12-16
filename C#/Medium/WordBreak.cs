public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var wordSet = new HashSet<string>(wordDict);
        var seen = new bool[s.Length + 1];
        var queue = new Queue<int>();
        queue.Enqueue(0);

        while (queue.Count > 0)
        {
            int start = queue.Dequeue();
            if (start == s.Length) return true;

            for (int end = start + 1; end <= s.Length; end++)
            {
                if (seen[end]) continue;

                if (wordSet.Contains(s.Substring(start, end - start)))
                {
                    queue.Enqueue(end);
                    seen[end] = true;
                }
            }
        }
        
        return false;
    }
}

/*

    BFS with the indicies of s as nodes
    
    Time: O(w*k + s^3)
    * s^3 because each iteration of BFS can is O*n^2) time, and BFS itself can be O(n)
    * w*k because 

    Space: O(w + s)
    * w because we can have up to s.Length nodes in the queue
    * s because we're using the seen array to tracked visited nodes

    Where w is the length of wordDict, k is the average length of each word, and s is the length of the input string s.

*/

