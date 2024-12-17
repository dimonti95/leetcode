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



public class Solution2
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var memo = new Dictionary<int, bool>();
        
        bool WordBreakRecursive(string s, IList<string> wordDict, int index)
        {
            if (index == s.Length) return true;
            if (memo.ContainsKey(index)) return memo[index];

            foreach (string word in wordDict)
            {
                int end = index + word.Length;
                if (end <= s.Length)
                {
                    string substr = s.Substring(index, word.Length);
                    if (substr == word && WordBreakRecursive(s, wordDict, index + word.Length))
                    {
                        memo[index] = true;
                        return memo[index];
                    }
                }
            }

            memo[index] = false;
            return memo[index];
        }
        
        return WordBreakRecursive(s, wordDict, 0);
    }
}

/*

    Top-down DP (memoization)

    Time: O(s*w*k)
    - We make s recursive calls (where s is the length of the input string s)
    - Each recursive call only "calculates" once (because of memoization)
    - Each calculation takes w*k time

    Space: O(s)
    - O(s) memory used for memoization (worst case)
    - The calls stack uses an additional O(n) memory (again, worst case)
    - O(2s) = O(s)

    Where s is the length of the input string s,
    w is the length of the input array wordDict,
    k is the average length of a string in wordDict
    
*/



public class Solution3
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var table = new bool[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            foreach (string word in wordDict)
            {
                if (i < word.Length - 1) continue;

                if (i == word.Length - 1 || table[i - word.Length])
                {
                    if (s.Substring(i - word.Length + 1, word.Length) == word)
                    {
                        table[i] = true;
                        break;
                    }
                }
            }
        }

        return table[s.Length - 1];
    }
}

/*

    Bottom-up DP (tabulation)

    Time: O(s*w*k)
    Space: O(s)

    Where s is the length of the input string s,
    w is the length of the input array wordDict,
    k is the average length of a string in wordDict

    --------------------------------------------------------------------

    Walkthrough

    table = [F,F,F,F,F,F,F,F,F]
             0 1 2 3 4 5 6 7 8
    
    "catsandog", wordDict = ["cats","dog","sand","and","cat"]

    i = 0
    table = [F,F,F,F,F,F,F,F,F,F]
    "catsandog"
     ^
    
    i = 1
    table = [F,F,F,F,F,F,F,F,F,F]
    "catsandog"
      ^
    
    i = 2
    table = [F,F,T,F,F,F,F,F,F]
    "catsandog"
       ^
    
    i = 3
    table = [F,F,T,T,F,F,F,F,F]
    "catsandog"
        ^
    
    i = 4
    table = [F,F,T,T,F,F,F,F,F]
    "catsandog"
         ^

    i = 5
    table = [F,F,T,T,F,F,F,F,F]
    "catsandog"
          ^

    i = 6
    table = [F,F,T,T,F,F,T,F,F]
    "catsandog"
           ^

    i = 7
    table = [F,F,T,T,F,F,T,F,F]
    "catsandog"
            ^

    i = 8
    table = [F,F,T,T,F,F,T,F,F]
    "catsandog"
             ^
    "cats" => table[8 - 4] = table[4] = F
    "dog"  => table[8 - 3] = table[5] = F
    "sand" => table[8 - 4] = table[4] = F
    "and"  => table[8 - 3] = table[5] = F
    "cat"  => table[8 - 3] = table[5] = F

*/
