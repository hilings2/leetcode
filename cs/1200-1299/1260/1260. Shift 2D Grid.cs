using System.Diagnostics;

public class Solution {
    public IList<IList<int>> ShiftGrid(int[][] grid, int k) {
        int m = grid.Length, n = grid[0].Length, l = m * n;
        k %= l;
        List<IList<int>> res = [];
        for (int i = 0; i < m; i++) {
            res.Add([]);
            for (int j = 0; j < n; j++) {
                int idx = (i * n + j - k + l) % l;
                res[i].Add(grid[idx / n][idx % n]);
            }
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[][] grid = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
        int k = 1;
        int[][] expected = [[9, 1, 2], [3, 4, 5], [6, 7, 8]];
        Debug.Assert(sol.ShiftGrid(grid, k).Select(r => string.Join(",", r)).SequenceEqual(expected.Select(r => string.Join(",", r))));

        grid = [[3, 8, 1, 9], [19, 7, 2, 5], [4, 6, 11, 10], [12, 0, 21, 13]];
        k = 4;
        expected = [[12, 0, 21, 13], [3, 8, 1, 9], [19, 7, 2, 5], [4, 6, 11, 10]];
        Debug.Assert(sol.ShiftGrid(grid, k).Select(r => string.Join(",", r)).SequenceEqual(expected.Select(r => string.Join(",", r))));

        grid = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
        k = 9;
        expected = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
        Debug.Assert(sol.ShiftGrid(grid, k).Select(r => string.Join(",", r)).SequenceEqual(expected.Select(r => string.Join(",", r))));

        Console.WriteLine("passed");
    }
}
