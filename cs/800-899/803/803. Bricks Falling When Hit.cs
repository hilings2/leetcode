using System.Diagnostics;

public class Solution {
    private static readonly int[][] directions = [ [0, 1], [0, -1], [1, 0], [-1, 0] ];

    public int[] HitBricks(int[][] grid, int[][] hits) {
        int n = grid.Length, m = grid[0].Length;
        int[][] copy = new int[n][];
        for (int i = 0; i < n; i++) {
            copy[i] = (int[])grid[i].Clone();
        }
        foreach (int[] hit in hits) { // apply all hits
            copy[hit[0]][hit[1]] = 0;            
        }

        bool[][] stable = new bool[n][];
        for (int i = 0; i < n; i++) {
            stable[i] = new bool[m];
        }

        for (int j = 0; j < m; j++) {
            if (copy[0][j] == 1) {
                MarkStableAndCountFalls(copy, stable, 0, j);
            }
        }

        int[] res = new int[hits.Length];
        for (int i = hits.Length - 1; i >= 0; i--) { // restore the hits in reverse order
            (int x, int y) = (hits[i][0], hits[i][1]);
            if (grid[x][y] == 0) {
                continue;
            }
            copy[x][y] = 1; // restore the brick
            if (x == 0 || HasStableNeighbor(stable, x, y)) {
                res[i] = MarkStableAndCountFalls(copy, stable, x, y);
            }
        }
        return res;
    }

    private static bool IsValid(bool[][] stable, int x, int y) {
        return x >= 0 && x < stable.Length && y >= 0 && y < stable[0].Length;
    }

    private static bool HasStableNeighbor(bool[][] stable, int x, int y) {
        foreach (int[] dir in directions) {
            (int nx, int ny) = (x + dir[0], y + dir[1]);
            if (IsValid(stable, nx, ny) && stable[nx][ny]) {
                return true;
            }
        }
        return false;
    }

    private static int MarkStableAndCountFalls(int[][] copy, bool[][] stable, int x, int y) {
        stable[x][y] = true;
        Queue<(int, int)> queue = new();
        queue.Enqueue((x, y));
        int count = 0;
        while (queue.Count > 0) {
            (int cx, int cy) = queue.Dequeue();
            foreach (int[] dir in directions) {
                (int nx, int ny) = (cx + dir[0], cy + dir[1]);
                if (IsValid(stable, nx, ny) && copy[nx][ny] == 1 && !stable[nx][ny]) {
                    stable[nx][ny] = true;
                    queue.Enqueue((nx, ny));
                    count++;
                }
            }
        }
        return count;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[][] grid = [[1, 0, 0, 0], [1, 1, 1, 0]];
        int[][] hits = [[1, 0]];
        Debug.Assert(sol.HitBricks(grid, hits).SequenceEqual([2]));

        grid = [[1, 0, 0, 0], [1, 1, 0, 0]];
        hits = [[1, 1], [1, 0]];
        Debug.Assert(sol.HitBricks(grid, hits).SequenceEqual([0, 0]));

        Console.WriteLine("passed");
    }
}