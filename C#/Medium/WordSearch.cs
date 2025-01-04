public class Solution
{
    public bool Exist(char[][] board, string word)
    {
        int nRows = board.Length;
        int nCols = board[0].Length;

        bool dfs(int r, int c, int i)
        {
            if (i == word.Length) return true;
            if (r < 0 || c < 0 || r >= nRows || c >= nCols || board[r][c] != word[i] || board[r][c] == '#') return false;
            
            // Rather than using a set, mark the current path in-place
            char temp = board[r][c];
            board[r][c] = '#';

            if (dfs(r + 1, c, i + 1) ||
            dfs(r - 1, c, i + 1) ||
            dfs(r, c + 1, i + 1) ||
            dfs(r, c - 1, i + 1)) return true;

            board[r][c] = temp;
            return false;
        }

        for (int r = 0; r < board.Length; r++)
        {
            for (int c = 0; c < board[r].Length; c++)
            {
                if (dfs(r, c, 0)) return true;
            }
        }

        return false;
    }
}

/*

    Backtracking

    Time: O(n * 3^L)
    Space: O(L)

    Where n is the number of cells and L is the length of the word.

    -----------------------------------------------------------------

    Time complexity analysis

    In the worst-case, the input would look something like this:

    word = "aab"
    board = ['a','a''a','a']
            ['a','a''a','a']
            ['a','a''a','a']
            ['a','a''a','a']    
        
    We have to visit every cell once, and at each cell we make 4 checks for the next character O(4n) = O(n).

    After those 4 checks, we're running a backtracking algorithm on a 3-nary tree (since we can't traverse
    back to the previous cell). This gives an additional O(3^L-1) = O(3^L)

    So, in total, the runtime is O(n * 3^L)

    If the length of the word is greater than the total number of cells then the algorithms runtime is bounded
    by the number of cells rather than the lenght of the word. So, a more accurate way to state the runtime would be
    O(n * 3^min(L,n)). This could be easily avoided by adding a check to see if L > n, and if it is, returning false.

    -----------------------------------------------------------------

    Follow-up question: Could you use search pruning to make your solution faster with a larger board?

    Search pruning (in the context of backtracking algorithms) refers to the process of eliminating (or "pruning")
    certain branches of the search tree early, because they cannot lead to a valid or optimal solution.

    1. Create a character frequency map for the letters in the board, and another one for the letters in the word.
        - E.g. if the word has 3 'a' characters, but the board only as 2, then it's impossible for find the word.
        - In this scenario, we could just return false immediately, without searching the board.
        - Another scenario to check for is if any characters in word are completely missing from the board

    2. Store the coordinates of each cell that has the first character (in word)
        - Only run the algorithm startin from those cells (rather than trying from every cell in the board)

    2 is probably the better solution because if the board is big enough, it will most likely contain enough
    characters of word, so approach 1 might not help much.

*/



public class Solution2
{
    public bool Exist(char[][] board, string word)
    {
        var boardCount = new Dictionary<char, int>();
        var wordCount = new Dictionary<char, int>();
        int nRows = board.Length;
        int nCols = board[0].Length;

        // Count the freq of the characters in the board
        for (int r = 0; r < board.Length; r++)
        {
            for (int c = 0; c < board[r].Length; c++)
            {
                char ch = board[r][c];
                if (!boardCount.ContainsKey(ch)) boardCount.Add(ch, 0);
                boardCount[ch] += 1;
            }
        }

        // Count the frequency of the characters in the word
        foreach (char c in word)
        {
            if (!wordCount.ContainsKey(c)) wordCount.Add(c, 0);
            wordCount[c] += 1;
        }

        // Check the word count to prune out words can't be found
        foreach (char c in word)
        {
            // If the board is missing a character contained in word, has too few, return false
            if (!boardCount.ContainsKey(c) || wordCount[c] > boardCount[c]) return false;
        }

        bool dfs(int r, int c, int i)
        {
            if (i == word.Length) return true;
            if (r < 0 || c < 0 || r >= nRows || c >= nCols || board[r][c] != word[i] || board[r][c] == '#') return false;
            
            // Rather than using a set, mark the current path in-place
            char temp = board[r][c];
            board[r][c] = '#';

            if (dfs(r + 1, c, i + 1) ||
            dfs(r - 1, c, i + 1) ||
            dfs(r, c + 1, i + 1) ||
            dfs(r, c - 1, i + 1)) return true;

            board[r][c] = temp;
            return false;
        }

        for (int r = 0; r < board.Length; r++)
        {
            for (int c = 0; c < board[r].Length; c++)
            {
                if (dfs(r, c, 0)) return true;
            }
        }

        return false;
    }
}

/*

    Same solution as above but with the following optimization (from the follow-up question).

    1. Create a character frequency map for the letters in the board, and another one for the letters in the word
        - E.g. if the word has 3 'a' characters, but the board only as 2, then it's impossible for find the word
        - Check if any characters in word are completely missing from the board
        - If either condition is met, just return false immediately, without searching the board

*/
