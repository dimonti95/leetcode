public class Solution
{
    public bool Exist(char[][] board, string word)
    {
        int nRows = board.Length;
        int nCols = board[0].Length;

        bool dfs(int r, int c, int i)
        {
            if (i == word.Length) return true;
            if (r < 0 || c < 0 || r >= nRows || c >= nCols || i >= word.Length || board[r][c] != word[i] || board[r][c] == '#') return false;
            
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

    ..


*/
