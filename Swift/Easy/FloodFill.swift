class Solution {
    func floodFill(_ image: [[Int]], _ sr: Int, _ sc: Int, _ color: Int) -> [[Int]] {
        if image[sr][sc] == color { return image }

        var image = image
        let nRows = image.count
        let nCols = image[0].count
        let oldColor = image[sr][sc]

        func fill(_ row: Int, _ col: Int, _ color: Int) {
            if (row < 0 || col < 0 || row >= nRows || col >= nCols) { return }
            if (image[row][col] != oldColor) { return }
            
            image[row][col] = color
            fill(row + 1, col, color)
            fill(row - 1, col, color)
            fill(row, col + 1, color)
            fill(row, col - 1, color)
        }

        fill(sr, sc, color)
        return image
    }
}

/*

    DFS flood fill

    Time: O(m * n)
    Space: O(m * n)

*/