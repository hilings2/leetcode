using System.Diagnostics;

public class Solution {
    private static readonly (int rowOffset, int colOffset)[] Directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];

    public int ClosedIsland(int[][] grid) {
        int rows = grid.Length, cols = grid[0].Length;
        for (int i = 0; i < rows; i++) { // flood from boundary cells
            FloodFill(grid, i, 0);
            FloodFill(grid, i, cols - 1);
        }
        for (int j = 0; j < cols; j++) {
            FloodFill(grid, 0, j);
            FloodFill(grid, rows - 1, j);
        }
        int result = 0;
        for (int i = 1; i < rows - 1; i++) {
            for (int j = 1; j < cols - 1; j++) {
                if (grid[i][j] == 0) {
                    FloodFill(grid, i, j);
                    result++;
                }
            }
        }
        return result;
    }

    private static void FloodFill(int[][] grid, int i, int j) {
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == 1) {
            return;
        }
        grid[i][j] = 1;
        Queue<(int row, int col)> queue = new();
        queue.Enqueue((i, j));

        while (queue.Count > 0) {
            (int row, int col) = queue.Dequeue();
            foreach ((int rowOffset, int colOffset) in Directions) {
                (int ii, int jj) = (row + rowOffset, col + colOffset);
                if (ii < 0 || ii >= grid.Length || jj < 0 || jj >= grid[0].Length || grid[ii][jj] == 1) {
                    continue;
                }
                grid[ii][jj] = 1;
                queue.Enqueue((ii, jj));
            }
        }
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[][] grid = [
            [1, 1, 1, 1, 1, 1, 1, 0],
            [1, 0, 0, 0, 0, 1, 1, 0],
            [1, 0, 1, 0, 1, 1, 1, 0],
            [1, 0, 0, 0, 0, 1, 0, 1],
            [1, 1, 1, 1, 1, 1, 1, 0]
        ];
        Debug.Assert(sol.ClosedIsland(grid) == 2);

        grid = [
            [0, 0, 1, 0, 0],
            [0, 1, 0, 1, 0],
            [0, 1, 1, 1, 0]
        ];
        Debug.Assert(sol.ClosedIsland(grid) == 1);

        grid = [
            [1, 1, 1, 1, 1, 1, 1],
            [1, 0, 0, 0, 0, 0, 1],
            [1, 0, 1, 1, 1, 0, 1],
            [1, 0, 1, 0, 1, 0, 1],
            [1, 0, 1, 1, 1, 0, 1],
            [1, 0, 0, 0, 0, 0, 1],
            [1, 1, 1, 1, 1, 1, 1]
        ];
        Debug.Assert(sol.ClosedIsland(grid) == 2);

        grid = [
            [0, 1, 1],
            [1, 0, 1],
            [1, 1, 1]
        ];
        Debug.Assert(sol.ClosedIsland(grid) == 1);

        grid = [[0]];
        Debug.Assert(sol.ClosedIsland(grid) == 0);

        grid = [[0, 0, 0]];
        Debug.Assert(sol.ClosedIsland(grid) == 0);

        grid = [[0], [0], [0]];
        Debug.Assert(sol.ClosedIsland(grid) == 0);

        grid = [[1, 1], [1, 1]];
        Debug.Assert(sol.ClosedIsland(grid) == 0);

        grid = new int[100][];
        for (int i = 0; i < grid.Length; i++) {
            grid[i] = new int[100];
        }
        Debug.Assert(sol.ClosedIsland(grid) == 0);

        Console.WriteLine("passed");
    }
}
