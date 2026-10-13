using System.Diagnostics;

public class Solution {
    public bool HasValidPath(char[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        if ((m + n - 1) % 2 != 0 || grid[0][0] == ')' || grid[m-1][n-1] == '(') return false;
        HashSet<(int, int, int)> cache = []; // cache failed state
        return Dfs(grid, 0, 0, 0, cache);
    }

    private static bool Dfs(char[][] grid, int i, int j, int count, HashSet<(int, int, int)> cache) {
        if (i >= grid.Length || j >= grid[0].Length) return false;
        count += grid[i][j] == '(' ? 1 : -1;
        if (count < 0 || cache.Contains((i, j, count))) return false;
        int remaining = (grid.Length - i - 1) + (grid[0].Length - j - 1);   // fail fast
        if (count > remaining) return false;
        if (i == grid.Length - 1 && j == grid[0].Length - 1) return count == 0; // last cell
        if (Dfs(grid, i + 1, j, count, cache) || Dfs(grid, i, j + 1, count, cache)) return true; // dfs
        cache.Add((i, j, count));
        return false;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        char[][] grid = [
            ['(', '(', '('],
            [')', '(', ')'],
            ['(', '(', ')'],
            ['(', '(', ')']
        ];
        Debug.Assert(sol.HasValidPath(grid) == true);

        grid = [
            [')', ')'],
            ['(', '(']
        ];
        Debug.Assert(sol.HasValidPath(grid) == false);

        Console.WriteLine("passed");
    }
}
