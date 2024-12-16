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
    * w*k because (apparently) you need to account for the length when hashing a string

    Space: O(w + s)
    * w because we can have up to s.Length nodes in the queue
    * s because we're using the seen array to tracked visited nodes

    Where w is the length of wordDict, k is the average length of each word, and s is the length of the input string s.

    ----------------------------------------------------------------------------------------------------

    Example
    Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
    Input: false

    node = 0
    queue = [3,4]
    seen = [F,F,F,T,T,F,F,F,F,F]
    strings found = "cat", "cats"
    "catsandog"
     ^ 

    node = 3
    queue = [4,7]
    seen = [F,F,F,T,T,F,F,T,F,F]
    strings found = "sand"
    "catsandog"
        ^ 

    node = 4
    queue = [7]
    seen = [F,F,F,T,T,F,F,T,F,F]
    "catsandog"   already found a word that ends at index 6
         ^ 

    node = 7
    queue = []
    seen = [F,F,F,T,T,F,F,T,F,F]
    "catsandog"
            ^ 

    ----------------------------------------------------------------------------------------------------

    An example of worst-case time complexity where a node gets pushed onto the queue for every characters in s
    s = "catsandog", wordDict = ["c","ca""cats","cat","catsa","catsan"]

*/

