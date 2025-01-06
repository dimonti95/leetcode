public class Solution
{
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        int nRows = image.Length;
        int nCols = image[0].Length;
        int newColor = image[sr][sc];

        void dfs(int r, int c)
        {
            if (r < 0 || c < 0 || r >= nRows || c >= nCols) return;
            if (image[r][c] != newColor || image[r][c] == color) return;

            image[r][c] = color;
            dfs(r + 1, c);
            dfs(r - 1, c);
            dfs(r, c + 1);
            dfs(r, c - 1);
        }

        dfs(sr, sc);
        return image;
    }
}

/*

    DFS

    Time: O(m * n)
    Space: O(m * n)

    Where m is the number of rows and n is the number of columns of the image

    ---------------------------------------------------------------

    Note: An important edge case to consider is when image[sr][sc] == color (it can lead to stack overflow).

*/
