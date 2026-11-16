using System.Diagnostics;

public class Solution {
    private static readonly (int rowOffset, int colOffset)[] Directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];

    public int CountIslands(int[][] grid, int k) {
        int rows = grid.Length, cols = grid[0].Length;
        int result = 0;
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (grid[i][j] == 0) continue;
                long totalValue = TotalValueAfterFloodFill(grid, i, j);
                if (totalValue % k == 0) {
                    result++;
                }
            }
        }
        return result;
    }

    private static long TotalValueAfterFloodFill(int[][] grid, int i, int j) {
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == 0) {
            return 0;
        }
        long totalValue = grid[i][j];
        grid[i][j] = 0;
        Queue<(int row, int col)> queue = new();
        queue.Enqueue((i, j));

        while (queue.Count > 0) {
            (int row, int col) = queue.Dequeue();
            foreach ((int rowOffset, int colOffset) in Directions) {
                (int ii, int jj) = (row + rowOffset, col + colOffset);
                if (ii < 0 || ii >= grid.Length || jj < 0 || jj >= grid[0].Length || grid[ii][jj] == 0) {
                    continue;
                }
                totalValue += grid[ii][jj];
                grid[ii][jj] = 0;
                queue.Enqueue((ii, jj));
            }
        }
        return totalValue;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[][] grid = [
            [0, 2, 1, 0, 0],
            [0, 5, 0, 0, 5],
            [0, 0, 1, 0, 0],
            [0, 1, 4, 7, 0],
            [0, 2, 0, 0, 8]
        ];
        int k = 5;
        Debug.Assert(sol.CountIslands(grid, k) == 2);

        grid = [
            [3, 0, 3, 0],
            [0, 3, 0, 3],
            [3, 0, 3, 0]
        ];
        k = 3;
        Debug.Assert(sol.CountIslands(grid, k) == 6);

        Console.WriteLine("passed");
    }
}
